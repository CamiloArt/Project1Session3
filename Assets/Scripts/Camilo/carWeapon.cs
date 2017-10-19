using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carWeapon : MonoBehaviour {
	public Transform weaponPosition;
	public Transform consumablePosition;
	public GameObject weapon;
	public GameObject mySkyn;
	public string teamColor; 
	public Material red, blue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SetColor(){
		Renderer myRender = mySkyn.GetComponent<Renderer> ();
		if (teamColor == Team.tColor.Blue.ToString()) {
			myRender.material = blue;
		}else{
			myRender.material = red;
		}
	}
}
