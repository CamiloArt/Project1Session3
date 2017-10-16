using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyStart : MonoBehaviour {

    public ApplyValues applyValues;
    public TurnEnd turnEnd;
    public SelectWeapon selecWeapon;

    public Image bloodDecal;

    void Start()
    {
        bloodDecal.enabled = false;
    }

	void Update() 
    {
        if (Input.GetKey(KeyCode.E) || Input.GetButton("X360_Start"))
        {
            bloodDecal.enabled = true;
        }
        else
        {
            bloodDecal.enabled = false;
        }

        if (Input.GetKeyUp(KeyCode.E) || Input.GetButtonUp("X360_Start"))
        {
            applyValues.ApplyUnitValues();
            turnEnd.ResetSelectionMenu();
        }
	}
}
