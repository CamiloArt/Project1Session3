using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehicleStats : MonoBehaviour {
    //--PUBLIC VARIABLES--//
    public ApplyValues applyValues;
    public SelectVehicle selectVehicle;

    [Tooltip("Damage:[0], Speed:[1], Armor:[2], Health:[3], Fuel:[4]")]
    public StatsBar[] statsBar;
	[Tooltip("Damage:[0], Speed:[1], Armor:[2], Health:[3], Fuel:[4]")]
	public Text[] statsNum;

    void Update()
    {
        if (selectVehicle.selected)
        {
            statsBar[0].progress = applyValues.damage_new / 10;
            statsBar[1].progress = applyValues.minSpeed_new / 10;
            statsBar[2].progress = applyValues.initialArmor_new / 10;
            statsBar[3].progress = applyValues.initialHp_new / 10;
            statsBar[4].progress = applyValues.currentFuel_new / 10;

            statsNum[0].text = applyValues.damage_new.ToString() + "/10";
            statsNum[1].text = applyValues.minSpeed_new.ToString() + "/10";
            statsNum[2].text = applyValues.initialArmor_new.ToString() + "/10";
            statsNum[3].text = applyValues.initialHp_new.ToString() + "/10";
            statsNum[4].text = applyValues.currentFuel_new.ToString() + "/10";
        }
    }
}
