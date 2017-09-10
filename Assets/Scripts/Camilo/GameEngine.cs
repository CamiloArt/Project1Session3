using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour {
	// array for the players
	public Player[] players;
	private int counter;
	private int RoundCounter;
	bool startTurn = false;
	private int playerTurnNum;
	// Use this for initialization
	void Start () {
		this.counter = 0;
		this.RoundCounter = 0;
		this.playerTurnNum = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(!this.startTurn){
		this.ShowRoundIntro ();
		}
		else{
			this.startPayerTurn ();
		}

	}
	void ShowRoundIntro(){
		//ui intro to show
		this.startTurn == true;
	}

}
