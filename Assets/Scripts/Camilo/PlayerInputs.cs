using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour {
	public Player myPlayer;

	public string hAxisName;
	public string vAxisName;
	public string trigger;
	public string hAxisName2;
	public string vAxisName2;

	void Awake(){
		myPlayer = gameObject.GetComponent<Player> ();
	}

	void Start(){
		if (myPlayer.playerTeam.teamColor == Team.tColor.Blue) {
			hAxisName = "BluePlayerHorizontal";
			vAxisName = "BluePlayerVertical";
			trigger = "BlueLeftTrigger";
			hAxisName2 = "BluePlayerHorizontal2";
			vAxisName2 = "BluePlayerVertical2";
			/*hAxisName = "Horizontal";
			vAxisName = "Vertical";
			trigger = "BlueLeftTrigger";*/

		} else if(myPlayer.playerTeam.teamColor == Team.tColor.Red) {
			/*hAxisName = "RedPlayerHorizontal";
			vAxisName = "RedPlayerVertical";
			trigger = "RedLeftTrigger";*/
			hAxisName2 = "RedPlayerHorizontal2";
			vAxisName2 = "RedPlayerVertical2";
			hAxisName = "Horizontal";
			vAxisName = "Vertical";
			trigger = "BlueLeftTrigger";
		}
	}
	// Update is called once per frame
}
