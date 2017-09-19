using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour {
	// array for the players
	public Player[] players;
	//scriot for the current player in the turn
	public Player currentPlayer;
	//time limit for each turn
	public float timeLimit;
	//time counter
	public float timeCounter;
	//Round counter
	public int RoundCounter;
	//Bool used to know if put or not the animation before each turn
	bool startTurn;
	//Holds the turn number in order to know which player goes next
	public int playerTurnNum;
	//Defines state of the game
	public string gameState;
	//MainMapCamera
	public GameObject mapCamera;
	//Battle map cameras
	public GameObject battleCamera;
	//Camera Switch
	private bool camSwitch;
	// Use this for initialization
	void Start () {
		//initialize the main variables
		timeCounter = timeLimit;
		RoundCounter = 1;
		playerTurnNum = 1;
		startTurn = false;
		gameState = "strategyMap";
		camSwitch = true;
		battleCamera.SetActive(!camSwitch);
	}
	
	// Update is called once per frame
	void Update () {
		//check state of the game

		if(playerTurnNum > 10){
			StartNewRound ();
		}
		if(gameState == "strategyMap"){//if the game is in the stategy map
			// animation showing the turn and the player
			if(!startTurn){
			ShowRoundIntro ();
			}
			else{
				//after the animation is done, it starts the player turn
				StartPayerTurn ();
			}
		}else if(gameState == "battlemap"){//if the game is in battle mode
			
		}

		if (Input.GetKeyDown (KeyCode.C)) {
			SwitchCameras ();
		}

	}
	void ShowRoundIntro(){
		//ui intro to show player number and beggining of the turn
		startTurn = true;
	}
	void StartPayerTurn(){
		//select script  of the player that is in the turn
		for (int i = 0; i < players.Length; i ++){
			if (players [i].playerTurn == playerTurnNum)
				currentPlayer = players [i];
		}
		//timer decreasing during the turn
		timeCounter -= Time.deltaTime;

		//space to create the function when two players encounter

		//finish the turn if the counter equals 0 or the unit run out of gas
		if (timeCounter <= 0 /*|| currentPlayer.playerUnit.fuel <= 0*/)
			EndPlayerTurn ();
		Debug.Log (currentPlayer.playerNumber);
		Debug.Log (timeCounter);
	}
	void EndPlayerTurn(){
		//set the next number for the turn and put the animation before the turns beging
		playerTurnNum++;
		timeCounter = timeLimit;
		startTurn = false;
	}
	void SwitchCameras(){
		camSwitch = !camSwitch;
		mapCamera.SetActive (camSwitch);
		battleCamera.SetActive(!camSwitch);
	}
	void StartNewRound (){
		RoundCounter++;
		playerTurnNum = 1;
	}
}
