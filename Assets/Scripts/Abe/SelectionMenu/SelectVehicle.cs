using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectVehicle : MonoBehaviour {
    //--PUBLIC VARIABLES--//
    [Tooltip("MuscleCar = [0], Buggy = [1], MonsterTruck = [2]")]
    public GameObject[] vehicles;

    public GameEngine gameEngine;

    public Camera mainCamera;
    public GameObject selectedUI;
    public GameObject unselectedUI;

    public Transform initialTransform;
    public Transform newTransform;

    public Material carBodyTeam1;
    public Material carBodyTeam2;
    public Material currentCarBodyMat;

    public float speed = 1f;
    //--PRIVATE VARIABLES--//
    private float startTime;
    private float journeyLengthTo;
    private float journeyLengthFrom;

    public bool selected = false; 

	void Start() 
    {
        currentCarBodyMat = carBodyTeam1;

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
        //change team color starting at the 6th player (Leader 2)
        vehicles[0].GetComponent<Renderer>().material = currentCarBodyMat;
        vehicles[1].GetComponent<Renderer>().material = currentCarBodyMat;
        vehicles[2].GetComponent<Renderer>().material = currentCarBodyMat;
        if (gameEngine.playerTurnNum < 5)
        {
            currentCarBodyMat = carBodyTeam1;
        }
        if (gameEngine.playerTurnNum > 5)
        {
            currentCarBodyMat = carBodyTeam2;
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("X360_A")) 
        {
            //zoom camera in on local axis 
            selected = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("X360_B")) 
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
            unselectedUI.SetActive(false);
        }
        if (!selected)
        {
            selectedUI.SetActive(false);
            unselectedUI.SetActive(true);
        }
    }
}