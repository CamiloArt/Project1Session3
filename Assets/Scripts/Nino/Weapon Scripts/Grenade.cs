using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {
	
	public float thrust;
	public Rigidbody rb;
	private Vector3 throwDirection;
	public float timer;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody>();
		//throwDirection = pl.lastDirection * -thrust;
		rb.AddForce(throwDirection, ForceMode.Impulse);
		Destroy (gameObject, timer);

	}

	void Update(){
	
		if (timer <= 1)
			GetComponent<SphereCollider> ().enabled = true;
	}
}


