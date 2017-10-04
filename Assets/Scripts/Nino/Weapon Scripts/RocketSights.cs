using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSights : MonoBehaviour {

	public string enemyName;
	public bool locked;
	public float timer;

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == enemyName)
			Debug.Log ("Target Locked");
		locked = true;
		timer = 3.0f;
	}
	void OnTriggerExit (Collider other){

		timer-=1;
		if (timer <= 0)
			locked = false;
		
	}


}
