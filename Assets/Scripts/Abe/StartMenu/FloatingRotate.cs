using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingRotate : MonoBehaviour {

    public Transform pointA;
    public Transform pointB;
    public float repeatTime = 0.5f;
    public float rotationSpeed = 10f;

	void Update() 
    {
        transform.position = Vector3.Lerp(pointA.position, pointB.position, Mathf.PingPong(Time.time, repeatTime) / repeatTime); 
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, -Mathf.PingPong(Time.time * 1, rotationSpeed), transform.localEulerAngles.z);
    }
}
