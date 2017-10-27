using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAfterTime : MonoBehaviour {

	public float timeToDie;
	
	// Update is called once per frame
	void Start () {
		Destroy (gameObject, timeToDie);
	}
}
