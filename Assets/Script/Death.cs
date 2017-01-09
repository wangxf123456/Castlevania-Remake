using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

	public Vector3 velocity = new Vector3(2f, 0, 0);
	public int health;
	private int vel_timer = 90;
	private int weapon_timer = 480;
	private int hit_timer;
	public Boss_weapon boss_weapon;
	// Use this for initialization
	void Start () {
		health = 150;
		hit_timer = -1;
	}
	
	// Update is called once per frame
	void Update () {
		GameMaster.enemyHealth = health;
		vel_timer--;
		weapon_timer--;
		if (hit_timer >= 0) {
			hit_timer--;
		}
		if (vel_timer >= 0 && vel_timer < 180) {
			velocity.x = 2f;
			velocity.y = 0;
		} else if (vel_timer >= 180 && vel_timer < 210) {
			velocity.x = 0;
			velocity.y = 1f;
		} else if (vel_timer >= 210 && vel_timer < 390) {
			velocity.x = -2f;
			velocity.y = 0;
		} else if (vel_timer >= 390 && vel_timer < 420) {
			velocity.x = 0;
			velocity.y = -1f;
		} else if (vel_timer < 0){
			vel_timer = 420;
		}

		if (weapon_timer == 120 || weapon_timer == 80 || weapon_timer == 40) {
			GameObject player = GameObject.Find("Player");
			Vector3 pos = player.transform.position;
			pos.y += collider.bounds.size.y / 2;
			Instantiate (boss_weapon.gameObject, pos, player.transform.rotation);
		}

		if (weapon_timer <= 0) {
			weapon_timer = 360;
		}

		transform.position += velocity * Time.deltaTime;
	}

	void OnTriggerEnter(Collider other) {

		if (hit_timer < 0) {
			if (other.gameObject.GetComponent<Weapon>()) {
				health -= 10;
			} else if (other.gameObject.GetComponent<Dagger>()){
				health -= 10;
			}
			if (health <= 0) {
				Destroy(gameObject);
				Application.LoadLevel("Scene_3");
			}
			hit_timer = 60;
		}
	
	}
	
	void OnTriggerStay(Collider other) {
		OnTriggerEnter(other);
	}
}
