using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	public float damage;
	public string  myTeamColor;

	void Start(){
		
	}
	void OnTriggerEnter(Collider player){

		if(player.gameObject.tag == "Player")
		{
			Player playerInCollision;
			playerInCollision = player.gameObject.GetComponent<Player> ();
			if (playerInCollision.playerTeam.teamColor.ToString () != myTeamColor) {
				playerInCollision.playerUnit.health.ReceiveDamage (damage);
				Destroy (gameObject);
			}
		}
		if (player.gameObject.tag == "Finish") {
			Destroy (gameObject);
		}
	}
	public void myTeam(string teamColor){
		myTeamColor = teamColor;
	}
}
