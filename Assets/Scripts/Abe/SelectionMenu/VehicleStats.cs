using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehicleStats : MonoBehaviour {
    //--PUBLIC VARIABLES--//
    [Tooltip("Damage:[0], Speed:[1], Armor:[2], Health:[3], Fuel:[4]")]
    public StatsBar[] statsBar;
	[Tooltip("Damage:[0], Speed:[1], Armor:[2], Health:[3], Fuel:[4]")]
	public Text[] statsNum;

    public ApplyValues applyValues;
	public SelectVehicle selectVehicle;
    //--PRIVATE VARIABLES--//

    void Update()
    {
        if (selectVehicle.selected)
        {
            statsBar[0].progress = applyValues.newDamage / 10;
            statsBar[1].progress = applyValues.newSpeed / 10;
            statsBar[2].progress = applyValues.newArmor / 10;
            statsBar[3].progress = applyValues.newHealth / 10;
            statsBar[4].progress = applyValues.newFuel / 10;

			statsNum[0].text = applyValues.newDamage.ToString() + "/10";
			statsNum[1].text = applyValues.newSpeed.ToString() + "/10";
			statsNum[2].text = applyValues.newArmor.ToString() + "/10";
			statsNum[3].text = applyValues.newHealth.ToString() + "/10";
			statsNum[4].text = applyValues.newFuel.ToString() + "/10";
        }
    }
}
