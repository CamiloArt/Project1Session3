using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	public float damage;
	public string  myTeamColor;
	public GameObject hitAnimation;

	void Start(){
		
	}
	void OnTriggerEnter(Collider player){

		if(player.gameObject.tag == "Player")
		{
			Player playerInCollision;
			playerInCollision = player.gameObject.GetComponentInParent<Player> ();
			if (playerInCollision.playerTeam.teamColor.ToString () != myTeamColor) {
				playerInCollision.playerUnit.health.ReceiveDamage (damage);
				Instantiate (hitAnimation, gameObject.transform.position, Quaternion.identity);
				Destroy (gameObject);
			}
		}
		else if (player.gameObject.tag == "Finish") {
			Instantiate (hitAnimation, gameObject.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
	void OnTriggerStay(Collider player){

		if(player.gameObject.tag == "Player")
		{
			Player playerInCollision;
			playerInCollision = player.gameObject.GetComponentInParent<Player> ();
			if (playerInCollision.playerTeam.teamColor.ToString () != myTeamColor) {
				playerInCollision.playerUnit.health.ReceiveDamage (damage);
				Instantiate (hitAnimation, gameObject.transform.position, Quaternion.identity);
				Destroy (gameObject);
			}
		}
		else if (player.gameObject.tag == "Finish") {
			Instantiate (hitAnimation, gameObject.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
	public void myTeam(string teamColor){
		myTeamColor = teamColor;
	}
}
