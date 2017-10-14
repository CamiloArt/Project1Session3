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
	public bool playerInTerrain;

	// Use this for initialization
	void Awake () {
		gameEngine = GameObject.FindGameObjectWithTag ("GameEngine").GetComponent<GameEngine> ();
		terrainRadius = 3;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		playerInTerrain = false;
		distance = Vector3.Distance (gameObject.transform.position, gameEngine.currentPlayer.gameObject.transform.position);
		if (distance <= terrainRadius) {
			gameEngine.currentPlayer.playerUnit.fuel.terrainValue = terrainValue;
		}
	}
	/*void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "Player") {
			distance = Vector3.Distance (gameObject.transform.position, gameEngine.currentPlayer.gameObject.transform.position);
			if (distance <= terrainRadius) {
				playerInTerrain = true;
			}
			if(playerInTerrain)
				playerOnTerrain = coll.gameObject.GetComponent<Player> ();
				playerOnTerrain.playerUnit.fuel.terrainValue = terrainValue;
		}
	}
	void OnTriggerExit(Collider coll){
		if (coll.gameObject.tag == "Player") {
			distance = Vector3.Distance (gameObject.transform.position, gameEngine.currentPlayer.gameObject.transform.position);
			if (distance <= terrainRadius) {
				playerInTerrain = true;
			}
			if(!playerInTerrain)
			playerOnTerrain = coll.gameObject.GetComponent<Player> ();
			playerOnTerrain.playerUnit.fuel.terrainValue = 0;
		}
	}*/
}
