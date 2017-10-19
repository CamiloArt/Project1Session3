using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelMannager : MonoBehaviour {
	public float myExperience;
	public int myLevel;
	public levelLibrary lvlLibrary;
	private Player myPlayer;
	// Use this for initialization
	void Start () {
		myLevel = 1;
		myExperience = 0;
		myPlayer = gameObject.GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (myExperience > lvlLibrary.levels [myLevel]) {
			myExperience = myExperience - lvlLibrary.levels [myLevel];
			myLevel++;
			UpdateStats (myLevel);
		}
	}
	void UpdateStats(int level){
		switch (level) {
		case 2:
			myPlayer.playerUnit.health.initialHp += 1f;
			myPlayer.playerUnit.health.currentHp += 1f;
			break;
		case 3:
			myPlayer.playerUnit.armor.currentArmor += 0.5f;
			break;
		case 4:
			myPlayer.playerUnit.speed.mapSpeed += 1f;
			break;
		case 5:
			myPlayer.playerUnit.speed.maxSpeed += 1;
			break;
		case 6:
			myPlayer.playerUnit.health.initialHp += 1f;
			myPlayer.playerUnit.health.currentHp += 1f;
			break;
		case 7:
			myPlayer.playerUnit.fuel.fuelConsumption -= 0.5f;
			break;
		case 8:
			myPlayer.playerUnit.armor.currentArmor += 1f;
			break;
		case 9:
			myPlayer.playerUnit.speed.mapSpeed += 1f;
			break;
		case 10:
			myPlayer.playerUnit.health.initialHp += 1f;
			myPlayer.playerUnit.health.currentHp += 1f;
			break;
		}
	}
}
