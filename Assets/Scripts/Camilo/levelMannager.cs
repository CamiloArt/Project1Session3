using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelMannager : MonoBehaviour {
	public float myExperience;
	public int myLevel;
	private levelLibrary lvlLibrary;
	// Use this for initialization
	void Start () {
		myLevel = 1;
		myExperience = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (myExperience > lvlLibrary.levels [myLevel]) {
			myExperience = myExperience - lvlLibrary.levels [myLevel];
			myLevel++;
		}
	}
}
