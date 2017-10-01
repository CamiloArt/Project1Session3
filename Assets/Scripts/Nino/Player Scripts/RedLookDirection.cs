using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLookDirection : MonoBehaviour {

	public CombatPlayer pl;

	// Update is called once per frame
	void Update () {

		if (pl.cc.isGrounded == true) {
			//This determined the direction at which you turn based on the left joystick of an Xbox controller
			Vector3 NextDir = new Vector3 (Input.GetAxisRaw ("RedPlayerHorizontal"), 0, Input.GetAxisRaw ("RedPlayerVertical"));
			//if you are moving, your next direction set by the joystick angle you are pressing
			if (NextDir != Vector3.zero)
				transform.rotation = Quaternion.LookRotation (NextDir);
		}
	}
}
