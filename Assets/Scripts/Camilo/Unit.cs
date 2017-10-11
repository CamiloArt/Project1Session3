using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    public Vehicles vehicleLib;
    public int vehicleIndex;
    public GameObject vehicle;
	public Item item1;
	public Item item2;
	public float damage;
	public Speed speed;
	public Armor armor;
	public Health health;
	public Fuel fuel;
	public Range range;
	public Player player;

	public bool isAlive;

	// Use this for initialization
	void Start () {
		isAlive = true;
        vehicleIndex = 0;
        vehicleLib = GameObject.FindGameObjectWithTag("Finish").GetComponent<Vehicles>();
        vehicle = Instantiate(vehicleLib.car[vehicleIndex], gameObject.transform.position, Quaternion.identity, gameObject.transform);
	}
	
	// Update is called once per frame
	void Update () {
		if (health.currentHp <= 0) {
			isAlive = false;
		}
	}
}
