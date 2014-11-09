using UnityEngine;
using System.Collections;

public class GameMain: MonoBehaviour {

	private Vector3 touchStartPosition;

	public GameObject unityMask = null;
	public GameObject unityMaskPrefab = null;
	private Animator unityMaskAnimator = null;

	public GameObject unityChang = null;
	public GameObject Arrow = null;
	private Animator unityChangAnimator = null;


	bool isKickAnimation = false;

	[SerializeField]
	AudioClip[] maskVoice = null;
	public static System.DateTime startTime;

	public static int Score = 0;

	public float PowerMax = 5.0f;
	// Use this for initialization
	void Start ()
	{
		startTime = System.DateTime.Now;
		unityMask = (GameObject)Instantiate(unityMaskPrefab);

		unityChangAnimator = unityChang.GetComponent<Animator>();
		unityMaskAnimator = unityMask.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isKickAnimation)
		{
			return;
		}

		if (Input.GetMouseButtonDown(0))
		{
			touchStartPosition = Input.mousePosition;
		}

		if (Input.GetMouseButton(0))
		{

			Vector3 vec = touchStartPosition - Input.mousePosition;
			float power = Vector3.Distance(touchStartPosition, Input.mousePosition) / 30;
			if (power > PowerMax)
			{
				power = PowerMax;
			}
		}
		if (Input.GetMouseButtonUp(0))
		{

			Vector3 vec = touchStartPosition - Input.mousePosition;
			float power = Vector3.Distance(touchStartPosition, Input.mousePosition) / 30;
			if (power > PowerMax)
			{
				power = PowerMax;
			}
			StartCoroutine(KickCoroutine(vec, power));
		}

	}


	public void RemoveMask()
	{
		Destroy(unityMask);
		unityMask = (GameObject)Instantiate(unityMaskPrefab);
		
		unityMaskAnimator = unityMask.GetComponent<Animator>();
		
		isKickAnimation = false;
	}

	IEnumerator KickCoroutine(Vector3 vec, float power)
	{
		isKickAnimation = true;
		unityChangAnimator.SetBool("Kick", true);

		for (int i = 0; i< 35; i++)
		{
			yield return null;
		}

		audio.PlayOneShot(maskVoice[Random.Range(0, maskVoice.Length)]);

		unityChangAnimator.SetBool("Kick", false);

		unityMask.rigidbody.constraints = RigidbodyConstraints.None;
		unityMask.rigidbody.AddForce(vec * power);
		unityMask.rigidbody.angularVelocity= new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
		
		unityMaskAnimator.SetBool("Fall", true);


		for (int i = 0; i< 150; i++)
		{
			yield return null;
		}
		if(isKickAnimation == true)
		{
			RemoveMask();
		}

		yield return null;
	}

	public void MaskVoiceOneShotRandom()
	{
		audio.PlayOneShot(maskVoice[Random.Range(0, maskVoice.Length)]);
	}
}
