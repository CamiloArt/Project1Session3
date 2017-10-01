using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour {

	public GameObject consumablePrefab;

	public float cooldown;
	public float remainTime;
	public float consumablesLeft = 0f;


	public enum Team {

		blue,
		red,
		nbteam,
		invalid
	}

	public Team team = Team.invalid;

	private string horizontalAxis;
	private string verticalAxis;
	private string Trigger;

	void Start () {
		switch (team) {
		case Team.blue:
			Trigger = "BlueRightTrigger";
			break;
		case Team.red:
			Trigger = "RedRightTrigger";
			break;
		}
	
		remainTime = cooldown;
	}
	// Update is called once per frame
	void Update () 
	{

		if (consumablesLeft >= 1)
		{
		
			if (Input.GetAxis (Trigger) > 0.2 && remainTime >= cooldown)
		
			{
			Instantiate (consumablePrefab, this.transform.position, this.transform.rotation); 
				consumablesLeft = consumablesLeft - 1;
				remainTime = 0;
			}
		}

		remainTime += Time.deltaTime;
	}
}
