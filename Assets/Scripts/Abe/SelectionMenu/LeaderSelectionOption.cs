using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderSelectionOption : MonoBehaviour {

    public GameEngine gameEngine;
    public ApplyValues applyValues;
    public GameObject selectableUIElements;
    [Tooltip("MuscleCar = [0], Buggy = [1], MonsterTruck = [2]")]
    public GameObject[] leaderSkull;

	void Update() 
    {
        if (gameEngine.playerTurnNum == 1 || gameEngine.playerTurnNum == 6)
        {
            selectableUIElements.SetActive(false);
            if (applyValues.muscleCar_LookAt)
            {
                leaderSkull[0].SetActive(true);
            }
            if (applyValues.buggy_LookAt)
            {
                leaderSkull[1].SetActive(true);
            }
            if (applyValues.monsterTruck_LookAt)
            {
                leaderSkull[2].SetActive(true);
            }
        }
        else
        {
            selectableUIElements.SetActive(true);
            leaderSkull[0].SetActive(false);
            leaderSkull[1].SetActive(false);
            leaderSkull[2].SetActive(false);
        }
	}
}