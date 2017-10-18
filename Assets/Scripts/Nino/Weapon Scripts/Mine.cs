using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {
	
	public float gravity;
	private Vector3 moveDirection = Vector3.zero;
	public float myDamage;
	public ParticleSystem myParticle;

	void Update () {
		CharacterController cc = GetComponent<CharacterController>();
		if (!cc.isGrounded) {
			moveDirection.y -= gravity * Time.deltaTime;
			cc.Move (moveDirection * Time.deltaTime);
		}
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.SendMessage ("ReceiveDamage", myDamage);
			myParticle.Play ();
		}
	}


}



	
