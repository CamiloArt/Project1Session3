using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {
	
	public float thrust;
	public Rigidbody rb;
	public Player2 pl;
	private Vector3 throwDirection;

	// Use this for initialization
	void Start () {

		pl = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player2> ();
		
			rb = GetComponent<Rigidbody>();
		throwDirection = pl.lastDirection * -thrust;
		rb.AddForce(throwDirection, ForceMode.Impulse);
		Destroy (gameObject, 5);

	}
}


