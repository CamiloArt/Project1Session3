using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour {

    public GameObject targetRect;

    public Image carIdle;
    public Image carMoving;

    public bool loaded = false;

    public float progress;

    private float speed = 0.1f;
    private float minValue = 0f;
    private float maxValue = 1f;

    static float t = 0f;

	void Start() 
    {
        carIdle.enabled = true;
        carMoving.enabled = false;
	}

	void Update()
    {
        progress = Mathf.Lerp(minValue, maxValue, t);

        t += Time.deltaTime * speed;

        if (progress > 0.2f)
        {
            carIdle.enabled = false;
            carMoving.enabled = true;
            LerpPos();
        }

        if (progress >= 1f)
        {
            //move to next scene
            loaded = true;
        }
	}

    void LerpPos()
    {
        carMoving.transform.position = Vector3.MoveTowards(carMoving.transform.position, targetRect.transform.position, Time.deltaTime * 15);
    }
}
