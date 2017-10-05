using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour {
	public Player myPlayer;

	public string hAxisName;
	public string vAxisName;
	public string trigger;

	void Awake(){
		myPlayer = gameObject.GetComponent<Player> ();
	}

	void Start(){
		if (myPlayer.playerTeam.teamColor == Team.tColor.Blue) {
			hAxisName = "BluePlayerHorizontal";
			vAxisName = "BluePlayerVertical";
			trigger = "BlueLeftTrigger";

		} else if(myPlayer.playerTeam.teamColor == Team.tColor.Red) {
			hAxisName = "RedPlayerHorizontal";
			vAxisName = "RedPlayerVertical";
			trigger = "RedLeftTrigger";
		}
	}
	// Update is called once per frame
}
