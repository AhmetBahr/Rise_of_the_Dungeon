using AI;
using Data;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy
{
	public class EnemyMover : MonoBehaviour
	{
		
		public MovemntData movementData;
		public AIDetector aiDetector;

		[SerializeField] private Rigidbody2D enemyRigidbody;
		[SerializeField] private LayerMask enemyLayer;
		[SerializeField] private float minimumEnemyDistance = 2.0f;
		 
		private Vector2 movementVector;
		private float currentSpeed = 0;
		private float currentForewardDirection = 1;
		
		private void Awake()
		{
			enemyRigidbody = GetComponentInParent<Rigidbody2D>();
		}

		private void FixedUpdate()
		{
			if(aiDetector.Target == null) 
				enemyRigidbody.velocity = Vector2.zero * 0;
			else
				Move();

		}

		private void Move()
		{
			Vector2 targetPosition = aiDetector.Target.position;
			Vector2 currentPosition = enemyRigidbody.position;

			float distanceToTarget = Vector2.Distance(currentPosition, targetPosition);

			Collider2D[] otherEnemies = Physics2D.OverlapCircleAll(currentPosition, minimumEnemyDistance, enemyLayer);

			if (distanceToTarget > movementData.StopDistance)
			{
				// Hedefe doğru ilerle
				Vector2 moveDirection = (targetPosition - currentPosition).normalized;
				enemyRigidbody.velocity = moveDirection * movementData.Speed;

				// Diğer enemyler ile mesafe kontrolü
				foreach (Collider2D otherEnemyCollider in otherEnemies)
				{
					if (otherEnemyCollider.gameObject != gameObject)
					{
						float distanceToOtherEnemy = Vector2.Distance(currentPosition, otherEnemyCollider.transform.position);
						if (distanceToOtherEnemy < minimumEnemyDistance)
						{
							// Diğer enemy ile minimum mesafeyi koru
							Vector2 moveAwayDirection = (currentPosition - (Vector2)otherEnemyCollider.transform.position).normalized;
							enemyRigidbody.velocity += moveAwayDirection * movementData.Speed;
						}
					}
				}
			}
			else if (distanceToTarget < movementData.StopDistance && distanceToTarget > movementData.retreatdistance)
			{
				// Durdur, pozisyonu koru
				enemyRigidbody.velocity = Vector2.zero;
			}
			else if (distanceToTarget < movementData.retreatdistance)
			{
				// Geriye doğru hareket et
				Vector2 moveDirection = (currentPosition - targetPosition).normalized;
				enemyRigidbody.velocity = moveDirection * movementData.Speed;
			}
		}
		
			/*	private void Move()
		{
			Vector2 targetPosition = aiDetector.Target.position;
			Vector2 currentPosition = enemyRigidbody.position;

			float distanceToTarget = Vector2.Distance(currentPosition, targetPosition);

			if (distanceToTarget > movementData.StopDistance)
			{
				// Hedefe doğru ilerle
				Vector2 moveDirection = (targetPosition - currentPosition).normalized;
				enemyRigidbody.velocity = moveDirection * movementData.Speed;
			}
			else if (distanceToTarget < movementData.StopDistance && distanceToTarget > movementData.retreatdistance)
			{
				// Durdur, pozisyonu koru
				enemyRigidbody.velocity = Vector2.zero;
			}
			else if (distanceToTarget < movementData.retreatdistance)
			{
				// Geriye doğru hareket et
				Vector2 moveDirection = (currentPosition - targetPosition).normalized;
				enemyRigidbody.velocity = moveDirection * movementData.Speed;
			}
		}*/
	}
	
}