using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSights : MonoBehaviour {

	public string enemyName;
	public bool locked;
	public float timer;
	public bool lockOn;


	void Update(){
		if (lockOn == true)
			timer = 3.0f;
			locked = true;
		if (lockOn == false)
			timer -= 1*Time.deltaTime;
		if (timer <= 0)
			locked = false;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == enemyName)
		lockOn = true;
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == enemyName)
			lockOn = false;
	}
}
