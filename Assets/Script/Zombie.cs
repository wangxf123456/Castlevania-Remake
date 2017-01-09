using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {
	private Vector3 velocity = new Vector3(2f, 0, 0);
	private int timer;
	public int time = 180;
	public bool isFacePositive = true;
	Collider floor = null;

	// Use this for initialization
	void Start () {
		timer = time;
	}
	
	// Update is called once per frame
	void Update () {

		timer--;
		transform.position += velocity * Time.deltaTime;
		if (timer <= 0) {
			velocity *= -1;
			timer = time;
		}
		if (!floor) {
			velocity += Physics.gravity * Time.deltaTime;
		}
		if (velocity.x > 0) {
			if (isFacePositive) {
				// do nothing
			}
			else {
				this.transform.Rotate (0, 180, 0);
				isFacePositive = true;
			}
		} 
		else if (velocity.x < 0) {
			if (isFacePositive) {
				this.transform.Rotate (0, 180, 0);
				isFacePositive = false;
			}
			else {
				// do nothing
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<Floor>()) {
			floor = other;
			velocity.y = 0;
			Vector3 pos = transform.position;
			pos.y = other.transform.position.y + other.collider.bounds.size.y / 2 + collider.bounds.size.y / 2;
			transform.position = pos; 
		} else if (other.gameObject.GetComponent<Weapon>()) {
			Destroy(this.gameObject);
		} else if (other.gameObject.GetComponent<Dagger>()){
			Destroy(this.gameObject);
		}
	}
	
	void OnTriggerStay(Collider other) {
		OnTriggerEnter(other);
	}
}
