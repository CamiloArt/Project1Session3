using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelBarUI : MonoBehaviour {

    public GameEngine gameEngine;

    void Update()
    {
        transform.localScale = new Vector3((gameEngine.currentPlayer.playerUnit.fuel.currentFuel / gameEngine.currentPlayer.playerUnit.fuel.maxFuel), 1, 1);
    }
}
