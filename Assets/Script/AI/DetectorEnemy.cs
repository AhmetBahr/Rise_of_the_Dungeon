using System.Collections;
using UnityEngine;

namespace AI
{
	public class DetectorEnemy : MonoBehaviour
	{
		[Range(1, 60)] 
		[SerializeField] private float viewRadius = 11;
		[SerializeField] private float detectionCheckDelay = 0.1f;
		[SerializeField] private Transform target = null;

		[SerializeField] private LayerMask enemyLayerMask;
		[SerializeField] private LayerMask visibilityLayer;
		
		[field: SerializeField]public bool TargetVisible { get; private set; }

		public Transform Target
		{
			get => target;
			set
			{
				target = value;
				TargetVisible = false;
			}
		}


		private void Start()
		{
			StartCoroutine(DetectionCoroutine());
		}

		private void Update()
		{
			if (Target != null)
				TargetVisible = CheckTargetVisible();
		}

		private bool CheckTargetVisible()
		{
			var result = Physics2D.Raycast(transform.position, Target.position - transform.position, viewRadius,
				visibilityLayer);
			if (result.collider != null)
			{
				return (enemyLayerMask & (1 << result.collider.gameObject.layer)) != 0;
			}

			return false;
		}

		private void DetectTarget()
		{
			if (Target == null)
				CheckIfPlayerRange();
			else if (target != null)
				DetectIfOutOfRange();
		}

		private void DetectIfOutOfRange()
		{
			if (target == null || target.gameObject.activeSelf == false ||
			    Vector2.Distance(transform.position, Target.position) > viewRadius)
			{
				Target = null;
			}
		}

		private void CheckIfPlayerRange()
		{
			Collider2D collision = Physics2D.OverlapCircle(transform.position, viewRadius, enemyLayerMask);
			if (collision != null)
			{
				Target = collision.transform;
			}
		}

		IEnumerator DetectionCoroutine()
		{
			yield return new WaitForSeconds(detectionCheckDelay);
			DetectTarget();
			StartCoroutine(DetectionCoroutine());	
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.white;
			Gizmos.DrawWireSphere(transform.position, viewRadius);
		}
	}
}