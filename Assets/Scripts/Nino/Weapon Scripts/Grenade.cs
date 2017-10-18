using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {
	
	public float thrust;
	public Rigidbody rb;
	public Vector3 throwDirection;
	public GameObject myExplosion;
	public float timer;
	public float myDamage;

	// Use this for initialization
	void Start () {
		//throwDirection = pl.lastDirection * -thrust;
	}

	void Update(){
		timer -= Time.deltaTime;
		if (timer <= 2.5)
			GetComponent<SphereCollider> ().enabled = true;
		if (timer <= 0) {
			Instantiate (myExplosion, gameObject.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
	public void SetMe(Vector3 playerDir){
		throwDirection = new Vector3 (-playerDir.x, 1f, -playerDir.z * 2);
		rb.AddForce((throwDirection * 6), ForceMode.Impulse);
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			Player colPlayer = col.gameObject.GetComponent<Player> ();
			colPlayer.playerUnit.health.ReceiveDamage (myDamage);
			Instantiate (myExplosion, gameObject.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}


