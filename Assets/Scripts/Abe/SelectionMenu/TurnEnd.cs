using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEnd : MonoBehaviour {

    public GameEngine gameEngine;
    public ApplyValues applyValues;
    public SelectVehicle selectVehicle;
    public ParentPlatform parentPlatform;
    public WeaponSelect weaponSelect;

    public bool lastPlayerTurnEnd = false;

    void Update()
    {
        if (gameEngine.playerTurnNum == 10) //last player has clicked "Ready"
        {
            lastPlayerTurnEnd = true;
        }
    }

    public void ResetSelectionMenu()
    {
        selectVehicle.selected = false;
        weaponSelect.ResetWeaponSelection();
    }
}
