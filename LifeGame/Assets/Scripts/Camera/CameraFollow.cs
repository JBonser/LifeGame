using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public Transform target;
	public float smoothing = 5f;

	public Vector3 offset = new Vector3( 0f, 0f, 0f );

	void Start()
	{
		//offset = transform.position - target.position;
	}

	void FixedUpdate()
	{
		Vector3 targetCamPos = target.position + offset;

		transform.position = Vector3.Lerp (target.position, targetCamPos, smoothing * Time.deltaTime );
	}
}
