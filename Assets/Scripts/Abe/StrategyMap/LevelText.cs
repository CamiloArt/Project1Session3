using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour {

    public GameEngine gameEngine;

    public Text levelTxt;

	void Update() 
    {
        levelTxt.text = "Level " + gameEngine.currentPlayer.myLvl.myLevel.ToString();
	}
}
