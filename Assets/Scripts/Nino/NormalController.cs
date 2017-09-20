using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalController : MonoBehaviour {
	
	public float speed;

	// Update is called once per frame
	void Update () {

		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");

		transform.Translate (x * Time.deltaTime * speed,0,y * Time.deltaTime * speed, Space.World);

		float angle = Mathf.Atan2 (x, y);

		transform.rotation = Quaternion.EulerAngles (0, angle, 0);
	
	}
}
