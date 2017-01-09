using UnityEngine;
using System.Collections;

public class Torch : MonoBehaviour {
	public GameObject rewardItem;
	public int rewardValue;
	
	// Use this for initialization
	void Start () {
		Vector3 pos = transform.position;
		pos.y -= 0.4f;
		rewardItem = (GameObject)Instantiate(rewardItem, pos, transform.rotation);	
		rewardItem.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<Weapon>() || other.gameObject.GetComponent<Dagger>()) {
			Dagger dagger = rewardItem.GetComponent<Dagger> ();
			if (dagger) {
				dagger.isFromTorch = true;
			}
			Destroy(this.gameObject);

			if (rewardItem.GetComponent<Heart>()) {
				rewardItem.GetComponent<Heart>().heartValue = rewardValue;
			}
			rewardItem.SetActive(true);	
		}
	}

	void OnTriggerStay(Collider other) {
		OnTriggerEnter (other);
	}
}
