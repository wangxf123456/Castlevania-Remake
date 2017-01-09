using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float maxVelocity;
	public GameObject weapon;
	public Vector3 velocity;
	private int weaponTimer = 0;
	private int hurtTimer = 0;
	private int daggerTimer = -1;
	private int weaponTimer1 = 0;
	private int godTimer = 0;
	Collider stair = null;
	Collider temp_stair = null;
	Collider floor = null;
	public int levelNum = 0;
	public bool isFacePositive = true;
	public bool canThrowDagger = false;
	private bool onStair = false;
	public Dagger dagger;
	
	// Use this for initialization
	void Start () {
		weapon = (GameObject)Instantiate(weapon, transform.position, transform.rotation);	
		weapon.SetActive (false);
	}

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
		DontDestroyOnLoad(dagger.transform.gameObject);
	}
	// Update is called once per frame
	void Update () {

		if (godTimer > 0) {
			if (godTimer % 15 >= 8) {
				transform.GetComponent<SpriteRenderer> ().color =new Color (256, 256, 256, 0);
			} else {
				transform.GetComponent<SpriteRenderer> ().color =new Color (256, 256, 256, 256);
			}
		}

		if (GameMaster.currentTime == 0) {
			GameMaster.currentLife--;
			GameMaster.currentHealth = 10;
			GameMaster.currentTime = 50000;
			transform.position = GameMaster.posBegin1;
		}

		if (GameMaster.currentHealth == 0) {
			GameMaster.currentLife--;
			GameMaster.currentWeapon = "None";
			GameMaster.currentHealth = 10;
			switch (GameMaster.currentStage) {
			case 1: 
				transform.position = GameMaster.posBegin1;
				break;
			case 2: 
				transform.position = GameMaster.posBegin2;
				break;
			case 3: 
				transform.position = GameMaster.posBegin3;
				break;
			case 4: 
				transform.position = GameMaster.posBegin4;
				break;
			case 5: 
				transform.position = GameMaster.posBegin5;
				break;
			case 6: 
				transform.position = GameMaster.posBegin6;
				break;
			}
		}

		if (GameMaster.currentLife == 0) {
			Application.LoadLevel("Scene_3");
		}


		if (daggerTimer >= 0) {
			daggerTimer--;		
		}

		weaponTimer--;
		weaponTimer1--;

		if (hurtTimer > 0) {
			hurtTimer--;
		}

		if (godTimer > 0) {
			godTimer--;
		}
		
		// change face position
		if (hurtTimer == 0) {
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
		
		if (stair) {
			Stair st = stair.gameObject.GetComponent<Stair>();
			
			// north-east
			if (st.slope > 0 && hurtTimer <= 0) {
				
				// upper arrow OR on stair
				if (Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.RightArrow) && onStair && !floor)) {
					
					// put it back
					if (floor) {
						Floor fl = floor.gameObject.GetComponent<Floor>();
						if (fl.transform.position.y < st.transform.position.y) {
							Vector3 pos0 = st.bottom;
							pos0.y += collider.bounds.size.y / 2;
							transform.position = pos0; 	
							floor = null;	
							onStair = true;
						}
					}
					velocity.x = maxVelocity * Mathf.Cos(st.slope);
					velocity.y = maxVelocity * Mathf.Sin(st.slope);
				} 
				else if (Input.GetKey(KeyCode.DownArrow) || (Input.GetKey(KeyCode.LeftArrow) && onStair && !floor)) {
					if (floor) {
						Floor fl = floor.gameObject.GetComponent<Floor>();
						if (fl.transform.position.y > st.transform.position.y) {
							Vector3 pos0 = st.top;
							pos0.y += collider.bounds.size.y / 2;
							transform.position = pos0; 	
							floor = null;	
							onStair = true;
						}
					}
					velocity.x = -maxVelocity * Mathf.Cos(st.slope);
					velocity.y = -maxVelocity * Mathf.Sin(st.slope);
				}
			}
			// south-east
			else if (hurtTimer <= 0){
				if (Input.GetKey(KeyCode.DownArrow) || (Input.GetKey(KeyCode.RightArrow) && onStair && !floor)) {
					if (floor) {
						Floor fl = floor.gameObject.GetComponent<Floor>();
						if (fl.transform.position.y >= st.transform.position.y) {
							Vector3 pos0 = st.top;
							pos0.y += collider.bounds.size.y / 2;
							transform.position = pos0; 	
							floor = null;	
							onStair = true;
						}
					}
					velocity.x = maxVelocity * Mathf.Cos(st.slope);
					velocity.y = maxVelocity * Mathf.Sin(st.slope);
				} 
				else if (Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.LeftArrow) && onStair && !floor)) {
					if (floor) {
						Floor fl = floor.gameObject.GetComponent<Floor>();
						if (fl.transform.position.y < st.transform.position.y) {
							Vector3 pos0 = st.bottom;
							pos0.y += collider.bounds.size.y / 2;
							transform.position = pos0; 	
							floor = null;
							onStair = true;
						}
					}
					velocity.x = -maxVelocity * Mathf.Cos(st.slope);
					velocity.y = -maxVelocity * Mathf.Sin(st.slope);
				}	
			}
		}
		
		// 
		if (floor && hurtTimer <= 0 && weaponTimer <= 0) {
			velocity.x = maxVelocity * Input.GetAxis("Horizontal");	
		}
		
		if (Input.GetButton ("Jump") && hurtTimer <= 0 && !onStair && weaponTimer <= 0) { 
			if (floor) {
				floor = null;
				velocity.y += 2.25f * maxVelocity;
			}
		}

		if (Input.GetKeyDown (KeyCode.A)) {
			Vector3 scene2_pos = new Vector3(-5f, 0, 0);
			transform.position = scene2_pos;
			GameMaster.currentStage = 5;
			GameMaster.prevStage = 5;

			Application.LoadLevel("Scene_2");
		}
		
		Vector3 pos = transform.position;
		if (isFacePositive) {
			pos.x += (collider.bounds.size.x * 0.5f + weapon.collider.bounds.size.x * 0.5f);
		} else {
			pos.x -= (collider.bounds.size.x * 0.5f + weapon.collider.bounds.size.x * 0.5f);	
		}
		pos.y += collider.bounds.size.x * 0.2f;	
		weapon.transform.position = pos;
		if (Input.GetButtonDown("Fire1") && hurtTimer <= 0 && weaponTimer1 <= 0) {
			if (Input.GetKey(KeyCode.UpArrow) && canThrowDagger && daggerTimer < 0) {
				if (GameMaster.currentHeart > 0) {
					daggerTimer = 60;
					Destroy(Instantiate (dagger.gameObject, transform.position, transform.rotation), 2f);
					GameMaster.currentHeart -= 1;
				}
			} else {
				weapon.SetActive(true);
				weaponTimer = 15;
				weaponTimer1 = 45;
			}
			
		}
		
		if (weaponTimer <= 0) {
			weapon.SetActive(false);
		}
		
		if (!floor && !onStair) {
			velocity += Physics.gravity * Time.deltaTime;
		}
		
		//		Debug.Log (velocity.x);
		transform.position += velocity * Time.deltaTime;
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<Stair>()) {
			stair = other;
			if (onStair) {
				velocity = Vector3.zero;
			}
		} else if (other.gameObject.GetComponent<Floor>()) {
			if (other.transform.position.y <= transform.position.y - collider.bounds.size.y / 2 + 0.1) {
				Debug.Log ("inner");
				floor = other;
				velocity = Vector3.zero;
				Vector3 pos = transform.position;
				pos.y = other.transform.position.y + other.collider.bounds.size.y / 2 + collider.bounds.size.y / 2;
				transform.position = pos; 
			}			
 
		} else if (other.gameObject.GetComponent<Zombie>() && godTimer <= 0) {
			hurtTimer = 30;
			godTimer = 90;
			GameMaster.currentHealth--;
			Zombie zombie = other.gameObject.GetComponent<Zombie>();
			if (zombie.isFacePositive) {
				velocity.x = 2.7f;
			} else {
				velocity.x =-2.7f;
			}
//			velocity.x -= 0.7f;
			velocity.y = 1.7f;
		} else if (other.gameObject.GetComponent<Door>()) {
			Debug.Log ("Door");
			Door dr = other.gameObject.GetComponent<Door>();
			if (dr.id == 0) {
				Vector3 pos = transform.position;
				pos.x += 10;
				transform.position = pos;
				GameMaster.currentStage = 2;
			}
			else if (dr.id == 1) {
				Vector3 scene2_pos = new Vector3(-5f, 0, 0);
				transform.position = scene2_pos;
				GameMaster.currentStage = 5;
				GameMaster.prevStage = 5;
				Application.LoadLevel("Scene_2");
			}

		} else if (other.gameObject.GetComponent<BlockWall>()) {
			Debug.Log ("Block Wall");
			velocity.x = 0;
			Vector3 pos = transform.position;
			if (pos.x > other.transform.position.x) {
				pos.x = other.transform.position.x + other.collider.bounds.size.x / 2 + collider.bounds.size.x / 2;	
			} else {
				pos.x = other.transform.position.x - other.collider.bounds.size.x / 2 - collider.bounds.size.x / 2;	
			}
			transform.position = pos; 
		} 

		// xiaofei
		else if (other.gameObject.GetComponent<Death>() && godTimer <= 0) {
			hurtTimer = 30;
			godTimer = 90;
			GameMaster.currentHealth--;
			Death death = other.gameObject.GetComponent<Death>();
			if (death.velocity.x > 0) {
				velocity.x = 2.7f;
			} else {
				velocity.x = -2.7f;
			}
			velocity.y = 1.7f;			
		} else if (other.gameObject.GetComponent<Boss_weapon>() && godTimer <= 0) {
			Boss_weapon boss_weapon = other.gameObject.GetComponent<Boss_weapon>();
			if (boss_weapon.isAbleToHit) {
				hurtTimer = 30;
				godTimer = 90;
				GameMaster.currentHealth--;
				if (transform.position.x < boss_weapon.transform.position.x) {
					velocity.x = -2.7f;
				} else {
					velocity.x = 2.7f;
				}
				velocity.y = 1.7f;				
			}
		} else if (other.gameObject.GetComponent<Marloc>() && godTimer <= 0) {
			hurtTimer = 30;
			godTimer = 90;
			GameMaster.currentHealth--;
			Marloc zombie = other.gameObject.GetComponent<Marloc>();
			if (zombie.isFacePositive) {
				velocity.x = 2.7f;
			} else {
				velocity.x =-2.7f;
			}
			//			velocity.x -= 0.7f;
			velocity.y = 1.7f;
		} else if (other.gameObject.GetComponent<Marloc_weapon>() && godTimer <= 0) {
			hurtTimer = 30;
			godTimer = 90;
			GameMaster.currentHealth--;
			Marloc_weapon zombie = other.gameObject.GetComponent<Marloc_weapon>();
			if (zombie.velocity.x >= 0) {
				velocity.x = 2.7f;
			} else {
				velocity.x =-2.7f;
			}
			//			velocity.x -= 0.7f;
			velocity.y = 1.7f;
		} else if (other.gameObject.GetComponent<Bat>() && godTimer <= 0) {
			hurtTimer = 30;
			godTimer = 90;
			GameMaster.currentHealth--;
			Bat zombie = other.gameObject.GetComponent<Bat>();
			if (zombie.velocity.x >= 0) {
				velocity.x = 2.7f;
			} else {
				velocity.x =-2.7f;
			}
			//			velocity.x -= 0.7f;
			velocity.y = 1.7f;
		}

		// transfer map
		else if (other.gameObject.GetComponent<TransferBlock>()) {
			Debug.Log ("TransferBlock");
			TransferBlock tb = other.gameObject.GetComponent<TransferBlock>();
			if (tb.id == 0 && Input.GetKey(KeyCode.DownArrow)) {
				Vector3 pos = transform.position;
				if (Mathf.Abs (pos.x - tb.transform.position.x) <= 0.1f) {
					pos.y -= 1;
					transform.position = pos;
					GameMaster.currentMapID = 1;
					GameMaster.currentStage = 4;
					GameMaster.prevStage = 4;
					onStair = true;
				}
			}
			else if (tb.id == 1 && Input.GetKey(KeyCode.UpArrow) ) {
				Vector3 pos = transform.position;
				pos.y += 2.5f;
				transform.position = pos;
				GameMaster.currentMapID = 0;
				GameMaster.prevMapID = 1;
				GameMaster.currentStage = 3;
				GameMaster.prevStage = 4;
				
			}
			else if (tb.id == 2 && Input.GetKey(KeyCode.UpArrow)) {
				Vector3 pos = transform.position;
				pos.y += 2.5f;
				transform.position = pos;
				GameMaster.currentMapID = 0;
				GameMaster.prevMapID = 1;
				GameMaster.currentStage = 3;
				GameMaster.prevStage = 4;
				
			}
			else if (tb.id == 3 && Input.GetKey(KeyCode.DownArrow)) {
				Vector3 pos = transform.position;
				if (Mathf.Abs (pos.x - tb.transform.position.x) <= 0.1f) {
					pos.y -= 1;
					transform.position = pos;
					GameMaster.currentMapID = 1;
					onStair = true;
					GameMaster.currentStage = 4;
					GameMaster.prevStage = 4;
					
				}
			}
			velocity = Vector3.zero;
		}

		// pool
		else if (other.gameObject.GetComponent<Pool>()) {
			GameMaster.currentLife--;
			GameMaster.currentHealth = 10;
			Vector3 pos = Vector3.zero;
			pos.x = 65;
			pos.y = -3;
			pos.z = -1.09f;
			onStair = true;
			transform.position = pos;
		}

		// stage trigger
		else if (other.gameObject.GetComponent<StageTrigger>()) {
			Debug.Log ("StageTrigger");
			GameMaster.prevStage = GameMaster.currentStage;
			GameMaster.currentStage = other.gameObject.GetComponent<StageTrigger>().id;
		}

		Debug.Log (other.gameObject);
	}
	
	void OnTriggerStay(Collider other) {
		OnTriggerEnter(other);
	}
	
	void OnTriggerExit(Collider other) {
		if (other.gameObject.GetComponent<Stair>()) {
			stair = null;
			onStair = false;
		} else if (other.gameObject.GetComponent<Floor>()) {
			floor = null;
//			velocity.x = 0;
		}
	}
}
