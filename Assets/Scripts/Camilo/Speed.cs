using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour {

	public float mapSpeed;
	public float minSpeed;
	public float maxSpeed;
	public float turboSpeed;
	public float currentSpeed;
	public float speedDampener;
	public float speedMultiplier;
	public float caltropsReducer;

	// Use this for initialization
	void Start () {
		caltropsReducer = 15;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
