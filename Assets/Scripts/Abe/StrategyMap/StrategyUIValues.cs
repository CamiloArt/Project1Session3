using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrategyUIValues : MonoBehaviour {

    public GameEngine gameEngine;
    public Text time;

    private Text currentPlayerText;
	
	void Update() 
    {
        
	}

    void RedTeamTurn()
    {
        if (gameEngine.playerTurnNum == 1)
        {

        }
    }

    void BlueTeamTurn()
    {
        if (gameEngine.playerTurnNum == 6)
        {
            
        }
    }
}
