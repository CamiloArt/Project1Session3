using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectConsumables : MonoBehaviour {

    //--PUBLIC VARIABLES--//
    public SelectVehicle selectVehicle;
    public ApplyValues applyValues;

    [Tooltip("Mines:[0], Grenades:[1], Caltrops[2]")]
    public GameObject[] muscleCar_Consumables;
    [Tooltip("Mines:[0], Grenades:[1], Caltrops[2]")]
    public GameObject[] buggy_Consumables;
    [Tooltip("Mines:[0], Grenades:[1], Caltrops[2]")]
    public GameObject[] monsterTruck_Consumables;

    public Dropdown dropdownCS;

    public float dps;

	void Start() 
    {
		
	}

	void Update() 
    {
		
	}

    //Mines
    public void Option0()
    {
        if (dropdownCS.value == 0)
        {
            if (applyValues.muscleCar_LookAt)
            {
                muscleCar_Consumables[0].SetActive(true);
                muscleCar_Consumables[1].SetActive(false);
                muscleCar_Consumables[2].SetActive(false);

                dps = 0.2f;
            }
            if (applyValues.buggy_LookAt)
            {
                buggy_Consumables[0].SetActive(true);
                buggy_Consumables[1].SetActive(false);
                buggy_Consumables[2].SetActive(false);

                dps = 0.2f;
            }
            if (applyValues.monsterTruck_LookAt)
            {
                monsterTruck_Consumables[0].SetActive(true);
                monsterTruck_Consumables[1].SetActive(false);
                monsterTruck_Consumables[2].SetActive(false);

                dps = 0.2f;
            }
        }
    }
    //Grenades
    public void Option1()
    {
        if (dropdownCS.value == 1)
        {
            if (applyValues.muscleCar_LookAt)
            {
                muscleCar_Consumables[0].SetActive(false);
                muscleCar_Consumables[1].SetActive(true);
                muscleCar_Consumables[2].SetActive(false);

                dps = 0.5f;
            }
            if (applyValues.buggy_LookAt)
            {
                buggy_Consumables[0].SetActive(false);
                buggy_Consumables[1].SetActive(true);
                buggy_Consumables[2].SetActive(false);

                dps = 0.5f;
            }
            if (applyValues.monsterTruck_LookAt)
            {
                monsterTruck_Consumables[0].SetActive(false);
                monsterTruck_Consumables[1].SetActive(true);
                monsterTruck_Consumables[2].SetActive(false);

                dps = 0.5f;
            }
        }
    }
    //Caltrops
    public void Option2()
    {
        if (dropdownCS.value == 2)
        {
            if (applyValues.muscleCar_LookAt)
            {
                muscleCar_Consumables[0].SetActive(false);
                muscleCar_Consumables[1].SetActive(false);
                muscleCar_Consumables[2].SetActive(true);

                dps = 0.7f;
            }
            if (applyValues.buggy_LookAt)
            {
                buggy_Consumables[0].SetActive(false);
                buggy_Consumables[1].SetActive(false);
                buggy_Consumables[2].SetActive(true);

                dps = 0.7f;
            }
            if (applyValues.monsterTruck_LookAt)
            {
                monsterTruck_Consumables[0].SetActive(false);
                monsterTruck_Consumables[1].SetActive(false);
                monsterTruck_Consumables[2].SetActive(true);

                dps = 0.7f;
            }
        }
    }
}