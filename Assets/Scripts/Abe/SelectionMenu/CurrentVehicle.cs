using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentVehicle : MonoBehaviour {

    public ApplyValues applyValues;

    public Text updatedText;

    void Update()
    {
        print(updatedText.color);
    }

	void LateUpdate() 
    {
        if (applyValues.muscleCar_LookAt)
        {
            updatedText.text = "The Muscular Tin Can";
            updatedText.color = new Color32(0x7A, 0x27, 0x27, 0xFF);
        }
        if (applyValues.buggy_LookAt)
        {
            updatedText.text = "Le Buggy";
            updatedText.color = new Color32(0x3C, 0x58, 0x20, 0xFF);
        }
        if (applyValues.monsterTruck_LookAt)
        {
            updatedText.text = "MONSTER X O.V.E.R 9000";
            updatedText.color = new Color(0x42, 0x00, 0x3A, 0xFF);
        }
	}
}
