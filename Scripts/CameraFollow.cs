using UnityEngine;

public class CameraFollow : MonoBehaviour {
	[SerializeField]
	Transform target;
	[SerializeField]
	float smoothSpeed = 0.125f;
	[SerializeField]
	private Vector3 offset;

	void FixedUpdate ()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;

		//transform.LookAt();
	}

}
