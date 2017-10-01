using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile: MonoBehaviour {
	 
	public float speed = 2.0f;

	void Update () {
		this.transform.position += this.transform.forward * this.speed * Time.deltaTime;
		 Destroy(gameObject, 5);
		
	}

}














