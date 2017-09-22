using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {
	
	public float gravity = 20.0F;

	private Vector3 moveDirection = Vector3.zero;
	// Update is called once per frame
	void Update () {
		CharacterController cc = GetComponent<CharacterController>();
		if (cc.isGrounded) {
			
		}
		moveDirection.y -= gravity * Time.deltaTime;
		cc.Move(moveDirection * Time.deltaTime);
	}
}
	
