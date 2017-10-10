using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponConsumablesDescription : MonoBehaviour {

    public SelectWeapon selectWeapon;
    public SelectConsumables selectConsumables;

    public Text descriptionText;
    //Weapons
    [TextArea(3,10)]
    public string minigunDescription;
    [TextArea(3,10)]
    public string rocketLauncherDescription;
    [TextArea(3,10)]
    public string flamethrowerDescription;
    //Consumables
    [TextArea(3,10)]
    public string minesDescription;
    [TextArea(3,10)]
    public string grenadesDescription;
    [TextArea(3,10)]
    public string caltropsDescription;

	void Update() 
    {
        //Weapons
        //Minigun
        if (selectWeapon.dropdownWS.value == 0)
        {
            descriptionText.text = minigunDescription;
        }
        //Rocket Launcher
        if (selectWeapon.dropdownWS.value == 1)
        {
            descriptionText.text = rocketLauncherDescription;
        }
        //Flamethrowers
        if (selectWeapon.dropdownWS.value == 2)
        {
            descriptionText.text = flamethrowerDescription;
        }
        //Consumables
        //Mines
        if (selectConsumables.dropdownCS.value == 0)
        {
            descriptionText.text = minesDescription;
        }
        //Grenades
        if (selectConsumables.dropdownCS.value == 1)
        {
            descriptionText.text = grenadesDescription;
        }
        //Caltrops
        if (selectConsumables.dropdownCS.value == 2)
        {
            descriptionText.text = caltropsDescription;
        }
	}
}
