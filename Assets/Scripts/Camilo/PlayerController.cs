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
	private GameEngine gameEngine;

	public CharacterController playerCc;
	public Vector3 direction;
	public float magnitude;

	// Use this for initialization

	void Start () {
		gameEngine = GameObject.FindGameObjectWithTag ("GameEngine").GetComponent<GameEngine> ();
		playerCc = this.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameEngine.gameState == "strategyMap" && gameEngine.startTurn) {
			if (gameEngine.currentPlayer) {
				myPlayer = gameEngine.currentPlayer;
				playerCc = myPlayer.gameObject.GetComponent<CharacterController> ();
				MovePlayerMainMap ();
			}
		}
	}

	void MovePlayerMainMap(){
		this.direction = Vector3.zero;
		if (Mathf.Abs(Input.GetAxis ("Horizontal")) > 0.1) {
			this.direction += new Vector3 (Input.GetAxis ("Horizontal"),0f,0f);
			ApplyMovement ();
			}
		if (Mathf.Abs(Input.GetAxis ("Vertical")) > 0.1) {
			this.direction += new Vector3 (0f,0f,Input.GetAxis ("Vertical"));
			ApplyMovement ();
		}
	}

	void ApplyMovement(){
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		float angle = Mathf.Atan2 (x, y) * Mathf.Rad2Deg;
		myPlayer.playerUnit.gameObject.transform.rotation = Quaternion.Euler(0, angle, 0);
		direction  = direction * Vector3.Magnitude (direction);
		magnitude =  Vector3.Magnitude (direction);
		playerCc.Move (direction * playerSpeed * Time.deltaTime);
		myPlayer.playerUnit.fuel.currentFuel -= (myPlayer.playerUnit.fuel.fuelConsumption + myPlayer.playerUnit.fuel.terrainValue) * Time.deltaTime * magnitude;
	}
}
