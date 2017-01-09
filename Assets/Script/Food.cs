using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {
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
			Debug.Log ("player hits food");

			if (GameMaster.currentHealth + 5 > 10)
				GameMaster.currentHealth = 10;
			else
				GameMaster.currentHeart += 5;
			Destroy(this.gameObject);
		}
	}
	
	void OnTriggerStay(Collider other) {
		OnTriggerEnter (other);
	}
}
