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
	public Text combatTimer;
	public Image arrow;
	public Camera strategyCamera;
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
		combatTimer.text = "";
		if (gameEngine.currentPlayer) {
			if (gameEngine.gameState == "strategyMap") {
				arrow.enabled = true;
				arrow.transform.position = strategyCamera.WorldToScreenPoint (gameEngine.currentPlayer.gameObject.transform.position);
				redTeamScore.text = gameScore.RedTeamTurfs.ToString ();
				blueTeamScore.text = gameScore.blueTeamTurfs.ToString ();
				if (gameEngine.startTurn)
					ShowInTurnCounter ();
				else
					ShowPrevCounter ();
			} else if (gameEngine.gameState == "battlemap") {
				arrow.enabled = false;
				if (gameEngine.inBattle)
					showInBattleCounter ();
				else
					ShowPrevCounter ();
			}else if(gameEngine.gameState == "showingCombatResults"){
				showCombatResults ();
			}
		}

	}
	void ShowInTurnCounter(){
		timer.text = Mathf.Round (gameEngine.timeCounter).ToString ();
		if (gameEngine.currentPlayer) {
			fuel.text = Mathf.Round (gameEngine.currentPlayer.playerUnit.fuel.currentFuel).ToString ();
		}
	}
	void ShowPrevCounter(){
		PrevCounter.text = gameEngine.currentPlayer.playerTeam.teamColor.ToString() +" Team" +"\n"+"Player:"+ gameEngine.currentPlayer.playerNumber.ToString() + "\n" + Mathf.Round (gameEngine.prevTime).ToString ();
		if(gameEngine.prevTime <= 1){
			PrevCounter.text = "GO!";
		}
	}
	void showInBattleCounter(){
		combatTimer.text = Mathf.Round (gameEngine.combatCounter).ToString ();
	}
	void showCombatResults(){
		if (gameEngine.combatEngine.draw) {
			PrevCounter.text = "DRAW!" + "\n" + "Both players did the same ammount of damage";
		}
		else {
			PrevCounter.text = "the winner is" + gameEngine.players [gameEngine.combatEngine.winnerIndex].playerNumber + "\n" + "from the team: " + gameEngine.players [gameEngine.combatEngine.winnerIndex].playerTeam.teamColor.ToString ();
		}
	}
}