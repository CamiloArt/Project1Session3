using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyValues : MonoBehaviour {
	//--PUBLIC VARIABLES--//
    public Unit[] unit;

	public bool muscleCar_LookAt;
	public bool buggy_LookAt;
	public bool monsterTruck_LookAt;

    public float newDamage;
    public float newSpeed;
    public float newArmor;
    public float newHealth;
    public float newFuel;
    public float newRange;
	//--PRIVATE VARIABLES--//
    private GameEngine gameEngine;

    void Awake(){
        gameEngine = GameObject.FindGameObjectWithTag ("GameEngine").GetComponent<GameEngine> ();
    }

	void Update () 
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, 20f))
        {
			if (hit.collider.gameObject.name.Equals("Values0"))
			{
				muscleCar_LookAt = true;
				print(hit.collider.gameObject.name);
				//newDamage = unit[0].damage.initialDamage;
                newSpeed = unit[0].speed.maxSpeed;
				newArmor = unit[0].armor.currentArmor;
				newHealth = unit[0].health.currentHp;
				newFuel = unit[0].fuel.currentFuel;
				newRange = unit[0].range.range;
			}
			else
			{
				muscleCar_LookAt = false;
			}

			if (hit.collider.gameObject.name.Equals("Values1"))
			{
				buggy_LookAt = true;
				print(hit.collider.gameObject.name);
				//newDamage = unit[1].damage.initialDamage;
                //newSpeed = unit[1].speed.maxSpeed;
				newArmor = unit[1].armor.currentArmor;
				newHealth = unit[1].health.currentHp;
				newFuel = unit[1].fuel.currentFuel;
				newRange = unit[1].range.range;
			}
			else
			{
				buggy_LookAt = false;
			}

			if (hit.collider.gameObject.name.Equals("Values2"))
			{
				monsterTruck_LookAt = true;
				print(hit.collider.gameObject.name);
				//newDamage = unit[2].damage.initialDamage;
                //newSpeed = unit[2].speed.maxSpeed;
				newArmor = unit[2].armor.currentArmor;
				newHealth = unit[2].health.currentHp;
				newFuel = unit[2].fuel.currentFuel;
				newRange = unit[2].range.range;
			}
			else
			{
				monsterTruck_LookAt = false;
			}
        }
        Debug.Log(newDamage);
        Debug.DrawRay(transform.position, fwd * 50, Color.yellow);
	}

    public void ApplyUnitValues()
    {
        //gameEngine.currentPlayer.playerUnit.damage.currentDamage = newDamage;
        //gameEngine.currentPlayer.playerUnit.speed.maxSpeed = newSpeed;
        gameEngine.currentPlayer.playerUnit.armor.currentArmor = newArmor;
        gameEngine.currentPlayer.playerUnit.health.currentHp = newHealth;
        gameEngine.currentPlayer.playerUnit.fuel.currentFuel = newFuel;
        gameEngine.currentPlayer.playerUnit.range.range = newRange;
        //gameEngine.SelectNext();
    }
}
