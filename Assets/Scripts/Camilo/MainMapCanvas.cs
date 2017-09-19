using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class MainMapCanvas : MonoBehaviour {
	public Text counter;
	private GameEngine gameEngine;
	// Use this for initialization
	void Start () {
		gameEngine = GameObject.FindGameObjectWithTag ("GameEngine").GetComponent<GameEngine> ();
	}
	
	// Update is called once per frame
	void Update () {
		counter.text = Mathf.Round(gameEngine.timeCounter).ToString();
	}
}
