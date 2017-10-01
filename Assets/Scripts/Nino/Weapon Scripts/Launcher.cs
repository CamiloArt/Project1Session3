using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {

	//Setting up a place to put our Rocket Prefab
	//rocket prefab
	public GameObject rocketPrefab;
	//speed
	public float speed = 2.0f;

	public bool shooting;

	void Update () {
		//the inputs 
		float x2 = Input.GetAxis ("BluePlayerHorizontal2");
		float y2 = Input.GetAxis ("BluePlayerVertical2");
		//discovering the angle
		float angle = Mathf.Atan2 (x2, y2);
		//using the angle to move
		transform.rotation = Quaternion.EulerAngles (0, angle, 0);
		//the directions which the launcher will move towards

		shooting = false;

		if (Input.GetAxis ("BluePlayerHorizontal2") > 0.2)
		{
			shooting = true;
		}
		if (Input.GetAxis ("BluePlayerHorizontal2") < -0.2)
		{
			shooting = true; 
		}
		if (Input.GetAxis ("BluePlayerVertical2") > 0.2) 
		{
			shooting = true;
		}
		if (Input.GetAxis ("BluePlayerVertical2") < -0.2)
		{
			shooting = true;

	}
		if (shooting == true) 
		{
			Instantiate (rocketPrefab, this.transform.position, this.transform.rotation); 
		}


		//the rotation of the launcher
		Vector3 NextDir = new Vector3(Input.GetAxisRaw("BluePlayerHorizontal"), 0, Input.GetAxisRaw("BluePlayerVertical"));
		if (NextDir != Vector3.zero)
			transform.rotation = Quaternion.LookRotation(NextDir);
}
}


