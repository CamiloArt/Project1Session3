using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

	public Item item1;
	public Item item2;
	public float damage;
	public float speed;
	public Armor armor;
	public Health health;
	public Fuel fuel;
	public Range range;
	public Player player;

	public bool isAlive;

	// Use this for initialization
	void Start () {
		isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (health.currentHp <= 0) {
			isAlive = false;
		}
	}
}
