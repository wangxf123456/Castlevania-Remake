using UnityEngine;
using System.Collections;

public class Dagger : MonoBehaviour {
	public Vector3 velocity = Vector3.zero;
	public bool isFromTorch = false;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		Player player = GameObject.Find ("Player").GetComponent<Player>();
		if (player.isFacePositive) {
			velocity.x = 4;
			this.transform.Rotate (0, 180, 0);
		} else {
			velocity.x = -4;
			this.transform.Rotate (0, 180, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!isFromTorch) {
			transform.position += velocity * Time.deltaTime;			
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if ((other.gameObject.GetComponent<Zombie>() || other.gameObject.GetComponent<Death>() 
		     || other.gameObject.GetComponent<Bat>() || other.gameObject.GetComponent<Marloc>())
		    && !isFromTorch) {
			Destroy(gameObject);
		} else if (other.gameObject.GetComponent<Player>() && isFromTorch) {
			Player player = other.gameObject.GetComponent<Player>();
			player.canThrowDagger = true;
			GameMaster.currentWeapon = "Dagger";
			Destroy(gameObject);
		} else if (other.gameObject.GetComponent<Torch>()) {
			Destroy(gameObject);
		}
	}
	
	void OnTriggerStay(Collider other) {
		OnTriggerEnter(other);
	}
}
