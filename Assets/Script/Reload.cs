using UnityEngine;
using System.Collections;

public class Reload : MonoBehaviour {
	private int timer;
	// Use this for initialization
	void Start () {
		timer = 300;
	}
	
	// Update is called once per frame
	void Update () {
		timer--;
//		Debug.Log (timer);
//		if (timer <= 0) {
//			Application.LoadLevel("Scene_1");
//		}
	}	
}
