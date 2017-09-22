using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {
	
	public PlayerInputs pi;
	public CharacterController cc;
	public Transform target;


	public float speed;
	public float gravity = 5.0f;
	public float min_speed;
	public float max_speed;
	public float turningSpeed = 20.0f;

	public Vector3 direction;
	public Vector3 lastDirection;


	void Awake(){

		//Character controller is cc
		cc = this.GetComponent<CharacterController>();
	
	}


	// Update is called once per frame
	void Update () {

		//direction is rotation and direction at a certain speed
		 direction = (transform.rotation * this.pi.direction) * speed;

		//direction is moving at a set time
		direction *= Time.deltaTime;

		//Speed of the step(how you turn) will be speed of your movement by the turningspeed
		float step = speed * Time.deltaTime * turningSpeed;

		//Ths is the rotation of your vehicle
		transform.rotation = Quaternion.RotateTowards (transform.rotation, target.rotation, step);

		//You're falling! Awwwwwwwww!
		if (cc.isGrounded == false) 
		{
			direction.y -= gravity * Time.deltaTime;
			this.pi.direction = Vector3.forward;

		}


		if (Mathf.Abs(direction.z) > 0.4 || Mathf.Abs(direction.x) > 0.4) {
			lastDirection = direction;
			lastDirection.y = 0;
			lastDirection = lastDirection.normalized;
		}
		//clamps the speed between min speed and max speed
		speed = Mathf.Clamp (speed, min_speed, max_speed);

		//It can move!
		this.cc.Move (direction);



}
}

