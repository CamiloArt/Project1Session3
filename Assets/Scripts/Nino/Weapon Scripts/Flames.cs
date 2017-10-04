using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour {

	public float damage;
	public string target;
	public string player;

	void OnTriggerStay(Collider player){

		if(player.gameObject.tag == target)
		{
			player.gameObject.SendMessage ("ReceiveDamage", damage);

		}
	}

	void OnTriggerExit(Collider player){

	}
}
