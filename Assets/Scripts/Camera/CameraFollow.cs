using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private Transform targetSurveillance;

	[SerializeField] private float offsetX = 2f;
	[SerializeField] private float damping = 1.5f;

	private Vector3 finalPosition;

	private int lastPosTrackingObjectX;
	private int currentPosTrackingObjectX;

	private sbyte coeffPositionOffset = 1;

	private void Start()
	{
		lastPosTrackingObjectX = Mathf.RoundToInt(targetSurveillance.position.x);

		transform.position = new Vector3(targetSurveillance.position.x + offsetX, transform.position.y, transform.position.z);
	}

	private void FixedUpdate()
	{
		currentPosTrackingObjectX = Mathf.RoundToInt(targetSurveillance.position.x);

		if (currentPosTrackingObjectX > lastPosTrackingObjectX)
			coeffPositionOffset = 1;
		else if (currentPosTrackingObjectX < lastPosTrackingObjectX)
			coeffPositionOffset = -1;

		lastPosTrackingObjectX = Mathf.RoundToInt(targetSurveillance.position.x);

		finalPosition = new Vector3(targetSurveillance.position.x + offsetX * coeffPositionOffset, transform.position.y, transform.position.z); ;

		transform.position = Vector3.Lerp(transform.position, finalPosition, damping * Time.deltaTime);
	}
}
