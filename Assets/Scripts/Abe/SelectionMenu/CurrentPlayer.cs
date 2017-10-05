using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentPlayer : MonoBehaviour {

    public GameEngine gameEngine;
    public TurnEnd turnEnd;

    public Text currentPlayer;

	void Update() 
    {
        if (gameEngine.playerTurnNum == 1)
        {
            currentPlayer.text = "Leader 1";
        }
        if (gameEngine.playerTurnNum == 6)
        {
            currentPlayer.text = "Leader 2";
        }
        if (gameEngine.playerTurnNum < 6 || gameEngine.playerTurnNum > 6)
        {
            currentPlayer.text = "Player " + gameEngine.playerTurnNum.ToString();
        }
	}
}
