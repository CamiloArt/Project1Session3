using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEnd : MonoBehaviour {

    public GameEngine gameEngine;
    public ApplyValues applyValues;
    public SelectVehicle selectVehicle;
    public ParentPlatform parentPlatform;
    public SelectWeapon selectWeapon;
    public LoadManager loadManager;
    [Tooltip("Assign from *TimerSelectionMenu*")]
    public TimerCountdown timerCountdown;
    void Awake(){
        gameEngine = GameObject.FindGameObjectWithTag ("GameEngine").GetComponent<GameEngine> ();
    }
    void Update()
    {
        if (timerCountdown.timeLeft <= 0f) 
        {
            AutoSelectVehicle();
        }
    }

    public void ResetSelectionMenu()
    {
        selectVehicle.selected = false;
        selectWeapon.ResetWeaponSelection();
    }

    void AutoSelectVehicle()
    {
        //if time has run out for turn selected = false + selectWeapon = false
        ResetSelectionMenu();
        //apply unit values to GameEngine
        applyValues.ApplyUnitValues();
    }
}
