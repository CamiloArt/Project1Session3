using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMChildPlatformRotation : MonoBehaviour {

    public GameObject[] childP; //child platform 

    private float childPSpeed = 10f;

	void Start() 
    {
		
	}

	void Update() 
    {
        foreach (GameObject cPlatform in childP)
        {
            cPlatform.transform.Rotate(Vector3.up * childPSpeed * Time.deltaTime);	
        }
	}
}
