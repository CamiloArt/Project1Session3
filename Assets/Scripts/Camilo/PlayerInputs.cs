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
	public string trigger2;
	public string Abutton;
	public string Bbutton;
	public string Ybutton;
	public string Xbutton;

	void Awake(){
		myPlayer = gameObject.GetComponent<Player> ();
	}

	void Start(){
		if (myPlayer.playerTeam.teamColor == Team.tColor.Blue) {
//			hAxisName = "BluePlayerHorizontal";
//			vAxisName = "BluePlayerVertical";
//			trigger = "BlueLeftTrigger";
			hAxisName2 = "BluePlayerHorizontal2";
			vAxisName2 = "BluePlayerVertical2";
			trigger2 = "BlueRightTrigger";
			Abutton = "BluePlayerA";
			Bbutton = "BluePlayerB";
			Ybutton = "BluePlayerY";
			Xbutton = "BluePlayerX";
			hAxisName = "Horizontal";
			vAxisName = "Vertical";
			trigger = "BlueLeftTrigger";

		} else if(myPlayer.playerTeam.teamColor == Team.tColor.Red) {
//			hAxisName = "RedPlayerHorizontal";
//			vAxisName = "RedPlayerVertical";
//			trigger = "RedLeftTrigger";
			hAxisName2 = "RedPlayerHorizontal2";
			vAxisName2 = "RedPlayerVertical2";
			trigger2 = "RedRightTrigger";
			Abutton = "RedPlayerA";
			Bbutton = "RedPlayerB";
			Ybutton = "RedPlayerY";
			Xbutton = "RedPlayerX";
			hAxisName = "Horizontal";
			vAxisName = "Vertical";
			trigger = "BlueLeftTrigger";
		}
	}
	// Update is called once per frame
}
