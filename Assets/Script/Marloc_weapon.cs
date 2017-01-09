using UnityEngine;
using System.Collections;

public class Marloc_weapon : MonoBehaviour {
	public Vector3 velocity = Vector3.zero;
	
	// Use this for initialization
	void Start () {
		if (velocity.x >= 0) {
			this.transform.Rotate (0, 180, 0);
		} else {
			this.transform.Rotate (0, 180, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += velocity * Time.deltaTime;			
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<Player>()) {
			Player player = other.gameObject.GetComponent<Player>();
		}
	}
	
	void OnTriggerStay(Collider other) {
		OnTriggerEnter(other);
	}
}
