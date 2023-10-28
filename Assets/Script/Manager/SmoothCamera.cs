using UnityEngine;

namespace Player
{
	public class SmoothCamera : MonoBehaviour
	{
		[SerializeField] private Vector3 offset;
		[SerializeField] private float damping;
		
		private Vector3 velocity = Vector3.zero;

		[SerializeField] private Transform _target;

		private void FixedUpdate()
		{
			Vector3 targetPosition = _target.position + offset;
			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, damping);
		}
	}
}

