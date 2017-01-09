using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public int id;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
//		if (other.gameObject.GetComponent<Player>()) {
//
//		}
	}
	
	void OnTriggerStay(Collider other) {
		OnTriggerEnter (other);
	}
}
