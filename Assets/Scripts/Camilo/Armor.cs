using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour {

	public float maxArmor;
	public float initialArmor;
	public float currentArmor;
	public float damageReduceMultiplier;

	// Use this for initialization
	void Start () {
		currentArmor = initialArmor;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
