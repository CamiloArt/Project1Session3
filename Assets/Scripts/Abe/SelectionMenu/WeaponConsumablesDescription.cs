using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponConsumablesDescription : MonoBehaviour {

    public SelectWeapon selectWeapon;
    public SelectConsumables selectConsumables;

    public Text descriptionText;

	void Update() 
    {
        //Minigun
        if (selectWeapon.dropdownWS.value == 0)
        {
            descriptionText.text = "da ting goes skrra";
        }
        //Rocket Launcher
        if (selectWeapon.dropdownWS.value == 1)
        {
            descriptionText.text = "makes your enemies go BOOM!... splat";
        }
        //Flamethrowers
        if (selectWeapon.dropdownWS.value == 2)
        {
            descriptionText.text = "the result of camilo dropping his mixtape";
        }
	}
}
