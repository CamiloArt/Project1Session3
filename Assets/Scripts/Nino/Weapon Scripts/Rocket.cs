using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {


	public float speed = 2.0f;

	public RocketSights rs;

	void Update () {
		this.transform.position += this.transform.forward * this.speed * Time.deltaTime;
		Destroy(gameObject, 5);


		if (rs.locked)
			transform.LookAt (rs.target);
	}

}
