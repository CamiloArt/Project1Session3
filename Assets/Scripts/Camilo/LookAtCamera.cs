using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

	public Camera combatCamera;
	public Camera mainCamera;
	private GameEngine gameEngine;
	private Vector3 wantedPos;
	public Player myPlayer;
	public Slider mySlider;



	void Awake () {
		gameEngine = GameObject.FindGameObjectWithTag ("GameEngine").GetComponent<GameEngine> ();
		mySlider = gameObject.GetComponent<Slider> ();
		wantedPos = Vector3.zero;
	}

	// Update is called once per frame
	void Update () {
		mySlider.maxValue = myPlayer.playerUnit.health.maxHp;
		mySlider.value = myPlayer.playerUnit.health.currentHp;
		if(gameEngine.gameState == "battlemap"){
			wantedPos = combatCamera.WorldToScreenPoint (myPlayer.gameObject.transform.position);
		}else{
			wantedPos = mainCamera.WorldToScreenPoint (myPlayer.gameObject.transform.position);
		}
		transform.position = wantedPos;
	}
}
