using UnityEngine;
using System.Collections;

public class Whip : MonoBehaviour {
	private int timer = 200;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timer == 0) {
			Destroy(this.gameObject);	
		}
		else {
			timer--;
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<Player>()) {
			Debug.Log ("player hits whip");
			Destroy(this.gameObject);
		}
	}
	
	void OnTriggerStay(Collider other) {
		OnTriggerEnter (other);
	}
}
