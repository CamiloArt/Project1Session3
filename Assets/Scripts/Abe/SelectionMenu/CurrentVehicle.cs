using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentVehicle : MonoBehaviour {

    public ApplyValues applyValues;

    public Text updatedText;

	void LateUpdate() 
    {
        if (applyValues.muscleCar_LookAt)
        {
            updatedText.text = "The Muscular Tin Can";
            updatedText.color = Color.green;
        }
        if (applyValues.buggy_LookAt)
        {
            updatedText.text = "Le Buggy";
            updatedText.color = Color.green;
        }
        if (applyValues.monsterTruck_LookAt)
        {
            updatedText.text = "MONSTER X O.V.E.R 9000";
            updatedText.color = Color.green;
        }
	}
}
