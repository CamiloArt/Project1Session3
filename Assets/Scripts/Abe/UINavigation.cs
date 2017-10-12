using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UINavigation : MonoBehaviour {

	void Update() 
    {
        if (Input.GetAxis("X360_HorizontalDPad") == 1f)//Right DPad
        {
            
        }
        if (Input.GetAxis("X360_HorizontalDPad") == -1f)//Left DPad
        {
            
        }
        if (Input.GetAxis("X360_VerticalDPad") == 1f)//Up DPad
        {
            
        }
        if (Input.GetAxis("X360_VerticalDPad") == -1f)//down DPad
        {
            
        }
	}
}
