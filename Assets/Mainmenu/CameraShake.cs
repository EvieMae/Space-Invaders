using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {


	private Transform transform;
	private float SDur = 0f; //Shake Duration
	private float sMag = 0.7f //Shake Distance;

	Vector3 startPOS;
	void OnEnable()
	{
		startPOS = new Vector3(0,0,-10);
	}
	void Start () {
		if (transform == null)
		{
			transform = GetComponent(typeof(Transform)) as Transform;
		}
	}
	void Update()
	{
		if (SDur > 0)
		{
			transform.localPosition = startPOS + Random.insideUnitSphere * sMag;
			SDur = SDur - Time.deltaTime;
		}
		else
		{
			SDur = 0f;
			transform.localPosition = startPOS;
		}
	}

	public void TriggerShake(float shake = 1f) {
		SDur = shake;
	}
}
