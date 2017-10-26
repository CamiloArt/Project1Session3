using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    public Vehicles vehicleLib;
    public int vehicleIndex, weaponIndex, consumableIndex;
    public GameObject vehicle, weapon1, weapon2;
	public Item item1;
	public Item item2;
	public float damage;
	public Speed speed;
	public Armor armor;
	public Health health;
	public Fuel fuel;
	public Range range;
	public Player player;
	private carWeapon myPos;
	public bool inCaltrops;
	public float caltropsCooldown;
	public float caltropsTime;
	public int consumablesNum;
	public int initialConsumables;

	public bool isAlive;

	// Use this for initialization
	void Start () {
		isAlive = true;
        vehicleLib = GameObject.FindGameObjectWithTag("Finish").GetComponent<Vehicles>();
		player = gameObject.GetComponentInParent<Player> ();
		consumablesNum = initialConsumables;
	}
	
	// Update is called once per frame
	void Update () {
		if (health.currentHp <= 0) {
			isAlive = false;
		}
		if (inCaltrops) {
			caltropsTime -= Time.deltaTime;
		}
		if (caltropsTime < 0) {
			inCaltrops = false;
		}
	}
	public void LoadModels(){
		vehicle = Instantiate(vehicleLib.car[vehicleIndex], gameObject.transform.position, Quaternion.identity, gameObject.transform);
		Vector3 weaponPos;
		myPos = vehicle.gameObject.GetComponent<carWeapon> ();
		weaponPos = myPos.weaponPosition.position;
		myPos.teamColor = player.playerTeam.teamColor.ToString ();
		myPos.SetColor ();
		weapon1 = Instantiate (vehicleLib.weapon [weaponIndex], weaponPos, Quaternion.identity, vehicle.gameObject.transform);
		weapon2 = Instantiate (vehicleLib.weapon [0], weaponPos, Quaternion.identity, vehicle.gameObject.transform);
		weapon2.SetActive (false);
	}
	public void UseConsumable(Vector3 lastDir){
		if (consumablesNum > 0) {
			consumablesNum--;
			GameObject newConsumable;
			Vector3 consumablePos = myPos.consumablePosition.position;
			newConsumable = Instantiate (vehicleLib.consumable [consumableIndex], consumablePos, player.gameObject.transform.rotation);
			if (consumableIndex == 1)
				newConsumable.gameObject.SendMessage ("SetMe", lastDir);

		}
	}
	public void CaltropsEnter(){
		inCaltrops = true;
		caltropsTime = caltropsCooldown;
	}
	public void ResetConsumables(){
		consumablesNum = initialConsumables;
	}
}
