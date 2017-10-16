using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWeapon : MonoBehaviour {
	//if selected = true, enable selection for weapon and consumables
    //int vehicle index, int weapon index, int consumable index -- if muscle car selected car = index car = 0 -- gameEngine.... currenetIndex 
	//--PUBLIC VARIABLES--//
	public SelectVehicle selectVehicle;
	public ApplyValues applyValues;

	[Tooltip("MachineGun[0], Minigun:[1], RocketLauncher:[2], Flamethrower[3]")]
	public GameObject[] muscleCar_Weapons;
    [Tooltip("MachineGun[0], Minigun:[1], RocketLauncher:[2], Flamethrower[3]")]
	public GameObject[] buggy_Weapons;
    [Tooltip("MachineGun[0], Minigun:[1], RocketLauncher:[2], Flamethrower[3]")]
	public GameObject[] monsterTruck_Weapons;
    [Tooltip("MachineGun[0], Minigun:[1], RocketLauncher:[2], Flamethrower[3]")]
    public bool[] currentValueW;

    public bool nothingSelectedW = true;
    public Text nothingSelectedWTxt;

    public GameObject currentSelectedWeapon;

    public Text dpsWText;

    public float dps;

    public int weaponSelectIndex; //Minigun:[1], RocketLauncher:[2], Flamethrower[3]

    void Update()
    {
        NothingSelectedW();
    }

	//MachineGun
	public void Option0()
	{
		if (applyValues.muscleCar_LookAt)
		{
            currentValueW[0] = true;
            currentValueW[1] = false;
            currentValueW[2] = false;
            currentValueW[3] = false;

            currentSelectedWeapon = muscleCar_Weapons[0];

			muscleCar_Weapons[0].SetActive(true);
			muscleCar_Weapons[1].SetActive(false);
            muscleCar_Weapons[2].SetActive(false);
            muscleCar_Weapons[3].SetActive(false);

            dps = 0.2f;
            dpsWText.text = "Minigun Damage: " + dps.ToString();
		}
		if (applyValues.buggy_LookAt)
		{
            currentValueW[0] = true;
            currentValueW[1] = false;
            currentValueW[2] = false;
            currentValueW[3] = false;

            currentSelectedWeapon = buggy_Weapons[0];

			buggy_Weapons[0].SetActive(true);
			buggy_Weapons[1].SetActive(false);
			buggy_Weapons[2].SetActive(false);
            buggy_Weapons[3].SetActive(false);

            dps = 0.2f;
            dpsWText.text = "Minigun Damage: " + dps.ToString();
		}
		if (applyValues.monsterTruck_LookAt)
		{
            currentValueW[0] = true;
            currentValueW[1] = false;
            currentValueW[2] = false;
            currentValueW[3] = false;

            currentSelectedWeapon = monsterTruck_Weapons[0];

			monsterTruck_Weapons[0].SetActive(true);
			monsterTruck_Weapons[1].SetActive(false);
			monsterTruck_Weapons[2].SetActive(false);
            monsterTruck_Weapons[3].SetActive(false);

            dps = 0.2f;
            dpsWText.text = "Minigun Damage: " + dps.ToString();
	    }
	}
	//Minigun
	public void Option1()
	{
        weaponSelectIndex = 1;
        if (applyValues.muscleCar_LookAt)
        {
            currentValueW[0] = false;
            currentValueW[1] = true;
            currentValueW[2] = false;
            currentValueW[3] = false;

            currentSelectedWeapon = muscleCar_Weapons[1];

            muscleCar_Weapons[0].SetActive(false);
            muscleCar_Weapons[1].SetActive(true);
            muscleCar_Weapons[2].SetActive(false);
            muscleCar_Weapons[3].SetActive(false);

            dps = 0.5f;
            dpsWText.text = "Rocket Launcher Damage: " + dps.ToString();

            nothingSelectedW = false;
        }
		if (applyValues.buggy_LookAt)
		{
            currentValueW[0] = false;
            currentValueW[1] = true;
            currentValueW[2] = false;
            currentValueW[3] = false;

            currentSelectedWeapon = buggy_Weapons[1];

			buggy_Weapons[0].SetActive(false);
			buggy_Weapons[1].SetActive(true);
			buggy_Weapons[2].SetActive(false);
            buggy_Weapons[3].SetActive(false);

            dps = 0.5f;
            dpsWText.text = "Rocket Launcher Damage: " + dps.ToString();

            nothingSelectedW = false;
		}
		if (applyValues.monsterTruck_LookAt)
		{
            currentValueW[0] = false;
            currentValueW[1] = true;
            currentValueW[2] = false;
            currentValueW[3] = false;

            currentSelectedWeapon = monsterTruck_Weapons[1];

			monsterTruck_Weapons[0].SetActive(false);
			monsterTruck_Weapons[1].SetActive(true);
			monsterTruck_Weapons[2].SetActive(false);
            monsterTruck_Weapons[3].SetActive(false);

            dps = 0.5f;
            dpsWText.text = "Rocket Launcher Damage: " + dps.ToString();

            nothingSelectedW = false;
		}
	}
    //Rocket Launcher
	public void Option2()
	{
        weaponSelectIndex = 2;
		if (applyValues.muscleCar_LookAt)
		{
            currentValueW[0] = false;
            currentValueW[1] = false;
            currentValueW[2] = true;
            currentValueW[3] = false;

            currentSelectedWeapon = muscleCar_Weapons[2];

			muscleCar_Weapons[0].SetActive(false);
			muscleCar_Weapons[1].SetActive(false);
			muscleCar_Weapons[2].SetActive(true);
            muscleCar_Weapons[3].SetActive(false);

            dps = 0.7f;
            dpsWText.text = "Flamethrower Damage: " + dps.ToString();

            nothingSelectedW = false;
		}
        if (applyValues.buggy_LookAt)
        {
            currentValueW[0] = false;
            currentValueW[1] = false;
            currentValueW[2] = true;
            currentValueW[3] = false;

            currentSelectedWeapon = buggy_Weapons[2];

            buggy_Weapons[0].SetActive(false);
            buggy_Weapons[1].SetActive(false);
            buggy_Weapons[2].SetActive(true);
            buggy_Weapons[3].SetActive(false);

            dps = 0.7f;
            dpsWText.text = "Flamethrower Damage: " + dps.ToString();

            nothingSelectedW = false;
        }
        if (applyValues.monsterTruck_LookAt)
        {
            currentValueW[0] = false;
            currentValueW[1] = false;
            currentValueW[2] = true;
            currentValueW[3] = false;

            currentSelectedWeapon = monsterTruck_Weapons[2];

            monsterTruck_Weapons[0].SetActive(false);
            monsterTruck_Weapons[1].SetActive(false);
            monsterTruck_Weapons[2].SetActive(true);
            monsterTruck_Weapons[3].SetActive(false);

            dps = 0.7f;
            dpsWText.text = "Flamethrower Damage: " + dps.ToString();

            nothingSelectedW = false;
        }
	}
    //Flamethrower
    public void Option3()
    {
        weaponSelectIndex = 3;
        if (applyValues.muscleCar_LookAt)
        {
            currentValueW[0] = false;
            currentValueW[1] = false;
            currentValueW[2] = false;
            currentValueW[3] = true;

            currentSelectedWeapon = muscleCar_Weapons[0];

            muscleCar_Weapons[0].SetActive(false);
            muscleCar_Weapons[1].SetActive(false);
            muscleCar_Weapons[2].SetActive(false);
            muscleCar_Weapons[3].SetActive(true);

            dps = 0.2f;
            dpsWText.text = "Mingun Damage: " + dps.ToString();

            nothingSelectedW = false;
        }
        if (applyValues.buggy_LookAt)
        {
            currentValueW[0] = false;
            currentValueW[1] = false;
            currentValueW[2] = false;
            currentValueW[3] = true;

            currentSelectedWeapon = buggy_Weapons[0];

            buggy_Weapons[0].SetActive(false);
            buggy_Weapons[1].SetActive(false);
            buggy_Weapons[2].SetActive(false);
            buggy_Weapons[3].SetActive(true);

            dps = 0.2f;
            dpsWText.text = "Minigun Damage: " + dps.ToString();

            nothingSelectedW = false;
        }
        if (applyValues.monsterTruck_LookAt)
        {
            currentValueW[0] = false;
            currentValueW[1] = false;
            currentValueW[2] = false;
            currentValueW[3] = true;

            currentSelectedWeapon = monsterTruck_Weapons[0];

            monsterTruck_Weapons[0].SetActive(false);
            monsterTruck_Weapons[1].SetActive(false);
            monsterTruck_Weapons[2].SetActive(false);
            monsterTruck_Weapons[3].SetActive(true);

            dps = 0.2f;
            dpsWText.text = "Minigun Damage: " + dps.ToString();

            nothingSelectedW = false;
        }
    }

    public void ResetWeaponSelection()
    {
        nothingSelectedW = true;

        muscleCar_Weapons[0].SetActive(false);
        muscleCar_Weapons[1].SetActive(false);
        muscleCar_Weapons[2].SetActive(false);
        muscleCar_Weapons[3].SetActive(false);

        buggy_Weapons[0].SetActive(false);
        buggy_Weapons[1].SetActive(false);
        buggy_Weapons[2].SetActive(false);
        buggy_Weapons[3].SetActive(false);

        monsterTruck_Weapons[0].SetActive(false);
        monsterTruck_Weapons[1].SetActive(false);
        monsterTruck_Weapons[2].SetActive(false);
        monsterTruck_Weapons[3].SetActive(false);
    }

    void NothingSelectedW()
    {
        if (nothingSelectedW)
        {
            nothingSelectedWTxt.enabled = true;
            nothingSelectedWTxt.text = "select a weapon";
        }
        if (!nothingSelectedW)
        {
            nothingSelectedWTxt.enabled = false;
        }
    }
}
