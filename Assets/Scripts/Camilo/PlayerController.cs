using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Player myPlayer;
	private GameEngine gameEngine;
	private PlayerInputs myInput;

	public CharacterController playerCc;
	public Vector3 mapDirection;
	public float magnitude;
	float terrainminDistance;

	//combat variables
	public float gravity;
	public float turningSpeed;

	public Vector3 direction;
	public Vector3 lastDirection;

	public Vector3 tdirection;
	public bool pressing;
	public bool shooting;
	public Vector3 shootingVector;

	public float turboTime;
	private float maxSpeed;
	private Quaternion ankle;

	// Use this for initialization

	void Awake () {
		gameEngine = GameObject.FindGameObjectWithTag ("GameEngine").GetComponent<GameEngine> ();
		playerCc = gameObject.GetComponent<CharacterController> ();
		myPlayer = gameObject.GetComponent<Player> ();
		myInput = gameObject.GetComponent<PlayerInputs> ();
		terrainminDistance = 3f;
	}
	
	// Update is called once per frame
	void Update () {
		shooting = false;
		if (gameEngine.gameState == "strategyMap" && gameEngine.startTurn) {
			if (gameEngine.currentPlayer.playerTurn == myPlayer.playerTurn) {
				myPlayer = gameEngine.currentPlayer;
				playerCc = myPlayer.gameObject.GetComponent<CharacterController> ();
				MovePlayerMainMap ();
			}
		}
		if(gameEngine.gameState == "battlemap" && gameEngine.inBattle && myPlayer.inBattle){
			SetDirection ();
			getShootingAxis ();
		}
	}

	void MovePlayerMainMap(){
		this.mapDirection = Vector3.zero;
		if (Mathf.Abs(Input.GetAxis(myInput.hAxisName)) > 0.2 || Mathf.Abs(Input.GetAxis (myInput.vAxisName)) > 0.2) {
			mapDirection += new Vector3 (Input.GetAxis (myInput.hAxisName),0f,Input.GetAxis (myInput.vAxisName));
			ApplyMovement ();
			}
	}

	void ApplyMovement(){
		float x = Input.GetAxis (myInput.hAxisName);
		float y = Input.GetAxis (myInput.vAxisName);
		float angle = Mathf.Atan2 (x, y) * Mathf.Rad2Deg;
		myPlayer.gameObject.transform.rotation = Quaternion.Euler(0, angle, 0);
		magnitude =  Vector3.Magnitude (mapDirection);
		CheckTerrains ();
		playerCc.Move (mapDirection * (myPlayer.playerUnit.speed.mapSpeed - myPlayer.playerUnit.fuel.terrainValue) * Time.deltaTime);
		myPlayer.playerUnit.fuel.currentFuel -= (myPlayer.playerUnit.fuel.fuelConsumption) * Time.deltaTime * magnitude;
	}
	void SetDirection(){
		direction = Vector3.zero;
		pressing = false;
		if (Mathf.Abs (Input.GetAxis (myInput.hAxisName)) > 0.2 || Mathf.Abs (Input.GetAxis (myInput.vAxisName)) > 0.2) {
			pressing = true;
		}
		if (Input.GetAxis (myInput.trigger) > 0.2 && turboTime > 0) {
			maxSpeed = myPlayer.playerUnit.speed.turboSpeed;
			turboTime--;
		} else {
			maxSpeed = myPlayer.playerUnit.speed.maxSpeed;
		}
		if (pressing) {
			myPlayer.playerUnit.speed.currentSpeed += myPlayer.playerUnit.speed.speedMultiplier;
		} else {
			myPlayer.playerUnit.speed.currentSpeed -= myPlayer.playerUnit.speed.speedDampener;
		}
		tdirection = tdirection.normalized;
		direction = (transform.rotation * tdirection) * myPlayer.playerUnit.speed.currentSpeed * Time.deltaTime;
		if (playerCc.isGrounded == true) {
			//This determined the direction at which you turn based on the left joystick of an Xbox controller
			Vector3 NextDir = new Vector3 (Input.GetAxisRaw (myInput.hAxisName.ToString ()), 0, Input.GetAxisRaw (myInput.vAxisName.ToString ()));
			//if you are moving, your next direction set by the joystick angle you are pressing
			if (NextDir != Vector3.zero) {
				ankle = Quaternion.LookRotation (NextDir);
			}
		} else {
			direction.y -= gravity * Time.deltaTime;
			tdirection = Vector3.forward;
		}
		float step = myPlayer.playerUnit.speed.currentSpeed * Time.deltaTime * turningSpeed;
		gameObject.transform.rotation = Quaternion.RotateTowards (transform.rotation, ankle, step);
		myPlayer.playerUnit.speed.currentSpeed = Mathf.Clamp (myPlayer.playerUnit.speed.currentSpeed, myPlayer.playerUnit.speed.minSpeed, maxSpeed);
		playerCc.Move (direction);
	}
	void getShootingAxis(){
		if (Mathf.Abs (Input.GetAxis (myInput.hAxisName2)) > 0.2 || Mathf.Abs (Input.GetAxis (myInput.vAxisName2)) > 0.2) {
			shooting = true;
			shootingVector = new Vector3 (Input.GetAxisRaw (myInput.hAxisName2), 0, Input.GetAxisRaw (myInput.vAxisName2));
		}
	}
	void CheckTerrains(){
		GameObject[] terrains = GameObject.FindGameObjectsWithTag ("Terrain");
		float distance;
		for (int i = 0; i < terrains.Length; i++) {
			distance = Vector3.Distance (gameObject.transform.position, terrains [i].gameObject.transform.position);
			if (distance < terrainminDistance) {
				myPlayer.playerUnit.fuel.terrainValue = terrains [i].gameObject.GetComponent<mapTerrains> ().terrainValue;
			}
		}
	}
}
