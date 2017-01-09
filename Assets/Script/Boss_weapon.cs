using UnityEngine;
using System.Collections;

public class Boss_weapon : MonoBehaviour {

	private int active_timer = 40;
	public bool isAbleToHit = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		active_timer--;
		if (active_timer <= 0) {
			Destroy(gameObject);
		} else if (active_timer > 0 && active_timer <= 10) {
			isAbleToHit = true;
		}
	}
}
