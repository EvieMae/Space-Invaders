using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {


	private Transform transform;

	private float shakeDuration = 0f;


	private float shakeMagnitude = 0.7f;

	private float dampingSpeed = 1.0f;

	Vector3 initialPosition;

	void Start () {
		if (transform == null)
		{
			transform = GetComponent(typeof(Transform)) as Transform;
		}
	}
	void OnEnable()
	{
		initialPosition = new Vector3(0,0,-10);
	}
	// Update is called once per frame
	void Update()
	{
		if (shakeDuration > 0)
		{
			transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

			shakeDuration -= Time.deltaTime * dampingSpeed;
		}
		else
		{
			shakeDuration = 0f;
			transform.localPosition = initialPosition;
		}
	}

	public void TriggerShake(float shake = 1f) {
		shakeDuration = shake;
	}


}
