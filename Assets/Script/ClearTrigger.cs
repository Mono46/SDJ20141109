using UnityEngine;
using System.Collections;

public class ClearTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "UnityMask")
		{
			System.TimeSpan time = System.DateTime.Now - GameMain.startTime;

			GameMain.Score = (int)time.TotalSeconds;
			Application.LoadLevelAsync("Result");
		}
	}
}
