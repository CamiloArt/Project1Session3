using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour {
	// array for the players
	public Player[] players;
	//scriot for the current player in the turn
	public Player currentPlayer;
	public int currentPlayerIndex;
	public int playerInRangeIndex;
	//time before each turn
	public float timeIntro;
	public float prevTime;
	public CombatEngine combatEngine;
	//time Variables
	[Header("Set time for each turn")]
	//time limit for each turn
	public float timeLimit;
	public float timeCounter;
	private float timeMultiplier;
	[Header("Set time for Combat Map")]
	public float combatTime;
	public float combatCounter;
	[Header("Set Speed for the looser player to retreive")]
	public float looserSpeed;
	[Header("")]
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
	public GameObject explosion;
	//Camera Switch
	private bool camSwitch;
	//BattleMap Variables
	public Transform currentPlayerPos;
	public Transform battlePlayerPos;

	public Transform battleMapPoint1;
	public Transform battleMapPoint2;

    private bool playerSelected;
	public bool modelsLoaded;

	public levelLibrary lvlLib;

	void Awake(){
		combatEngine = gameObject.GetComponent<CombatEngine> ();
	}

	// Use this for initialization
	void Start () {
		//initialize the main variables
		timeCounter = timeLimit;
		combatCounter = combatTime;
		roundCounter = 1;
		turnCounter = 1;
		playerTurnNum = 1;
		startTurn = false;
		inBattle = false;
		gameState = "SelectionMenu";
		camSwitch = true;
		battleCamera.SetActive(!camSwitch);
		prevTime = timeIntro;
        playerSelected = false;
		modelsLoaded = false;
	}

	// Update is called once per frame
	void Update () {
		//check state of the game
        if(gameState == "SelectionMenu"){
            if (!playerSelected)
            {
                SelectPlayer(1);
                playerSelected = true;
            }
        }
		else if(gameState == "strategyMap"){//if the game is in the stategy map
            // animation showing the turn and the player
			if(!modelsLoaded){
				for (int i = 0; i < players.Length; i ++){
					players [i].playerUnit.LoadModels ();
				}
				modelsLoaded = true;
			}
            if(playerTurnNum > players.Length){
                StartNewRound ();
            }
			if(!startTurn){
				ShowRoundIntro ();
			}
			else{
				//after the animation is done, it starts the player turn
				StartPayerTurn ();
			}
		}else if(gameState == "battlemap"){//if the game is in battle mode
			if (!inBattle) {
				ShowCombatIntro();
				//animation before the battle starts
			} else {
				StartBattle ();
			}
			//switch camera and start battl
		}else if(gameState == "DamagingLeader"){
			DamagingLeader ();
		}else if(gameState == "showingCombatResults"){
			ShowCombatResults ();
		}else if(gameState == "afterCombat"){
			EndBattle ();
		}

	}
    public void endSelection(){
        playerSelected = false;
        playerTurnNum++;
    }
	void ShowRoundIntro(){
        SelectPlayer(2);
		//ui intro to show player number and beggining of the turn
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
		if(currentPlayer.myController.pressingTime){
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
			playerInRangeIndex = currentPlayer.playerInRange;
			currentPlayerPos.position = players[currentPlayerIndex].gameObject.transform.position;
			currentPlayerPos.rotation = players[currentPlayerIndex].gameObject.transform.rotation;
			battlePlayerPos.position = players[playerInRangeIndex].gameObject.transform.position;
			battlePlayerPos.rotation = players[playerInRangeIndex].gameObject.transform.rotation;

			players[currentPlayerIndex].transform.position = battleMapPoint1.position;
			players[currentPlayerIndex].gameObject.transform.rotation = battleMapPoint1.rotation;
			players[playerInRangeIndex].gameObject.transform.position = battleMapPoint2.position;
			players[playerInRangeIndex].gameObject.transform.rotation = battleMapPoint2.rotation;
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
	void ShowCombatIntro(){
		prevTime -= Time.deltaTime;
		if (prevTime <= 0) {
			inBattle = true;
			prevTime = timeIntro;
			combatEngine.SetPlayers ();
		}
	}
	public void StartBattle(){
		combatCounter -= Time.deltaTime;
		if (combatCounter <= 0 || currentPlayer.playerUnit.health.currentHp <= 0 || players [currentPlayer.playerInRange].playerUnit.health.currentHp <= 0) {
			combatEngine.SetWinner ();
			gameState = "showingCombatResults";
		}
	}
	void ShowCombatResults (){
		prevTime -= Time.deltaTime;
		if (prevTime <= 0) {
			prevTime = timeIntro;
			players [currentPlayerIndex].transform.position = currentPlayerPos.position;
			players [currentPlayerIndex].gameObject.transform.rotation = currentPlayerPos.rotation;
			players [playerInRangeIndex].gameObject.transform.position = battlePlayerPos.position;
			players [playerInRangeIndex].gameObject.transform.rotation = battlePlayerPos.rotation;
			SwitchCameras ();
			inBattle = false;
			gameState = "afterCombat";
		}
	}
	void EndBattle(){
		//We need animation of the looser going back before switch turns!
		CharacterController looserController;
		Vector3 moveDirection = Vector3.zero;
		if(!combatEngine.playerDied){
			if (combatEngine.draw) {
				looserController = players [currentPlayerIndex].gameObject.GetComponent<CharacterController> ();
				moveDirection = players [currentPlayerIndex].gameObject.transform.position - players [playerInRangeIndex].gameObject.transform.position;
				moveDirection = moveDirection.normalized;
				looserController.Move (moveDirection * Time.deltaTime * looserSpeed);
				looserController = players [playerInRangeIndex].gameObject.GetComponent<CharacterController> ();
				moveDirection = players [playerInRangeIndex].gameObject.transform.position - players [currentPlayerIndex].gameObject.transform.position;
				moveDirection = moveDirection.normalized;
				looserController.Move (moveDirection * Time.deltaTime * looserSpeed);


			} else {
				looserController = players [combatEngine.looserIndex].gameObject.GetComponent<CharacterController> ();
				moveDirection = players [combatEngine.looserIndex].gameObject.transform.position - players [combatEngine.winnerIndex].gameObject.transform.position;
				moveDirection = moveDirection.normalized;
				looserController.Move (moveDirection * Time.deltaTime * looserSpeed);
			}
		}
		combatCounter = combatTime;
		prevTime -= Time.deltaTime;
		if (prevTime <= 0) {
			if (!combatEngine.playerDied) {
				if (combatEngine.draw) {
					players [playerInRangeIndex].myLvl.myExperience += combatEngine.player2DamageDealt * lvlLib.damageExperience;
					players [currentPlayerIndex].myLvl.myExperience += combatEngine.player1DamageDealt * lvlLib.damageExperience;
				} else {
					players [combatEngine.looserIndex].myLvl.myExperience += combatEngine.player2DamageDealt * lvlLib.damageExperience;
					players [combatEngine.winnerIndex].myLvl.myExperience += (combatEngine.player1DamageDealt * lvlLib.damageExperience) + lvlLib.winExperience;
				}
			} else {

				players [combatEngine.winnerIndex].myLvl.myExperience += (combatEngine.player1DamageDealt * lvlLib.damageExperience) + lvlLib.killExperience;
			}
			prevTime = timeIntro;
			gameState = "strategyMap";
			EndPlayerTurn ();
		}
	}
	public void DamageLeader( Transform leaderPosition){
		Instantiate (explosion, leaderPosition.position, Quaternion.identity);
		gameState = "DamagingLeader";
		playerInRangeIndex = currentPlayer.playerInRange;
		players [playerInRangeIndex].playerUnit.health.ReceiveDamage (currentPlayer.playerUnit.damage);
	}
	public void DamagingLeader(){
		prevTime -= Time.deltaTime;
		if (prevTime <= 0) {
			prevTime = timeIntro;
			gameState = "strategyMap";
			EndPlayerTurn ();
		}
	}
    void SelectPlayer(int a){
        for (int i = 0; i < players.Length; i ++){
            if (a == 1)
            {
                if (players[i].playerNumber == playerTurnNum)
                {
                    currentPlayer = players[i];
                    currentPlayerIndex = i;
                }
            }
            if (a == 2)
            {
                if (players[i].playerTurn == playerTurnNum)
                {
                    currentPlayer = players[i];
                    currentPlayerIndex = i;
                }
            }
        }
    }
}
