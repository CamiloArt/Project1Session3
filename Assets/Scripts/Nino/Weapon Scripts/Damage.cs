using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	public float damage;
	public Player myPlayer;

	void Start(){
		myPlayer = gameObject.GetComponentInParent<Player> ();
	}
	void OnTriggerEnter(Collider player){

		if(player.gameObject.tag == "Player")
		{
			Player playerInCollision;
			playerInCollision = player.gameObject.GetComponent<Player> ();
			if (playerInCollision.playerTeam.teamColor.ToString () != myPlayer.playerTeam.teamColor.ToString ()) {
				playerInCollision.playerUnit.health.ReceiveDamage (damage);
				Destroy (gameObject);
			}
		}
}
}
