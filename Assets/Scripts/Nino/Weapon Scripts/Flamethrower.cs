using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour {
	
	public GameObject flamer;
	public Player myPlayer;
	public float timelimit;
	public float coolDown;
	private float currentTime;
	public ParticleSystem myParticle;

	void Start () {
		myPlayer = gameObject.GetComponentInParent<Player> ();
		currentTime = timelimit;
	}

	void Update () {
		if (myPlayer.myController.shooting) {
			flamer.SetActive (true);
			myParticle.Play ();
		} else {
			flamer.SetActive (false);
			myParticle.Stop ();
		}
		if (myPlayer.myController.shootingVector != Vector3.zero)
			transform.rotation = Quaternion.LookRotation(myPlayer.myController.shootingVector);
	}
}