using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSights : MonoBehaviour {

	public Rocket myRocket;
	public Transform target;
	private GameEngine gameEngine;
	public int enemyIndex;
	public bool locked;
	public float timer;
	public bool lockOn;
	public float targetDistance;
	public float minDistance;

	void Start(){
		gameEngine = GameObject.FindGameObjectWithTag ("GameEngine").GetComponent<GameEngine> ();
		lockOn = false;
		locked = false;
	}

	void Update(){		
			target.position = gameEngine.players [enemyIndex].gameObject.transform.position;
		targetDistance = Vector3.Distance (gameObject.transform.position,target.position);
		if (targetDistance <= minDistance) {
			lockOn = true;
		} else {
			lockOn = false;
		}
		if (lockOn) {
			timer = 3.0f;
			locked = true;
		} else {
			timer -= 1 * Time.deltaTime;
			if (timer <= 0)
				locked = false;
		}
	}
	public void SetTarget(int enemy){
		enemyIndex = enemy;
	}
}
