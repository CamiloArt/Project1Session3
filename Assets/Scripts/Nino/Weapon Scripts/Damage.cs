using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	public float damage;
	public string target;
	public string player;


	void OnTriggerEnter(Collider player){

		if(player.gameObject.tag == target)
		{
			player.gameObject.SendMessage ("ReceiveDamage", damage);
			Destroy(gameObject);
		}
}
}
