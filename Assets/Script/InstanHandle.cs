using UnityEngine;
using System.Collections;

public class InstanHandle : MonoBehaviour {
	public GameObject prefab;
	public Transform tf;
	public int destroyTime;
	public int timer;
	private int currentTimer;
	
	public Vector3 velocity = new Vector3(2f, 0.5f, 0);
	public bool isUp = false;
	
	void Start ()
	{
		currentTimer = timer;
	}
	
	void Update ()
	{
		
		if (currentTimer == 0) {
			currentTimer = timer;		
		}
		
		if (currentTimer == timer) {
			if (prefab.GetComponent<Bat>()) {
				prefab.GetComponent<Bat>().velocity =velocity;
				prefab.GetComponent<Bat>().isUp =isUp;
			}
			GameObject go = Instantiate(prefab, tf.position, tf.rotation) as GameObject;
			
			
			Destroy(go, destroyTime);
			
		}
		currentTimer--;
	}
}
