using UnityEngine;
using System.Collections;

public class Bat : MonoBehaviour {
	public Vector3 velocity = new Vector3(2f, 0.5f, 0);
	private int timer;
	public bool isUp = false;
	
	// Use this for initialization
	void Start () {
		timer = 60;
	}
	
	// Update is called once per frame
	void Update () {




		timer--;
		transform.position += velocity * Time.deltaTime;

		if (transform.position.y > -7) {
			if (transform.position.x <= 62.6f || transform.position.x >= 78.3) {
				Destroy(this.gameObject);
			}
		}

		if (isUp) {
			if (timer % 60 < 30) {
				velocity.y = 1.3f;
			} else {
				velocity.y = -0.7f;
			}
		}
		else {
			if (timer % 60 < 30) {
				velocity.y = 0.7f;
			} else {
				velocity.y = -1.3f;
			}
		}

		if (timer < 0) {
			timer = 60;
		}
	}
	
	void OnTriggerEnter(Collider other) {
		Debug.Log (other.gameObject);
		if (other.gameObject.GetComponent<Weapon>()) {
			Destroy(this.gameObject);
		} else if (other.gameObject.GetComponent<Dagger>()){
			Destroy(this.gameObject);
		} 
	}
	
	void OnTriggerStay(Collider other) {
		OnTriggerEnter(other);
	}
}