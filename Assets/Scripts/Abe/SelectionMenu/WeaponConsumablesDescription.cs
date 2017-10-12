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
        if (selectWeapon.currentValueW[0] == true)
        {
            descriptionText.text = minigunDescription;
        }
        //Rocket Launcher
        if (selectWeapon.currentValueW[1] == true)
        {
            descriptionText.text = rocketLauncherDescription;
        }
        //Flamethrowers
        if (selectWeapon.currentValueW[2] == true)
        {
            descriptionText.text = flamethrowerDescription;
        }
        //Consumables
        //Mines
        if (selectConsumables.currentValueC[0] == true)
        {
            descriptionText.text = minesDescription;
        }
        //Grenades
        if (selectConsumables.currentValueC[1] == true)
        {
            descriptionText.text = grenadesDescription;
        }
        //Caltrops
        if (selectConsumables.currentValueC[2] == true)
        {
            descriptionText.text = caltropsDescription;
        }
	}
}
