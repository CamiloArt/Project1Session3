using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public CameraInput camInput;
	public float speed;
	private Vector3 direction;
	private CharacterController camCc; 
	private Vector3 lastPosition;

	// Use this for initialization
	void Start () {
		this.direction = Vector3.zero;
		this.camCc = this.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		this.direction = Vector3.zero;

		if(Input.GetKey(this.camInput.forward)){
			this.direction += Vector3.forward;
		}else if(Input.GetKey(this.camInput.backward)){
			this.direction += Vector3.back;
		}
		if(Input.GetKey(this.camInput.right)){
			this.direction += Vector3.right;
		}else if(Input.GetKey(this.camInput.left)){
			this.direction += Vector3.left;
		}
		this.camCc.Move(direction * this.speed * Time.deltaTime);
		lastPosition = this.transform.position;
	}
	void LateUpdate(){
		this.FixPosition ();
	}
	void FixPosition(){
		lastPosition.y = 0;
		this.transform.position = lastPosition;
	}
}
