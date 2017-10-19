using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caltrops : MonoBehaviour {

	public ParticleSystem caltropsParticles;
	private float myTime;
	public float activationTime;
	// Use this for initialization
	void Start () {
		myTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		myTime += Time.deltaTime;
	}

	void OnParticleCollision(GameObject other){
		if (other.tag == "Player" && myTime > activationTime) {
			Debug.Log ("Entered caltrops");
			Player collisionPlayer;
			collisionPlayer = other.GetComponent<Player> ();
			collisionPlayer.playerUnit.CaltropsEnter();
		}		
	}
	public void SetMe(){
	}
}
