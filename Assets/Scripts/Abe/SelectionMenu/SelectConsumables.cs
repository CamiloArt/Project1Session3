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
    [Tooltip("Mines:[0], Grenades:[1], Caltrops[2]")]
    public bool[] currentValueC;

    public bool nothingSelectedC = true;
    public Text nothingSelectedCTxt;

    public GameObject currentSelectedConsumable;

    public Text dpsCText;

    public float dps;

    public int consumablesSelectIndex; //Mines:[0], Grenades:[1], Caltrops[2]

    void Update()
    {
        NothingSelectedC();
    }

    //Mines
    public void Option0()
    {
        consumablesSelectIndex = 0;
        if (applyValues.muscleCar_LookAt)
        {
            currentValueC[0] = true;
            currentValueC[1] = false;
            currentValueC[2] = false;

            currentSelectedConsumable = muscleCar_Consumables[0];

            muscleCar_Consumables[0].SetActive(true);
            muscleCar_Consumables[1].SetActive(false);
            muscleCar_Consumables[2].SetActive(false);

            dps = 0.2f;
            dpsCText.text = "Mines Damage: " + dps.ToString();
        }
        if (applyValues.buggy_LookAt)
        {
            currentValueC[0] = true;
            currentValueC[1] = false;
            currentValueC[2] = false;

            currentSelectedConsumable = buggy_Consumables[0];

            buggy_Consumables[0].SetActive(true);
            buggy_Consumables[1].SetActive(false);
            buggy_Consumables[2].SetActive(false);

            dps = 0.2f;
            dpsCText.text = "Mines Damage: " + dps.ToString();
        }
        if (applyValues.monsterTruck_LookAt)
        {
            currentValueC[0] = true;
            currentValueC[1] = false;
            currentValueC[2] = false;

            currentSelectedConsumable = monsterTruck_Consumables[0];

            monsterTruck_Consumables[0].SetActive(true);
            monsterTruck_Consumables[1].SetActive(false);
            monsterTruck_Consumables[2].SetActive(false);

            dps = 0.2f;
            dpsCText.text = "Mines Damage: " + dps.ToString();
        }
    }
    //Grenades
    public void Option1()
    {
        consumablesSelectIndex = 1;
        if (applyValues.muscleCar_LookAt)
        {
            currentValueC[0] = false;
            currentValueC[1] = true;
            currentValueC[2] = false;

            currentSelectedConsumable = muscleCar_Consumables[1];

            muscleCar_Consumables[0].SetActive(false);
            muscleCar_Consumables[1].SetActive(true);
            muscleCar_Consumables[2].SetActive(false);

            dps = 0.5f;
            dpsCText.text = "Grenades Damage: " + dps.ToString();
        }
        if (applyValues.buggy_LookAt)
        {
            currentValueC[0] = false;
            currentValueC[1] = true;
            currentValueC[2] = false;

            currentSelectedConsumable = buggy_Consumables[1];

            buggy_Consumables[0].SetActive(false);
            buggy_Consumables[1].SetActive(true);
            buggy_Consumables[2].SetActive(false);

            dps = 0.5f;
            dpsCText.text = "Grenades Damage: " + dps.ToString();
        }
        if (applyValues.monsterTruck_LookAt)
        {
            currentValueC[0] = false;
            currentValueC[1] = true;
            currentValueC[2] = false;

            currentSelectedConsumable = monsterTruck_Consumables[1];

            monsterTruck_Consumables[0].SetActive(false);
            monsterTruck_Consumables[1].SetActive(true);
            monsterTruck_Consumables[2].SetActive(false);

            dps = 0.5f;
            dpsCText.text = "Grenades Damage: " + dps.ToString();
        }
    }
    //Caltrops
    public void Option2()
    {
        consumablesSelectIndex = 2;
        if (applyValues.muscleCar_LookAt)
        {
            currentValueC[0] = false;
            currentValueC[1] = false;
            currentValueC[2] = true;

            currentSelectedConsumable = muscleCar_Consumables[2];

            muscleCar_Consumables[0].SetActive(false);
            muscleCar_Consumables[1].SetActive(false);
            muscleCar_Consumables[2].SetActive(true);

            dps = 0.7f;
            dpsCText.text = "Caltrops Damage: " + dps.ToString();
        }
        if (applyValues.buggy_LookAt)
        {
            currentValueC[0] = false;
            currentValueC[1] = false;
            currentValueC[2] = true;

            currentSelectedConsumable = buggy_Consumables[1];

            buggy_Consumables[0].SetActive(false);
            buggy_Consumables[1].SetActive(false);
            buggy_Consumables[2].SetActive(true);

            dps = 0.7f;
            dpsCText.text = "Caltrops Damage: " + dps.ToString();
        }
        if (applyValues.monsterTruck_LookAt)
        {
            currentValueC[0] = false;
            currentValueC[1] = false;
            currentValueC[2] = true;

            monsterTruck_Consumables[0].SetActive(false);
            monsterTruck_Consumables[1].SetActive(false);
            monsterTruck_Consumables[2].SetActive(true);

            dps = 0.7f;
            dpsCText.text = "Caltrops Damage: " + dps.ToString();
        }
    }

    public void ResetConsumablesSelection()
    {
        muscleCar_Consumables[0].SetActive(false);
        muscleCar_Consumables[1].SetActive(false);
        muscleCar_Consumables[2].SetActive(false);

        buggy_Consumables[0].SetActive(false);
        buggy_Consumables[1].SetActive(false);
        buggy_Consumables[2].SetActive(false);

        monsterTruck_Consumables[0].SetActive(false);
        monsterTruck_Consumables[1].SetActive(false);
        monsterTruck_Consumables[2].SetActive(false);
    }

    void NothingSelectedC()
    {
        if (nothingSelectedC)
        {
            nothingSelectedCTxt.enabled = true;
            nothingSelectedCTxt.text = "select a consumable";
        }
        if (!nothingSelectedC)
        {
            nothingSelectedCTxt.enabled = false;
        }
    }
}