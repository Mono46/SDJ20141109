using UnityEngine;
using System.Collections;

public class MoonManager : MonoBehaviour
{
    private GameObject moon;
    public float speed;
    private float rotate;

	// Use this for initialization
	void Start () 
    {

        speed = -0.03f;
        rotate = 180;
        moon = GameObject.Find("Moon");
	}
	
	// Update is called once per frame
	void Update () 
    {
		Vector3 v = moon.transform.position;
//        moon.transform.position = v + new Vector3(speed, 0, 0);
        
        rotate++;
        moon.transform.rotation = Quaternion.AngleAxis(rotate, new Vector3(0, 0, 1));
	}
}
