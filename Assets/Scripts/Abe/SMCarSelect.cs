using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMCarSelect : MonoBehaviour {
    //--PUBLIC VARIABLES--//
    public Unit units;

    public Camera mainCamera;
    public GameObject selectedUI;

    public Transform initialTransform;
    public Transform newTransform;

    public float speed = 1f;
    //--PRIVATE VARIABLES--//
    private float startTime;
    private float journeyLengthTo;
    private float journeyLengthFrom;

    public bool selected = false; 
    public bool unselected = false;

	void Start() 
    {
        selectedUI.SetActive(false);

        journeyLengthTo = Vector3.Distance(initialTransform.position, newTransform.position);
        journeyLengthFrom = Vector3.Distance(newTransform.position, initialTransform.position);
        startTime = Time.time;
	}

    void FixedUpdate()
    {
        if (selected)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLengthTo;
            mainCamera.transform.position = Vector3.Lerp(initialTransform.position, newTransform.position, fracJourney);
        }
        if (!selected)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLengthFrom;
            mainCamera.transform.position = Vector3.Lerp(newTransform.position, initialTransform.position, fracJourney);
        }
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Return)) //if in initial pos, and e is pressed, go to new pos
        {
            //zoom camera in on local axis 
            selected = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape)) //if in new pos, and escape 
        {
            //zoom camera back to initial position
            selected = false;
        }
        ToggleSelectionUI();
    }

    void ToggleSelectionUI()
    {
        if (selected)
        {
            selectedUI.SetActive(true);
        }
        if (!selected)
        {
            selectedUI.SetActive(false);
        }
    }
}