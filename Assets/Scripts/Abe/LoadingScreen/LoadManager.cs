using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour {
    
    public GameEngine gameEngine;
    public TurnEnd turnEnd;
    public LoadingBar loadingBar; //access LoadingBar in LoadingScreen GameObject
    [Tooltip("StartMenu = [0], LoadingScreen = [1], SelectionMenu = [2], StrategyMap = [3], BattleMap = [4]")]
    public GameObject[] Scenes;

    public bool loadToSelectionMenu = false;
    public bool loadToStrategyMap = false;
    public bool loadToBattleMap = false;

	void Update() 
    {
        if (loadToSelectionMenu)
        {
            Load_LoadingScreen();
            if (loadingBar.loaded)
            {
                SelectionMenu();
                loadingBar.loaded = false;
            }
        }
        if (loadToStrategyMap)
        {
            Load_LoadingScreen();
            if (loadingBar.loaded)
            {
                StrategyMap();
                loadingBar.loaded = false;
            }
        }
        if (loadToBattleMap)
        {
            Load_LoadingScreen();
            if(loadingBar.loaded)
            {
                BattleMap();
                loadingBar.loaded = false;
            }
        }
	}
    //
    private void Load_LoadingScreen()
    {
        Scenes[0].SetActive(false);
        Scenes[1].SetActive(true);
        Scenes[2].SetActive(false);
        Scenes[3].SetActive(false);
        //[3](false)
    }

    private void SelectionMenu()
    {
        Scenes[0].SetActive(false);
        Scenes[1].SetActive(false);
        Scenes[2].SetActive(true);
        Scenes[3].SetActive(false);
        loadToSelectionMenu = false;
        //[3](false);
    }
    public void LoadTo_SelectionMenu()
    {
        loadToSelectionMenu = true;
    }

    private void StrategyMap()
    {
        Scenes[0].SetActive(false);
        Scenes[1].SetActive(false);
        Scenes[2].SetActive(false);
        Scenes[3].SetActive(true);
        loadToStrategyMap = false;
        gameEngine.gameState = "strategyMap";
        //[3](false);
    }
    public void LoadTo_StrategyMap()
    {
        loadToStrategyMap = true;
    }

    private void BattleMap()
    {
        Scenes[0].SetActive(false);
        Scenes[1].SetActive(false);
        Scenes[2].SetActive(false);
        Scenes[4].SetActive(false);
        loadToBattleMap = false;
        //[3](true);
    }
    public void LoadTo_BattleMap()
    {
        loadToBattleMap = true;
    }
}
