using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapTerrains : MonoBehaviour {

	private GameEngine gameEngine;
	private Player playerOnTerrain;
	public float terrainRadius;
	private float distance;
	[Range(-9.0f, 9.0f)]
	public float terrainValue;

	// Use this for initialization
	void Awake () {
		gameEngine = GameObject.FindGameObjectWithTag ("GameEngine").GetComponent<GameEngine> ();
	}
	
	// Update is called once per frame
	/*void Update () {
		if (gameEngine.currentPlayer) {
			distance = Vector3.Distance (gameObject.transform.position, gameEngine.currentPlayer.gameObject.transform.position);
			gameEngine.currentPlayer.playerUnit.fuel.terrainValue = 0;
			if (distance <= terrainRadius) {
				gameEngine.currentPlayer.playerUnit.fuel.terrainValue = terrainValue;

			}
		}
	}*/
	void OnTriggerStay(Collider coll){
		if (coll.gameObject.tag == "Player") {
			playerOnTerrain = coll.gameObject.GetComponent<Player> ();
			Debug.Log ("Player here");
		}
	}
	void fixedUpdate(){
		playerOnTerrain.playerUnit.fuel.terrainValue = terrainValue;
	}
	/*void OnTriggerExit(Collider coll){
		if (coll.gameObject.tag == "Player") {
			Player playerOnTerrain;
			playerOnTerrain = coll.gameObject.GetComponent<Player> ();
			playerOnTerrain.playerUnit.fuel.terrainValue = 0;
		}
	}*/
}
