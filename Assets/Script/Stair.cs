using UnityEngine;
using System.Collections;

public class Stair : MonoBehaviour {

	public float slope;
	public Vector3 bottom = Vector3.zero;
	public Vector3 top = Vector3.zero;

	// Use this for initialization
	void Start () {
		if (slope > 0) {
			top.x = transform.position.x + collider.bounds.size.x / 2;
			bottom.x = transform.position.x - collider.bounds.size.x / 2;
		} else {
			top.x = transform.position.x - collider.bounds.size.x / 2;
			bottom.x = transform.position.x + collider.bounds.size.x / 2;
		}
		top.y = transform.position.y + collider.bounds.size.y / 2;
		bottom.y = transform.position.y - collider.bounds.size.y / 2;
		bottom.z = transform.position.z;
		top.z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
