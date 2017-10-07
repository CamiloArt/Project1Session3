using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWeapon : MonoBehaviour {
	//if selected = true, enable selection for weapon and consumables
	//--PUBLIC VARIABLES--//
	public SelectVehicle selectVehicle;
	public ApplyValues applyValues;

	[Tooltip("Minigun:[0], RocketLauncher:[1], Flamethrower[2]")]
	public GameObject[] muscleCar_Weapons;
	[Tooltip("Minigun:[0], RocketLauncher:[1], Flamethrower[2]")]
	public GameObject[] buggy_Weapons;
	[Tooltip("Minigun:[0], RocketLauncher:[1], Flamethrower[2]")]
	public GameObject[] monsterTruck_Weapons;

	public Dropdown dropdownWS;

    public float dps;

	void Start() 
    {
		
	}
   
	void Update() 
    {
		
	}

	//Minigun
	public void Option0()
	{
		if (dropdownWS.value == 0)
		{
			if (applyValues.muscleCar_LookAt)
			{
				muscleCar_Weapons[0].SetActive(true);
				muscleCar_Weapons[1].SetActive(false);
				muscleCar_Weapons[2].SetActive(false);

                dps = 0.2f;
			}
			if (applyValues.buggy_LookAt)
			{
				buggy_Weapons[0].SetActive(true);
				buggy_Weapons[1].SetActive(false);
				buggy_Weapons[2].SetActive(false);

                dps = 0.2f;
			}
			if (applyValues.monsterTruck_LookAt)
			{
				monsterTruck_Weapons[0].SetActive(true);
				monsterTruck_Weapons[1].SetActive(false);
				monsterTruck_Weapons[2].SetActive(false);

                dps = 0.2f;
			}
		}
	}
	//Rocket Launcher
	public void Option1()
	{
		if (dropdownWS.value == 1)
		{
			if (applyValues.muscleCar_LookAt)
			{
				muscleCar_Weapons[0].SetActive(false);
				muscleCar_Weapons[1].SetActive(true);
				muscleCar_Weapons[2].SetActive(false);

                dps = 0.5f;
			}
			if (applyValues.buggy_LookAt)
			{
				buggy_Weapons[0].SetActive(false);
				buggy_Weapons[1].SetActive(true);
				buggy_Weapons[2].SetActive(false);

                dps = 0.5f;
			}
			if (applyValues.monsterTruck_LookAt)
			{
				monsterTruck_Weapons[0].SetActive(false);
				monsterTruck_Weapons[1].SetActive(true);
				monsterTruck_Weapons[2].SetActive(false);

                dps = 0.5f;
			}
		}
	}
	//Flamethrower
	public void Option2()
	{
		if (dropdownWS.value == 2)
		{
			if (applyValues.muscleCar_LookAt)
			{
				muscleCar_Weapons[0].SetActive(false);
				muscleCar_Weapons[1].SetActive(false);
				muscleCar_Weapons[2].SetActive(true);

                dps = 0.7f;
			}
			if (applyValues.buggy_LookAt)
			{
				buggy_Weapons[0].SetActive(false);
				buggy_Weapons[1].SetActive(false);
				buggy_Weapons[2].SetActive(true);

                dps = 0.7f;
			}
			if (applyValues.monsterTruck_LookAt)
			{
				monsterTruck_Weapons[0].SetActive(false);
				monsterTruck_Weapons[1].SetActive(false);
				monsterTruck_Weapons[2].SetActive(true);

                dps = 0.7f;
			}
		}
	}

    public void ResetWeaponSelection()
    {
        muscleCar_Weapons[0].SetActive(false);
        muscleCar_Weapons[1].SetActive(false);
        muscleCar_Weapons[2].SetActive(false);

        buggy_Weapons[0].SetActive(false);
        buggy_Weapons[1].SetActive(false);
        buggy_Weapons[2].SetActive(false);

        monsterTruck_Weapons[0].SetActive(false);
        monsterTruck_Weapons[1].SetActive(false);
        monsterTruck_Weapons[2].SetActive(false);
    }
}
