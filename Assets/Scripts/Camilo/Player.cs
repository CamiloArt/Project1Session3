using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//player variables
	public int playerNumber;
	public Unit playerUnit;
	public int playerTurn;
	public Team playerTeam;
	public Transform respawnPosition;
	public bool enemyInRange;
	public int playerInRange;
	public bool inBattle;
	public PlayerController myController;
	public levelMannager myLvl;

	public enum playerType{
		Leader,
		Guard
	}
	public playerType typeOfPlayer;
	private GameEngine gameEngine;
	// Use this for initialization
	void Awake () {
		myController = gameObject.GetComponent<PlayerController>();
		myLvl = gameObject.GetComponent<levelMannager> ();
		gameEngine = GameObject.FindGameObjectWithTag ("GameEngine").GetComponent<GameEngine> ();
		inBattle = false;
	}
	
	// Update is called once per frame
	void Update () {
		enemyInRange = false;
		if(gameEngine.gameState == "strategyMap")
		if (!playerUnit.isAlive) {
			Respawn ();
		}
	}

	void Respawn(){
		playerUnit.isAlive = true;
		playerUnit.health.currentHp = playerUnit.health.initialHp;
		gameObject.transform.position = respawnPosition.position;
		myLvl.myExperience = 0;
	}
	public void CheckEnemies(){
		for (int i = 0; i < gameEngine.players.Length; i++) {
			float distance;
			if (gameEngine.players [i].playerTeam.teamColor.ToString() != playerTeam.teamColor.ToString()){
				distance = Vector3.Distance (gameEngine.players[i].gameObject.transform.position, gameObject.transform.position);
				if (gameEngine.players [i].typeOfPlayer == playerType.Leader &&  distance < playerUnit.range.range) {
					//make damage to the leader
					playerInRange = i;
					gameEngine.DamageLeader(gameEngine.players [i].gameObject.transform);
					Debug.Log (i.ToString ());
					i = gameEngine.players.Length + 1;
				}
				else if (distance < playerUnit.range.range || distance < gameEngine.players[i].playerUnit.range.range) {
					enemyInRange = true;
					inBattle = true;
					playerInRange = i;
					gameEngine.players [i].inBattle = true;
					i = gameEngine.players.Length + 1;
				}
			}
		}
	}
}
