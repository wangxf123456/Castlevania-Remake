using UnityEngine;
using System.Collections;

public class Marloc : MonoBehaviour {
	public Vector3 hori_velocity = new Vector3 (2f, 0, 0);
	private Vector3 velocity = new Vector3(0, 8f, 0);
	private int jump_timer;
	private int timer;
	private bool isFirst = true;
	public bool isFacePositive = true;
	public Marloc_weapon marloc_weapon;
	Collider floor = null;
	
	// Use this for initialization
	void Start () {
		jump_timer = 80;
		timer = 60;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameMaster.currentMapID == 1) {
			if (jump_timer <= 0) {
				jump_timer = -1;
				timer--;
			}
			
			if (jump_timer > 0) {
				jump_timer--;
			}
			
			
			if (timer <= 0) {
				velocity *= -1;
				timer = 60;
				if (velocity.x >= 0) {
					marloc_weapon.velocity.x = 4f;
				} else {
					marloc_weapon.velocity.x = -4f;
				}
				Destroy(Instantiate (marloc_weapon.gameObject, transform.position, transform.rotation), 2f);
			}	
			
			if (isFirst && jump_timer <= 0) {
				isFirst = false;
				velocity = hori_velocity;
			}
			
			if (jump_timer <= 75) {
				Vector3 pos = transform.position;
				pos.z = -1f;
				transform.position = pos;
			}
			
			transform.position += velocity * Time.deltaTime;
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
		
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<Floor>()) {
			if (!isFirst) {
				floor = other;
				velocity.y = 0;
				Vector3 pos = transform.position;
				pos.y = other.transform.position.y + other.collider.bounds.size.y / 2 + collider.bounds.size.y / 2;
				transform.position = pos;			
			}
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
