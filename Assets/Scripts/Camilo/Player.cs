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

	public enum playerType{
		Leader,
		Guard
	}
	public playerType typeOfPlayer;
	public GameEngine gameEngine;
	// Use this for initialization
	void Awake () {
		gameEngine = GameObject.FindGameObjectWithTag ("GameEngine").GetComponent<GameEngine> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameEngine.gameState == "strategyMap")
		if (!playerUnit.isAlive) {
			Respawn ();
		}
	}

	void Respawn(){
		this.gameObject.transform.Translate (respawnPosition.position);
	}
}
