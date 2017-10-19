using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrategyUIValues : MonoBehaviour {

    public GameEngine gameEngine;

    public GameObject strategyUI;
    public GameObject redStats;
    public GameObject blueStats;

    public bool redTeam;
    public bool blueTeam;

    public Text currentPlayerText;
	
	void Update() 
    {
        RunUI();
	}

    void RedTeamTurn()
    {
        if (gameEngine.playerTurnNum == 3)
        {
            redTeam = true;
            blueTeam = false;

            currentPlayerText.text = "Red Leader";
            currentPlayerText.color = new Color32(0x69, 0x02, 0x02, 0xFF);

            redStats.SetActive(true);
            blueStats.SetActive(false);
        }
        //bodyguards
        if (gameEngine.playerTurnNum == 1 
            || gameEngine.playerTurnNum == 5 
            || gameEngine.playerTurnNum == 7
            || gameEngine.playerTurnNum == 9)
        {
            redTeam = true;
            blueTeam = false;

            currentPlayerText.text = "Player: " + gameEngine.playerTurnNum.ToString();
            currentPlayerText.color = new Color32(0x69, 0x02, 0x02, 0xFF);

            redStats.SetActive(true);
            blueStats.SetActive(false);
        }
    }

    void BlueTeamTurn()
    {
        if (gameEngine.playerTurnNum == 4)
        {
            redTeam = false;
            blueTeam = true;

            currentPlayerText.text = "Blue Leader";
            currentPlayerText.color = new Color32(0x00, 0x37, 0xFF, 0xFF);

            redStats.SetActive(false);
            blueStats.SetActive(true);
        }
        //bodyguards
        if (gameEngine.playerTurnNum == 2 
            || gameEngine.playerTurnNum == 6 
            || gameEngine.playerTurnNum == 8
            || gameEngine.playerTurnNum == 10)
        {
            redTeam = false;
            blueTeam = true;

            currentPlayerText.text = "Player: " + gameEngine.playerTurnNum.ToString();
            currentPlayerText.color = new Color32(0x00, 0x37, 0xFF, 0xFF);

            redStats.SetActive(false);
            blueStats.SetActive(true);
        }
    }

    void RunUI()
    {
        if (gameEngine.gameState == "strategyMap")
        {
            strategyUI.SetActive(true);
            RedTeamTurn();
            BlueTeamTurn();
        }
        else
        {
            strategyUI.SetActive(false);
            redStats.SetActive(false);
            blueStats.SetActive(false);
        }
    }
}
