using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public Vector3 velocity;
	// Use this for initialization
	void Start () {
		
	}

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Update is called once per frame
	void Update () {
		transform.position += velocity * Time.deltaTime;
	}
}
