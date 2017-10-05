using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	public float RedTeamTurfs;
	public float blueTeamTurfs;
	public GameEngine gameEngine;

	[Header("Please insert all the turfs")]
	public Turf[] turfs;
	private int turnsCounter;
	void Awake(){
		gameEngine = GameObject.FindGameObjectWithTag ("GameEngine").GetComponent<GameEngine> ();
	}
	// Use this for initialization
	void Start () {
		turnsCounter = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (turnsCounter != gameEngine.turnCounter) {
			turnsCounter = gameEngine.turnCounter;
			UpdateScore ();
		}
	}
	void UpdateScore(){
		RedTeamTurfs = 0;
		blueTeamTurfs = 0;
		for (int i = 0; i < turfs.Length; i++) {
			if (turfs [i].owner == Turf.OwnerNames.BlueTeam) {
				blueTeamTurfs++;
			}
			else if (turfs [i].owner == Turf.OwnerNames.RedTeam) {
				RedTeamTurfs++;
			}
		}
	}
}
