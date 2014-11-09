using UnityEngine;
using System.Collections;

public class ClearTime : MonoBehaviour {
    private int time;
    private int clearTime;
    private GUIStyle guiStyle;
    private GUIStyleState guiStyleState;

    // Use this for initialization
	void Start () {
        time = 45;

        clearTime = GameMain.Score;
        guiStyle = new GUIStyle();
        guiStyle.fontSize = 50;
        guiStyleState = new GUIStyleState();
        guiStyleState.textColor = Color.yellow;
        guiStyle.normal = guiStyleState;
		guiStyle.alignment = TextAnchor.MiddleCenter;
	}
	
	// Update is called once per frame
	void Update () {
        time--;
        if (time < 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Application.LoadLevelAsync("Title");
            }
        }
	}

    void OnGUI () {
        // ラベルを表示する
        string str = clearTime.ToString();
        GUI.Label(new Rect((int)(Screen.width*0.5), (int)(Screen.height*0.65), 200, 100),str,guiStyle);
    }
}
