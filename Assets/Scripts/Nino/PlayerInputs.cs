using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour {
	//Your direction. Simple.
	public Vector3 direction;
	public Player2 pl;
	public bool pressing;
	public float speedDampener = 0.2f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//Your direction, or w
		this.SetDirection ();


	}

	void SetDirection (){

		//You aren't moving
		this.direction = Vector3.zero;


		//sets pressing as false
		pressing = false;

		//if you are applying pressure on the joystick sufficiently to move, pressing is true
		if (Input.GetAxis ("Horizontal") > 0.2)
		{
			pressing = true;
		}

		if (Input.GetAxis ("Horizontal") < -0.2)
		{
			pressing = true;
		}
		if (Input.GetAxis ("Vertical") > 0.2) 
		{
			pressing = true;
		}
		if (Input.GetAxis ("Vertical") < -0.2)
		{
			pressing = true;
		}

		if (Input.GetAxis ("Left_Trigger") > 0.2) {
			Debug.Log ("Pressed");
			pl.max_speed = 50.0f;
			pl.speed = 50.0f;
		} else 
		{
			pl.max_speed = 20.0f;
		}
		//if you are pressing, speed will increase, otherwise it will decrease
		if (pressing == true)
			pl.speed += 0.5f;
		else
			pl.speed -= speedDampener;

		//if speed is greater than 0, it will move forward
		if (pl.speed > 0)
			this.direction = Vector3.forward;
		

		//the direction is normalized so that any movement is 1
		this.direction = this.direction.normalized;
	
	}




}

