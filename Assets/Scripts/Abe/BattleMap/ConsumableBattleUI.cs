using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableBattleUI : MonoBehaviour {

    public GameEngine gameEngine;

    public GameObject BattleUI;

    void Start()
    {
        BattleUI.SetActive(false);
    }

	void Update() 
    {
        if (gameEngine.gameState == "battlemap")
        {
            BattleUI.SetActive(true);
        }
        else
        {
            BattleUI.SetActive(false);
        }
	}
}
