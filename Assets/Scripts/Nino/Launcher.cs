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
		float x2 = Input.GetAxis ("Horizontal2");
		float y2 = Input.GetAxis ("Vertical2");
		//discovering the angle
		float angle = Mathf.Atan2 (x2, y2);
		//using the angle to move
		transform.rotation = Quaternion.EulerAngles (0, angle, 0);
		//the directions which the launcher will move towards

		shooting = false;

		if (Input.GetAxis ("Horizontal2") > 0.2)
		{
			shooting = true;
		}
		if (Input.GetAxis ("Horizontal2") < -0.2)
		{
			shooting = true; 
		}
		if (Input.GetAxis ("Vertical2") > 0.2) 
		{
			shooting = true;
		}
		if (Input.GetAxis ("Vertical2") < -0.2)
		{
			shooting = true;

	}
		if (shooting == true) 
		{
			Instantiate (rocketPrefab, this.transform.position, this.transform.rotation); 
		}


		//the rotation of the launcher
		Vector3 NextDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		if (NextDir != Vector3.zero)
			transform.rotation = Quaternion.LookRotation(NextDir);
}
}


