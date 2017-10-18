using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuTransition : MonoBehaviour {

    public Vector3 targetAngle = new Vector3(0f, -100f, 0f);
    public Vector3 currentAngle;

    public float speed = 0.1f;

    public bool transitionToCredits = false;
    public bool creditsActive = false;

    void Start()
    {
        currentAngle = transform.eulerAngles;
    }

	void Update () 
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("X360_HorizontalDPad") == 1f)//Right
        {
            transitionToCredits = true;
            if (transitionToCredits && !creditsActive)
            {
                creditsActive = true;
                currentAngle = new Vector3(
                    Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime),
                    Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime),
                    Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime));

                transform.eulerAngles = currentAngle;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("X360_HorizontalDPad") == -1f)//Left
        {
            transitionToCredits = false;
            if (!transitionToCredits && creditsActive)
            {
                creditsActive = false;
                currentAngle = new Vector3(
                    Mathf.LerpAngle(currentAngle.x, 0f, Time.deltaTime),
                    Mathf.LerpAngle(currentAngle.y, 0f, Time.deltaTime),
                    Mathf.LerpAngle(currentAngle.z, 0f, Time.deltaTime));

                transform.eulerAngles = currentAngle;

            }
        }
	}
}
