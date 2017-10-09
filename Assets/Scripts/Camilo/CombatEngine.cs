using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEngine : MonoBehaviour {

	private GameEngine gameEngine;
	private float player1StartHp;
	private float player2StartHp;
	public float player1DamageDealt;
	public float player2DamageDealt;
	public int winnerIndex;
	public int looserIndex;
	public bool draw;
	public bool playerDied;
	// Use this for initialization
	void Awake () {
		gameEngine = gameObject.GetComponent<GameEngine> ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void SetPlayers(){
		player1StartHp = gameEngine.currentPlayer.playerUnit.health.currentHp;
		player2StartHp = gameEngine.players [gameEngine.playerInRangeIndex].playerUnit.health.currentHp;
		draw = false;
		playerDied = false;
	}
	public void SetWinner(){
		player1DamageDealt = player2StartHp - gameEngine.players [gameEngine.playerInRangeIndex].playerUnit.health.currentHp;
		player2DamageDealt = player1StartHp -  gameEngine.currentPlayer.playerUnit.health.currentHp;
		if (gameEngine.currentPlayer.playerUnit.health.currentHp <= 0) {
			winnerIndex = gameEngine.playerInRangeIndex;
			looserIndex = gameEngine.currentPlayerIndex;
			playerDied = true;
		}else if(gameEngine.players[gameEngine.playerInRangeIndex].playerUnit.health.currentHp <= 0){
			winnerIndex = gameEngine.currentPlayerIndex;
			looserIndex = gameEngine.playerInRangeIndex;
			playerDied = true;
		}else if (player1DamageDealt > player2DamageDealt) {
			winnerIndex = gameEngine.currentPlayerIndex;
			looserIndex = gameEngine.playerInRangeIndex;
		} else if (player2DamageDealt > player1DamageDealt) {
			winnerIndex = gameEngine.currentPlayer.playerInRange;
			looserIndex = gameEngine.currentPlayerIndex;
		} else if (player1DamageDealt == player2DamageDealt) {
			draw = true;
		}
	}
}
