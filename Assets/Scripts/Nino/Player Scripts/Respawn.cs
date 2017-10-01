using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
	public Vector3 respawn;
	public CombatHealth hl;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (hl.isDead == true)
		{
			transform.position = respawn;
			hl.isDead = false;
			hl.currentHealth = hl.startingHealth;
		}
}
}