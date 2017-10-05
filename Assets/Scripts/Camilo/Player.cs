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
	public Player playerinRange;
	public bool inBattle;

	public enum playerType{
		Leader,
		Guard
	}
	public playerType typeOfPlayer;
	public GameEngine gameEngine;
	// Use this for initialization
	void Awake () {
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
		this.gameObject.transform.Translate (respawnPosition.position);
	}
	public void CheckEnemies(){
		for (int i = 0; i < gameEngine.players.Length; i++) {
			float distance;
			if (gameEngine.players [i].playerTeam.teamColor.ToString() != playerTeam.teamColor.ToString()){
				distance = Vector3.Distance (gameEngine.players[i].gameObject.transform.position, gameObject.transform.position);
				if (gameEngine.players [i].typeOfPlayer == playerType.Leader &&  distance < playerUnit.range.range) {
					//make damage to the leader
					gameEngine.DamageLeader(gameEngine.players [i].gameObject.transform);
				}
				else if (distance < playerUnit.range.range || distance < gameEngine.players[i].playerUnit.range.range) {
					enemyInRange = true;
					inBattle = true;
					playerinRange = gameEngine.players [i];
					gameEngine.players [i].inBattle = true;
				}
			}
		}
	}
}
