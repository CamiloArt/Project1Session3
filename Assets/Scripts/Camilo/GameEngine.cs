using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour {
	// array for the players
	public Player[] players;
	//scriot for the current player in the turn
	public Player currentPlayer;
	//time before each turn
	public float timeIntro;
	public float prevTime;
	//time limit for each turn
	public float timeLimit;
	//time Variables
	[Header("Set time for each turn")]
	public float timeCounter;
	private float timeMultiplier;
	//Round counter
	public int roundCounter;
	//TurnsCounter
	public int turnCounter;
	//Bool used to know if put or not the animation before each turn
	public bool startTurn;
	public bool inBattle;
	//Set the number of turns required for have a turf
	[Header("!important to set!")]
	public int turnsToCapture;
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
		roundCounter = 1;
		turnCounter = 1;
		playerTurnNum = 1;
		startTurn = false;
		inBattle = false;
		gameState = "strategyMap";
		camSwitch = true;
		battleCamera.SetActive(!camSwitch);
		prevTime = timeIntro;
	}
	
	// Update is called once per frame
	void Update () {
		//check state of the game

		if(playerTurnNum > players.Length){
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
			if (!inBattle) {
				//animation before the battle starts
			} else {
				StartBattle ();
			}
			//switch camera and start battl
		}else if(gameState == "DamagingLeader"){
			
		}

	}
	void ShowRoundIntro(){
		//ui intro to show player number and beggining of the turn
		for (int i = 0; i < players.Length; i ++){
			if (players [i].playerTurn == playerTurnNum) {
				currentPlayer = players [i];
			}
		}
		prevTime -= Time.deltaTime;
		if (prevTime <= 0) {
			startTurn = true;
			prevTime = timeIntro;
		}
	}
	void StartPayerTurn(){
		timeMultiplier = 1f;
		//select script  of the player that is in the turn

		if (timeCounter == timeLimit) {
			currentPlayer.playerUnit.fuel.currentFuel = currentPlayer.playerUnit.fuel.maxFuel;
		}
		if(Input.GetKey(KeyCode.G)){
			timeMultiplier = 3;
		}
			
		//timer decreasing during the turn
		timeCounter -= Time.deltaTime * timeMultiplier;

		//space to create the function when two players encounter
		if(currentPlayer.typeOfPlayer == Player.playerType.Guard){
		currentPlayer.CheckEnemies();
		}
		//finish the turn if the counter equals 0 or the unit run out of gas
		if (currentPlayer.enemyInRange) {
			gameState = "battlemap";
			SwitchCameras ();
		} else if (timeCounter <= 0 || currentPlayer.playerUnit.fuel.currentFuel <= 0) {
			EndPlayerTurn ();
		}
	}
	void EndPlayerTurn(){
		//set the next number for the turn and put the animation before the turns beging
		playerTurnNum++;
		timeCounter = timeLimit;
		startTurn = false;
		turnCounter++;
	}
	void SwitchCameras(){
		camSwitch = !camSwitch;
		mapCamera.SetActive (camSwitch);
		battleCamera.SetActive(!camSwitch);
	}
	void StartNewRound (){
		roundCounter++;
		playerTurnNum = 1;
	}
	public void StartBattle(){
		
	}
	public void DamageLeader( Transform leaderPosition){
		//instantiate an explosion on the leader position
		gameState = "DamagingLeader";
	}
}
