using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCamera : MonoBehaviour 
{
    private GameEngine gameEngine;
	private Vector3 Player01, Player02;
	public Transform firstPosition;
    public Camera battleCamera;
	public float minDistance, maxDistance, resetFocus;
   	
	void Start () 
    {
		gameEngine = GameObject.FindGameObjectWithTag("GameEngine").GetComponent<GameEngine>();
	}
	
	// Update is called once per frame
	void Update()
    {
		if (gameEngine.gameState == "battlemap") {
			if (gameEngine.inBattle) {
				PlayerTarget ();
				DynamicCamera ();
			}
		} else {
			ResetCamera ();
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
        float distance = Vector3.Distance(Player01,Player02);
        Vector3 myPos = new Vector3(midPoint.x,0,midPoint.z);
        gameObject.transform.position = myPos;

        if (distance > minDistance && distance < maxDistance)

        battleCamera.fieldOfView = distance*1.5f;
    }
	void ResetCamera(){
		battleCamera.fieldOfView = resetFocus;
		gameObject.transform.position = firstPosition.position;
	}
}

