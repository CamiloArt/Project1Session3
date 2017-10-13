using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyValues : MonoBehaviour {
	//--PUBLIC VARIABLES--//
    public Unit[] unit;
    public LoadManager loadManager;
    public SelectWeapon selectWeapon;
    public SelectConsumables selectConsumable;

	public bool muscleCar_LookAt;
	public bool buggy_LookAt;
	public bool monsterTruck_LookAt;

    [Header("Damage")]
    public float damage_new;
    [Header("Speed")]
    public float mapSpeed_new;
    public float minSpeed_new;
    public float maxSpeed_new;
    public float turboSpeed_new;
    public float currentSpeed_new;
    public float speedDampener_new;
    public float speedMultiplier;
    [Header("Armor")]
    public float maxArmor_new;
    public float initialArmor_new;
    public float currentArmor_new;
    public float damageReduceMultiplier_new;
    [Header("Health")]
    public float maxHp_new;
    public float currentHp_new;
    public float initialHp_new;
    [Header("Fuel")]
    public float maxFuel_new;
    public float currentFuel_new;
    public float fuelConsumption_new;
    public float terrainValue_new;
    [Header("Range")]
    public float range_new;
	//--PRIVATE VARIABLES--//
    private GameEngine gameEngine;

    private int valueIndex;

    void Awake(){
        gameEngine = GameObject.FindGameObjectWithTag ("GameEngine").GetComponent<GameEngine> ();
    }

	void Update () 
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, 20f))
        {
            //MuscleCar
			if (hit.collider.gameObject.name.Equals("Values0"))
			{
				muscleCar_LookAt = true;
				print(hit.collider.gameObject.name);
                valueIndex = 0;

                //Damage
                damage_new = unit[valueIndex].damage;
                //Speed
                mapSpeed_new = unit[valueIndex].speed.mapSpeed;
                minSpeed_new = unit[valueIndex].speed.minSpeed;
                maxSpeed_new = unit[valueIndex].speed.maxSpeed;
                turboSpeed_new = unit[valueIndex].speed.turboSpeed;
                currentSpeed_new = unit[valueIndex].speed.currentSpeed;
                speedDampener_new = unit[valueIndex].speed.speedDampener;
                //Armor
                maxArmor_new = unit[valueIndex].armor.maxArmor;
                initialArmor_new = unit[valueIndex].armor.initialArmor;
                currentArmor_new = unit[valueIndex].armor.currentArmor;
                damageReduceMultiplier_new = unit[valueIndex].armor.damageReduceMultiplier;
                //Health
                maxHp_new = unit[valueIndex].health.maxHp;
                currentHp_new = unit[valueIndex].health.currentHp;
                initialHp_new = unit[valueIndex].health.initialHp;
                //Fuel
                maxFuel_new = unit[valueIndex].fuel.maxFuel;
                currentFuel_new = unit[valueIndex].fuel.currentFuel;
                fuelConsumption_new = unit[valueIndex].fuel.fuelConsumption;
                terrainValue_new = unit[valueIndex].fuel.terrainValue;
                //Range
                range_new = unit[valueIndex].range.range;
			}
			else
			{
				muscleCar_LookAt = false;
			}
            //Buggy
			if (hit.collider.gameObject.name.Equals("Values1"))
			{
				buggy_LookAt = true;
				print(hit.collider.gameObject.name);
                valueIndex = 1;

                //Damage
                damage_new = unit[valueIndex].damage;
                //Speed
                mapSpeed_new = unit[valueIndex].speed.mapSpeed;
                minSpeed_new = unit[valueIndex].speed.minSpeed;
                maxSpeed_new = unit[valueIndex].speed.maxSpeed;
                turboSpeed_new = unit[valueIndex].speed.turboSpeed;
                currentSpeed_new = unit[valueIndex].speed.currentSpeed;
                speedDampener_new = unit[valueIndex].speed.speedDampener;
                //Armor
                maxArmor_new = unit[valueIndex].armor.maxArmor;
                initialArmor_new = unit[valueIndex].armor.initialArmor;
                currentArmor_new = unit[valueIndex].armor.currentArmor;
                damageReduceMultiplier_new = unit[valueIndex].armor.damageReduceMultiplier;
                //Health
                maxHp_new = unit[valueIndex].health.maxHp;
                currentHp_new = unit[valueIndex].health.currentHp;
                initialHp_new = unit[valueIndex].health.initialHp;
                //Fuel
                maxFuel_new = unit[valueIndex].fuel.maxFuel;
                currentFuel_new = unit[valueIndex].fuel.currentFuel;
                fuelConsumption_new = unit[valueIndex].fuel.fuelConsumption;
                terrainValue_new = unit[valueIndex].fuel.terrainValue;
                //Range
                range_new = unit[valueIndex].range.range;
			}
			else
			{
				buggy_LookAt = false;
			}
            //MonsterTruck
			if (hit.collider.gameObject.name.Equals("Values2"))
			{
				monsterTruck_LookAt = true;
				print(hit.collider.gameObject.name);
                valueIndex = 2;

                //Damage
                damage_new = unit[valueIndex].damage;
                //Speed
                mapSpeed_new = unit[valueIndex].speed.mapSpeed;
                minSpeed_new = unit[valueIndex].speed.minSpeed;
                maxSpeed_new = unit[valueIndex].speed.maxSpeed;
                turboSpeed_new = unit[valueIndex].speed.turboSpeed;
                currentSpeed_new = unit[valueIndex].speed.currentSpeed;
                speedDampener_new = unit[valueIndex].speed.speedDampener;
                //Armor
                maxArmor_new = unit[valueIndex].armor.maxArmor;
                initialArmor_new = unit[valueIndex].armor.initialArmor;
                currentArmor_new = unit[valueIndex].armor.currentArmor;
                damageReduceMultiplier_new = unit[valueIndex].armor.damageReduceMultiplier;
                //Health
                maxHp_new = unit[valueIndex].health.maxHp;
                currentHp_new = unit[valueIndex].health.currentHp;
                initialHp_new = unit[valueIndex].health.initialHp;
                //Fuel
                maxFuel_new = unit[valueIndex].fuel.maxFuel;
                currentFuel_new = unit[valueIndex].fuel.currentFuel;
                fuelConsumption_new = unit[valueIndex].fuel.fuelConsumption;
                terrainValue_new = unit[valueIndex].fuel.terrainValue;
                //Range
                range_new = unit[valueIndex].range.range;
			}
			else
			{
				monsterTruck_LookAt = false;
			}
        }
        Debug.DrawRay(transform.position, fwd * 50, Color.yellow);
	}

    public void ApplyUnitValues()
    {
        //GENERAL STATS
        //Damage
        gameEngine.currentPlayer.playerUnit.damage = damage_new;
        //Speed
        gameEngine.currentPlayer.playerUnit.speed.mapSpeed = mapSpeed_new;
        gameEngine.currentPlayer.playerUnit.speed.minSpeed = minSpeed_new;
        gameEngine.currentPlayer.playerUnit.speed.mapSpeed = maxSpeed_new;
        gameEngine.currentPlayer.playerUnit.speed.turboSpeed = turboSpeed_new;
        gameEngine.currentPlayer.playerUnit.speed.currentSpeed = currentSpeed_new;
        gameEngine.currentPlayer.playerUnit.speed.speedDampener = speedDampener_new;
        gameEngine.currentPlayer.playerUnit.speed.speedMultiplier = speedMultiplier;
        //Armor
        gameEngine.currentPlayer.playerUnit.armor.maxArmor = maxArmor_new;
        gameEngine.currentPlayer.playerUnit.armor.initialArmor = initialArmor_new;
        gameEngine.currentPlayer.playerUnit.armor.currentArmor = currentArmor_new;
        gameEngine.currentPlayer.playerUnit.armor.damageReduceMultiplier = damageReduceMultiplier_new;
        //Health
        gameEngine.currentPlayer.playerUnit.health.maxHp = maxHp_new;
        gameEngine.currentPlayer.playerUnit.health.currentHp = currentHp_new;
        gameEngine.currentPlayer.playerUnit.health.initialHp = initialHp_new;
        //Fuel
        gameEngine.currentPlayer.playerUnit.fuel.maxFuel = maxFuel_new;
        gameEngine.currentPlayer.playerUnit.fuel.currentFuel = currentFuel_new;
        gameEngine.currentPlayer.playerUnit.fuel.fuelConsumption = fuelConsumption_new;
        gameEngine.currentPlayer.playerUnit.fuel.terrainValue = terrainValue_new;
        //Range
        gameEngine.currentPlayer.playerUnit.range.range = range_new;

        //vehicleIndex 
        gameEngine.currentPlayer.playerUnit.vehicleIndex = valueIndex;

        //Weapons Slot 
        //gameEngine.currentPlayer.playerUnit.item1 = selectWeapon.currentSelectedWeapon; //Secondary Weapon

        //Consumables Slot
        //gameEngine.currentPlayer.playerUnit.item2 = selectConsumable.currentSelectedConsumable; //Consumable

        gameEngine.endSelection();   

        if (gameEngine.playerTurnNum > 10) //last player has clicked "Ready"
        {
            loadManager.loadToStrategyMap = true;
            gameEngine.playerTurnNum = 1;
        }
    }
}
