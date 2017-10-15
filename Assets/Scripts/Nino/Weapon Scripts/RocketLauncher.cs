using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour {

	public GameObject bulletPrefab;
	public int enemyIndex;
	private GameEngine gameEngine;
	public Player myPlayer;
	//speed
	public float speed = 2.0f;

	public bool shooting;
	public float firingTime;
	public float canShootTime;
	private bool indexSetted;

	void Start(){
		gameEngine = GameObject.FindGameObjectWithTag ("GameEngine").GetComponent<GameEngine> ();
		myPlayer = gameObject.GetComponentInParent<Player> ();
		indexSetted = false;
	}

	void Update () {
		if (myPlayer.inBattle) {
			if (!indexSetted) {
				setIndex ();
				indexSetted = true;
			}
		} else {
			indexSetted = false;
		}
		//the inputs 
		firingTime += Time.deltaTime;
		if (myPlayer.myController.shooting == true && canShootTime <= firingTime) 
		{
			GameObject bullet;
			bullet = Instantiate (bulletPrefab, this.transform.position, this.transform.rotation); 
			bullet.gameObject.SendMessage("myTeam",myPlayer.playerTeam.teamColor.ToString());
			bullet.gameObject.GetComponent<RocketSights> ().SetTarget (enemyIndex);
			//bullet.gameObject.SendMessage ("SetTarget", enemyIndex);
			firingTime =0f;

		}


		//the rotation of the launcher
		if (myPlayer.myController.shootingVector != Vector3.zero)
			transform.rotation = Quaternion.LookRotation(myPlayer.myController.shootingVector);
	}
	void setIndex(){
		if (myPlayer.playerTurn != gameEngine.players [gameEngine.currentPlayerIndex].playerTurn) {
			enemyIndex = gameEngine.currentPlayerIndex;
		} else {
			enemyIndex = gameEngine.playerInRangeIndex;
		}
	}
}


