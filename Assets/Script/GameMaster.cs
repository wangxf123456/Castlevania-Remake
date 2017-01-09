using UnityEngine;
using System.Collections;


public class GameMaster : MonoBehaviour {
	public static int currentScore = 0;
	public static int currentTime = 50000;
	public static int currentStage = 1;
	public static float currentHealth = 10;
	public static float enemyHealth;
	public static float currentHeart = 5;
	public static float currentLife = 3;
	public static string currentWeapon = "None";
	

	public static Vector3 posBegin1;
	public static Vector3 posBegin2;
	public static Vector3 posBegin3;
	public static Vector3 posBegin4;
	public static Vector3 posBegin5;
	public static Vector3 posBegin6;
	
	public static float currentMapID = 0;
	public static float prevMapID = 0;
	public static float prevLife = 3;
	public static float prevStage = 2;
	
	bool showBox = true;
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		posBegin1 = new Vector3 (-11, 1, -1.09f);
		posBegin2 = new Vector3 (18.3f, 1, -1.09f);
		posBegin3 = new Vector3 (63.8f, 2.75f, -1.09f);
		posBegin4 = new Vector3 (65, -3, -1.09f);
		posBegin5 = new Vector3 (-4.997f, 0.7946f, 0);
		posBegin6 = new Vector3 (-4.4f, -0.84f, 0);
		
	}
	
	// Update is called once per frame
	void Update () {
		currentTime--;

		switch (GameMaster.currentStage) {
		case 1: 
			//GameObject z = Instantiate(Zombie, posBegin1, );
			break;
//		case 2: 
//			transform.position = GameMaster.posBegin2;
//			break;
//		case 3: 
//			transform.position = GameMaster.posBegin3;
//			break;
//		case 4: 
//			transform.position = GameMaster.posBegin4;
//			break;
//		case 5: 
//			transform.position = GameMaster.posBegin5;
//			break;
//		case 6: 
//			transform.position = GameMaster.posBegin6;
			break;
		}


	}
	
	void OnGUI() {
		string content = "SCORE: " + currentScore + "    TIME: " + (currentTime / 100) + "     STAGE: " + currentStage + "\n";
		content += "HEART: " + currentHeart + "     WEAPON: " + currentWeapon + "    LIFE: " + currentLife + "\n";
		content += "PLAYER HEALTH: " + currentHealth + "    ENEMY HEALTH: " + enemyHealth + "\n";
		GUI.Box (new Rect(0, 0, Screen.width, 95), content);		
	}

}
