using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	public Transform camTransform;

	static public float shake = 0f;

	float shakeAmount = 0.2f;
	float decreaseFactor = 5f;
	
	Vector3 originalPos;
	
	void Start()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
		originalPos = camTransform.localPosition;
	}
	
	void Update()
	{
		if (shake > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			Handheld.Vibrate();
			shake -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shake = 0f;
			camTransform.localPosition = originalPos;
		}
	}
}

