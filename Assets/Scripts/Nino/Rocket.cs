using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
	 
	//Speed of the rocket
	public float speed = 2.0f;
	//movement at the rocket. After five seconds, it will destroy itself.
	void Update () {
		this.transform.position += this.transform.forward * this.speed * Time.deltaTime;
		 Destroy(gameObject, 5);
		
	}

}














