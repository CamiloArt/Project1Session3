using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turf : MonoBehaviour {

	public float minDistance;
	public GameEngine gameEngine;
	private bool blueLeader;
	private int blueGuardsCounter;
	private int redLeader;
	private int redGuardsCounter;
	public enum OwnerNames
	{
		Neutral,
		RedTeam,
		BlueTeam
	}
	public OwnerNames owner;
	// Use this for initialization
	void Start () {
		gameEngine = GameObject.FindGameObjectWithTag ("GameEngine").GetComponent<GameEngine> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameEngine.gameState == "strategyMap") {
			CheckPlayers ();
		}
	}
	void CheckPlayers(){
		float distance;
		blueLeader = false;
		redLeader = false;
		for (int i = 0; i < gameEngine.players.Length; i++) {
			distance = Vector3.Distance (gameEngine.players[i].gameObject.transform.position, gameObject.transform.position);
			if (distance < minDistance) {
				if (gameEngine.players [i].typeOfPlayer.ToString () == "Leader") {
					if (gameEngine.players [i].playerTeam.teamColor.ToString == "Blue") {
						blueLeader = true;
					}
					if (gameEngine.players [i].playerTeam.teamColor.ToString == "Red") {
						redLeader = true;
					}
					Debug.Log ("Leader on turf");
				}
				if (gameEngine.players [i].typeOfPlayer.ToString () == "Guard") {
					if (gameEngine.players [i].playerTeam.teamColor.ToString == "Blue") {
						blueGuardsCounter++;
					}
					if (gameEngine.players [i].playerTeam.teamColor.ToString == "Red") {
						redGuardsCounter++;
					}
					Debug.Log ("Guard on turf");
				}
			}
		}
		SetTurf();
	}
	void SetTurf(){
		
	}
}
