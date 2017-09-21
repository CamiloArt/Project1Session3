using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	private GameEngine gameEngine;

	// Use this for initialization
	void Start () {
		gameEngine = GameObject.FindGameObjectWithTag ("GameEngine").GetComponent<GameEngine> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameEngine.currentPlayer) {
			SetPosition ();
		}	
	}
	void LateUpdate(){
		
	}
	void SetPosition(){
		gameObject.transform.position = gameEngine.currentPlayer.gameObject.transform.position;
	}
}
