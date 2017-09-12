using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

	public Item item1;
	public Item item2;
	public float damage;
	public float speed;
	public float armor;
	public float health;
	private GameEngine gameEngine;
	// Use this for initialization
	void Start () {
		gameEngine = GameObject.FindGameObjectWithTag ("GameEngine").GetComponent<GameEngine> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
