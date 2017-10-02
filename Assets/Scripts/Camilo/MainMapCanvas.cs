using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class MainMapCanvas : MonoBehaviour {
	public Text timer;
	public Text fuel;
	public Text PrevCounter;
	public Text redTeamScore;
	public Text blueTeamScore;
	private GameEngine gameEngine;
	private Score gameScore;
	// Use this for initialization
	void Awake () {
		gameEngine = GameObject.FindGameObjectWithTag ("GameEngine").GetComponent<GameEngine> ();
		gameScore = gameObject.GetComponent<Score> ();
	}
	
	// Update is called once per frame
	void Update () {
		redTeamScore.text = "";
		blueTeamScore.text = "";
		timer.text = "";
		fuel.text = "";
		PrevCounter.text = "";
		if (gameEngine.gameState == "strategyMap") {
			redTeamScore.text = gameScore.RedTeamTurfs.ToString();
			blueTeamScore.text = gameScore.blueTeamTurfs.ToString();
			if (gameEngine.startTurn)
				showInTurnCounter ();
			else
				showPrevCounter ();
		}

	}
	void showInTurnCounter(){
		timer.text = Mathf.Round (gameEngine.timeCounter).ToString ();
		if (gameEngine.currentPlayer) {
			fuel.text = Mathf.Round (gameEngine.currentPlayer.playerUnit.fuel.currentFuel).ToString ();
		}
	}
	void showPrevCounter(){
		PrevCounter.text = gameEngine.currentPlayer.playerTeam.teamColor.ToString() +" Team" +"\n"+"Player:"+ gameEngine.currentPlayer.playerNumber.ToString() + "\n" + Mathf.Round (gameEngine.prevTime).ToString ();
		if(gameEngine.prevTime <= 1){
			PrevCounter.text = "GO!";
		}
	}
}
