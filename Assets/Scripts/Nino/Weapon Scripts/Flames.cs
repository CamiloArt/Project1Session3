using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour {

	public float damage;
	private Player myPlayer;

	void Start(){
		myPlayer = gameObject.GetComponentInParent<Player> ();
	}

	void OnTriggerStay(Collider player){

		if(player.gameObject.tag == "Player")
		{
			Player playerOnHit;
			playerOnHit = player.GetComponent<Player> ();
			if (playerOnHit.playerTeam.teamColor.ToString () != myPlayer.playerTeam.teamColor.ToString ())
				playerOnHit.playerUnit.health.ReceiveDamage (damage);

		}
	}

	void OnTriggerExit(Collider player){

	}
}
