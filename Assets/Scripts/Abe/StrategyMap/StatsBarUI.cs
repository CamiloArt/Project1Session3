using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsBarUI : MonoBehaviour {

    public GameEngine gameEngine;
    public StrategyUIValues strategyUIValues;
    [Tooltip("HP = [0], AR = [1], DM = [2], SP = [3], FU = [4]")]
    public RectTransform[] statsBar;
    [Tooltip("HP = [0], AR = [1], DM = [2], SP = [3], FU = [4]")]
    public Image[] imageBars;
    [Tooltip("HP = [0], AR = [1], DM = [2], SP = [3], FU = [4]")]
    public Text[] statTxtValues;

	void Start(){
		if (strategyUIValues.redTeam)
		{
			imageBars[0].color = new Color32(0x69, 0x02, 0x02, 0xFF);
			imageBars[1].color = new Color32(0x69, 0x02, 0x02, 0xFF);
			imageBars[2].color = new Color32(0x69, 0x02, 0x02, 0xFF);
			imageBars[3].color = new Color32(0x69, 0x02, 0x02, 0xFF);
			imageBars[4].color = new Color32(0x69, 0x02, 0x02, 0xFF);
		}
		if (strategyUIValues.blueTeam)
		{
			imageBars[0].color = new Color32(0x00, 0x37, 0xFF, 0xFF);
			imageBars[1].color = new Color32(0x00, 0x37, 0xFF, 0xFF);
			imageBars[2].color = new Color32(0x00, 0x37, 0xFF, 0xFF);
			imageBars[3].color = new Color32(0x00, 0x37, 0xFF, 0xFF);
			imageBars[4].color = new Color32(0x00, 0x37, 0xFF, 0xFF);
		}
	}

    void Update()
    {
        //HP
        statsBar[0].transform.localScale = new Vector3((gameEngine.currentPlayer.playerUnit.health.currentHp / gameEngine.currentPlayer.playerUnit.health.maxHp), 1, 1);
        statTxtValues[0].text = gameEngine.currentPlayer.playerUnit.health.currentHp.ToString() + "/10";
        //AR
        statsBar[1].transform.localScale = new Vector3((gameEngine.currentPlayer.playerUnit.armor.currentArmor / gameEngine.currentPlayer.playerUnit.armor.maxArmor), 1, 1);
        statTxtValues[1].text = gameEngine.currentPlayer.playerUnit.armor.currentArmor.ToString() + "/10";
        //DM
        statsBar[2].transform.localScale = new Vector3((gameEngine.currentPlayer.playerUnit.damage / 10f), 1, 1);
        statTxtValues[2].text = gameEngine.currentPlayer.playerUnit.damage.ToString() + "/10";
        //SP
        statsBar[3].transform.localScale = new Vector3((gameEngine.currentPlayer.playerUnit.speed.maxSpeed / 50f), 1, 1);
        statTxtValues[3].text = gameEngine.currentPlayer.playerUnit.speed.maxSpeed.ToString() + "/50";
        //FU
        statsBar[4].transform.localScale = new Vector3((gameEngine.currentPlayer.playerUnit.fuel.fuelConsumption / gameEngine.currentPlayer.playerUnit.fuel.maxFuel), 1, 1);
        statTxtValues[4].text = gameEngine.currentPlayer.playerUnit.fuel.fuelConsumption.ToString() + "/10";
    }
}
