using UnityEngine;
using System.Collections;

public class Remover : MonoBehaviour {
	[SerializeField]
	public GameMain gameMain;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter(Collider other) 
	{
		gameMain.RemoveMask();
	}
}
