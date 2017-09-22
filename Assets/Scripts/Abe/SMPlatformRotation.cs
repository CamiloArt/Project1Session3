using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMPlatformRotation : MonoBehaviour {
    //--PUBLIC VARIABLES--//
    public GameObject parentP; //parent platform

    public int PRotationAngle = 120;
    //--PRIVATE VARIABLES--//
    private Vector3 PRotationAmount;
    private Vector3 currentRotation;

    private bool rotate;

    private float parentSpeed = 5f;
    private float direction;

    void Start()
    {
        PRotationAmount = new Vector3(0, 0, 0);
        currentRotation = new Vector3(0, 0, 0);
    }

    void Update()
    {
        OnArrowKeyPress();
    }

    void OnArrowKeyPress()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rotate = true;
            PRotationAmount.y -= PRotationAngle;
            direction = -1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rotate = true;
            PRotationAmount.y += PRotationAngle;
            direction = 1;
        }
        if (rotate)
        {
            RotateParent();
        }
    }

    void RotateParent()
    {
        currentRotation = Vector3.Lerp(currentRotation, PRotationAmount, Time.deltaTime * parentSpeed);
        transform.eulerAngles = currentRotation;
        if (direction == 1)
        {
            if ((currentRotation.y - PRotationAmount.y) > -0.5f)
            {
                transform.eulerAngles = PRotationAmount;
                if (PRotationAmount.y == 360)
                {
                    transform.eulerAngles = Vector3.zero;
                    PRotationAmount.y = 0;
                    currentRotation.y = 0;
                }
                rotate = false;
            } 
        }
        else
        {
            if ((currentRotation.y - PRotationAmount.y) < 0.5f)
            {
                transform.eulerAngles = PRotationAmount;
                if (PRotationAmount.y == -360)
                {
                    transform.eulerAngles = Vector3.zero;
                    PRotationAmount.y = 0;
                    currentRotation.y = 0;
                }
                rotate = false;
            } 
        }
    }
}