using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour {

	public GameObject bulletPrefab;
	public Player myPlayer;
	//speed
	public float speed = 2.0f;

	public float firingTime;
	public float canShootTime;
	public float bulletTimeNum;
	public int bulletNum;


	public bool shooting;

	void Start () {
		myPlayer = gameObject.GetComponentInParent<Player> ();
		bulletTimeNum = 0f;
		firingTime = 0f;
		bulletNum = 0;
	}

	void Update () {
		//the inputs 

		firingTime += Time.deltaTime;

		/*if(Input.GetKey(KeyCode.V)){
			shooting = true;
		}*/
		if (myPlayer.myController.shooting && firingTime >= canShootTime) {
			ShootBullet ();
		}
		if (myPlayer.myController.shootingVector != Vector3.zero)
			transform.rotation = Quaternion.LookRotation(myPlayer.myController.shootingVector);
	}
	void ShootBullet(){
		bulletTimeNum += Time.deltaTime;
		float btimecd = 0.1f;
		if (bulletNum < 5) {
			if (bulletTimeNum > btimecd) {
				GameObject bullet; 
				bullet = Instantiate (bulletPrefab, this.transform.position, this.transform.rotation);
				bullet.gameObject.SendMessage("myTeam",myPlayer.playerTeam.teamColor.ToString());
				bulletTimeNum = 0;
				bulletNum++;
			}
		} else {
			firingTime =0f;
			bulletNum = 0;
		}
	}
}


