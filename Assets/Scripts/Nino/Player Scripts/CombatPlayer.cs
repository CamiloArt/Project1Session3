using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlayer : MonoBehaviour {
	public Transform target;

	public CharacterController cc;


	public float speed;
	public float gravity = 5.0f;
	public float min_speed;
	public float max_speed;
	public float turningSpeed = 20.0f;

	public Vector3 direction;
	public Vector3 lastDirection;

	public Vector3 tdirection;
	public bool pressing;
	public float speedDampener = 0.2f;
	public float turboTime;

	public enum Team {

		blue,
		red,
		nbteam,
		invalid
	}

	public Team team = Team.invalid;

	private string horizontalAxis;
	private string verticalAxis;
	private string Trigger;

	void Start () {
		switch (team) {
		case Team.blue:
			horizontalAxis = "BluePlayerHorizontal";
			verticalAxis = "BluePlayerVertical";
			Trigger = "BlueLeftTrigger";
			break;
		case Team.red:
			horizontalAxis = "RedPlayerHorizontal";
			verticalAxis = "RedPlayerVertical";
			Trigger = "RedLeftTrigger";
			break;
		}
	}


	void Awake()
	{
		cc = this.GetComponent<CharacterController>();
	}

	void Update () {
		
		this.SetDirection ();


	direction = (transform.rotation * this.tdirection) * speed;

	direction *= Time.deltaTime;

	float step = speed * Time.deltaTime * turningSpeed;

	transform.rotation = Quaternion.RotateTowards (transform.rotation, target.rotation, step);

	if (cc.isGrounded == false) 
	{
		direction.y -= gravity * Time.deltaTime;
		this.tdirection = Vector3.forward;
	}
	
	speed = Mathf.Clamp (speed, min_speed, max_speed);

	this.cc.Move (direction);

}

	void SetDirection (){

		this.direction = Vector3.zero;


		pressing = false;

		if (Input.GetAxis (horizontalAxis) > 0.2)
		{
			pressing = true;
		}

		if (Input.GetAxis (horizontalAxis) < -0.2)
		{
			pressing = true;
		}
		if (Input.GetAxis (verticalAxis) > 0.2) 
		{
			pressing = true;
		}
		if (Input.GetAxis (verticalAxis) < -0.2)
		{
			pressing = true;
		}

		if (Input.GetAxis (Trigger) > 0.2 && turboTime>0) {
			Debug.Log ("Pressed");
			max_speed = 50.0f;
			speed = 50.0f;
			turboTime--;
		} else 
		{
			max_speed = 20.0f;
		}
		if (pressing == true)
			speed += 0.5f;
		else
			speed -= speedDampener;

		if (speed > 0)
			this.direction = Vector3.forward;


		//the direction is normalized so that any movement is 1
		this.tdirection = this.tdirection.normalized;
}
}