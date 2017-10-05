using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsBar : MonoBehaviour {
	//--PUBLIC VARIABLES--//
    public Vector2 pos = new Vector2(0, 0);
    public Vector2 size = new Vector2(100, 5);

    public Texture2D progressBarEmpty;
    public Texture2D progressBarFull;

    public float progress = 0f;
	//--PRIVATE VARIABLES--//

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(pos.x, pos.y, size.x, size.y), progressBarEmpty);
        GUI.DrawTexture(new Rect(pos.x, pos.y, size.x * Mathf.Clamp01(progress), size.y), progressBarFull);
    }
}
