using UnityEngine;
using System.Collections;

public class gui : MonoBehaviour {
	public GUISkin mySkin;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Application.LoadLevel ("GameMain");
		}
	}

	void OnGUI(){
		int sw = Screen.width;
		int sh = Screen.height;
		GUI.skin = mySkin;
		GUI.Label (new Rect (0, 0, sw, sh), "月に向かって蹴れ", "title");
		GUI.Label (new Rect (0, 100, sw, sh), "Tap or Click Start", "subtitle");

	}
}
