using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//basic input for the camera (if we need it)
	/*public KeyCode forward;
	public KeyCode backward;
	public KeyCode left;
	public KeyCode right;
	public KeyCode lookforward;
	public KeyCode lookbackward;
	public KeyCode lookleft;
	public KeyCode lookright;
	public KeyCode action1;
	public KeyCode action2;
	public KeyCode select;
	public KeyCode back;*/
	public Player myPlayer;
	public float playerSpeed;

	private CharacterController playerCc;
	private Vector3 direction;

	// Use this for initialization

	void Start () {
		playerCc = this.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (myPlayer.gameEngine.gameState == "strategyMap") {
			MovePlayerMainMap ();
		}
	}

	void MovePlayerMainMap(){
		this.direction = Vector3.zero;
		if (Input.GetAxis ("Horizontal") > 0.2 || Input.GetAxis ("Horizontal") < 0.2) {
			this.direction += new Vector3 (Input.GetAxis ("Horizontal"),0f,0f);
			ApplyMovement ();
			}
		if (Input.GetAxis ("Vertical") > 0.2 || Input.GetAxis ("Vertical") < 0.2) {
			this.direction += new Vector3 (0f,0f,Input.GetAxis ("Vertical"));
			ApplyMovement ();
		}
	}

	void ApplyMovement(){
		//playerCc.Move (direction * playerSpeed * Time.deltaTime);
		myPlayer.playerUnit.fuel.currentFuel -= myPlayer.playerUnit.fuel.fuelConsumption * Time.deltaTime;
	}
}
