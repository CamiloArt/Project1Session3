using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {
	
	public float gravity;
	private Vector3 moveDirection = Vector3.zero;
	public float myDamage;
	public GameObject myExplosion;
	public float delay = 0.5f;
	public float currentTime;
	private bool activate;
	private GameEngine gameEngine;

	void Start(){
		gameEngine = GameObject.FindGameObjectWithTag ("GameEngine").GetComponent<GameEngine> ();
	}

	void Update () {
		activate = false;
		CharacterController cc = GetComponent<CharacterController>();
		if (!cc.isGrounded) {
			moveDirection.y -= gravity * Time.deltaTime;
			cc.Move (moveDirection * Time.deltaTime);
		}
		currentTime += Time.deltaTime;
		if (currentTime > delay) {
			activate = true;
		}
		if (gameEngine.gameState == "strategyMap") {
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player" && activate) {
			Player colPlayer = col.gameObject.GetComponent<Player> ();
			colPlayer.playerUnit.health.ReceiveDamage (myDamage);
			Instantiate (myExplosion, gameObject.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}



	
