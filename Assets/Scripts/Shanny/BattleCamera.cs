using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCamera : MonoBehaviour 
{
    private GameEngine gameEngine;
    private Vector3 Player01, Player02;
	
	void Start () 
    {
		gameEngine = GameObject.FindGameObjectWithTag("GameEngine").GetComponent<GameEngine>();
	}
	
	// Update is called once per frame
	void Update()
    {
        if (gameEngine.gameState == "battlemap")
        {
            if (!gameEngine.inBattle)
            {
                PlayerTarget();
            }
            else
            {
                DynamicCamera();
            }
        }
	}

    void PlayerTarget()
    {
        Player01 = gameEngine.players[gameEngine.currentPlayerIndex].gameObject.transform.position;
        Player02 = gameEngine.players[gameEngine.playerInRangeIndex].gameObject.transform.position;
    }

    void DynamicCamera()
    {
    Vector3 midPoint= (Player01 + Player02) / 2;
    }
}

