using System.Collections;
using System.Collections.Generic;
using AI;
using Enemy;
using UnityEngine;

namespace AI
{
	public class AIPatrolBehaviour : AIBehaviour
	{
		public float patrolDelay = 4;

		[SerializeField] private Vector2 randomDirection = Vector2.zero;
		[SerializeField] private float currentPatrolDelay;

		private void Awake()
		{
			randomDirection = Random.insideUnitCircle;
		}

		public override void PerformAction(EnemyController enemy, AIDetector detector)
		{
			float angle = Vector2.Angle(enemy.aimTurret.transform.right, randomDirection);
			if (currentPatrolDelay <= 0 && (angle < 2))
			{
				randomDirection = Random.insideUnitCircle;
				currentPatrolDelay = patrolDelay;
			}
			else
			{
				if (currentPatrolDelay > 0)
					currentPatrolDelay -= Time.deltaTime;
				else
					enemy.HandleTurretMovement((Vector2)enemy.aimTurret.transform.position + randomDirection);
			}
		}
		
		

	}
}