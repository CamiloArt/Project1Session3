using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuTransition : MonoBehaviour {

    public Vector3 targetAngle = new Vector3(0f, -170f, 0f);
    public Vector3 currentAngle;

    public float speed = 0.1f;

    bool lerpRight = false;
    bool lerpLeft = false;

    void Start()
    {
        currentAngle = transform.eulerAngles;
    }

    void Update()
    {
        if (lerpRight)
        {
            lerpLeft = false;
            currentAngle = new Vector3(
                Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime),
                Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime),
                Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime));

            transform.eulerAngles = currentAngle;
        }
        if (lerpLeft)
        {
            lerpRight = false;
            currentAngle = new Vector3(
                Mathf.LerpAngle(currentAngle.x, 0f, Time.deltaTime),
                Mathf.LerpAngle(currentAngle.y, 0f, Time.deltaTime),
                Mathf.LerpAngle(currentAngle.z, 0f, Time.deltaTime));

            transform.eulerAngles = currentAngle;
        }
    }

    public void LerpPosRight()
    {
        lerpRight = true;
    }
    public void LerpPosLeft()
    {
        lerpLeft = true;
    }
}
