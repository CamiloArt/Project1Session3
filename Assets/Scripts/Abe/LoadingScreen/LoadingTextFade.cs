using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingTextFade : MonoBehaviour {

    public Text loadingText;

    public float alphaPingPong;

	void Start () 
    {
        alphaPingPong = 0f;
	}

	void Update () 
    {
        loadingText.CrossFadeAlpha(alphaPingPong, 1f, false);

        alphaPingPong = Mathf.PingPong(Time.time, 1.2f);
	}
}
