using UnityEngine;
using System.Collections;

public class Follow_Player : MonoBehaviour {

  	private GameObject player;
	private float defaultY;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update()
	{
		if (GameMaster.currentMapID == 0) {
			player = GameObject.Find("Player");
			Vector3 pos = player.transform.position;
			pos.z = -10.0F;
			pos.x = player.transform.position.x;

			if (GameMaster.prevMapID == 0) {
				pos.y = transform.position.y;
				defaultY = transform.position.y;
				transform.position = pos;	
			} else {
				pos.y = defaultY;
				transform.position = pos;
			}
		}
		else if (GameMaster.currentMapID == 1) {
			player = GameObject.Find("Player");
			Vector3 pos = player.transform.position;
			pos.z = -10.0F;
			pos.x = player.transform.position.x;
			
			pos.y = defaultY - 6.2f;
			transform.position = pos;
		}
	}
}
