using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour {

	public GameObject bulletPrefab;
	//speed
	public float speed = 2.0f;

	public float firingTime;
	public float canShootTime;
	public float bulletTimeNum;
	public int bulletNum;


	public bool shooting;

	public enum Team {

		blue,
		red,
		nbteam,
		invalid
	}

	public Team team = Team.invalid;

	private string horizontalAxis;
	private string verticalAxis;

	void Start () {
		bulletTimeNum = 0f;
		firingTime = 0f;
		bulletNum = 0;

		switch (team) {
		case Team.blue:
			horizontalAxis = "BluePlayerHorizontal2";
			verticalAxis = "BluePlayerVertical2";
			break;
		case Team.red:
			horizontalAxis = "RedPlayerHorizontal2";
			verticalAxis = "RedPlayerVertical2";
			break;
		}


	}

	void Update () {
		//the inputs 

		firingTime += Time.deltaTime;

		float x2 = Input.GetAxis (horizontalAxis);
		float y2 = Input.GetAxis (verticalAxis);
		//discovering the angle
		float angle = Mathf.Atan2 (x2, y2);
		//using the angle to move
		transform.rotation = Quaternion.EulerAngles (0, angle, 0);
		//the directions which the launcher will move towards

		shooting = false;

		if (Input.GetAxis (horizontalAxis) > 0.2)
		{
			shooting = true;
		}
		if (Input.GetAxis (horizontalAxis) < -0.2)
		{
			shooting = true; 
		}
		if (Input.GetAxis (verticalAxis) > 0.2) 
		{
			shooting = true;
		}
		if (Input.GetAxis (verticalAxis) < -0.2)
		{
			shooting = true;

		}
		if (shooting == true && canShootTime <= firingTime) 
		{
			ShootBullet ();
		}

		//the rotation of the launcher
		Vector3 NextDir = new Vector3(Input.GetAxisRaw(horizontalAxis), 0, Input.GetAxisRaw(verticalAxis));
		if (NextDir != Vector3.zero)
			transform.rotation = Quaternion.LookRotation(NextDir);
	}
	void ShootBullet(){
		bulletTimeNum += Time.deltaTime;
		float btimecd = 0.1f;
		if (bulletNum < 3) {
			if (bulletTimeNum > btimecd) {
				Instantiate (bulletPrefab, this.transform.position, this.transform.rotation); 
				bulletTimeNum = 0;
				bulletNum++;
			}
		} else {
			firingTime =0f;
			bulletNum = 0;
		}
	}
}


