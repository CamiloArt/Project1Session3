using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour {
    public GameEngine gameEngine;
    public TurnEnd turnEnd;
    public LoadingBar loadingBar; //access LoadingBar in LoadingScreen GameObject
    [Tooltip("LoadingScreen = [0], SelectionMenu = [1], StrategyMap = [2], BattleMap = [3]")]
    public GameObject[] Scenes;

	void Awake() 
    {
		
	}

	void Update() 
    {       
        if (turnEnd.lastPlayerTurnEnd) //if last player clicks on "ReadyBtn", load LoadingScreen
        {
            LoadTo_LoadingScreen();
        }
        if (loadingBar.loaded) //if LoadingScreen is done loading, load level
        {
            //*from which scene is LoadingScreen loading from?*
            LoadTo_StrategyMap();
        }
	}

    public void LoadTo_LoadingScreen()
    {
        Scenes[0].SetActive(true);
        Scenes[1].SetActive(false);
        Scenes[2].SetActive(false);
        //[3](false);
    }

    public void LoadTo_SelectionMenu()
    {
        Scenes[0].SetActive(false);
        Scenes[1].SetActive(true);
        Scenes[2].SetActive(false);
        //[3](false);
    }

    public void LoadTo_StrategyMap()
    {
        Scenes[0].SetActive(false);
        Scenes[1].SetActive(false);
        Scenes[2].SetActive(true);
        //[3](false);
    }

    public void LoadTo_BattleMap()
    {
        Scenes[0].SetActive(false);
        Scenes[1].SetActive(false);
        Scenes[2].SetActive(false);
        //[3](true);
    }
}
