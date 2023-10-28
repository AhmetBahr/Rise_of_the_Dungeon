using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;
using UnityEngine.Serialization;

namespace AI
{
	public class DefaultEnemyAI : MonoBehaviour
	{
		[SerializeField]
		private AIBehaviour shootBehaviour, patrolBehaviour;

		[SerializeField] private EnemyController enemy;
		[SerializeField] private AIDetector detector;

		private void Awake()
		{
			detector = GetComponentInChildren<AIDetector>();
			enemy = GetComponentInChildren<EnemyController>();
		}

		private void Update()
		{
			if (detector.TargetVisible)
			{
				
				shootBehaviour.PerformAction(enemy, detector);
			}
			else
			{
				patrolBehaviour.PerformAction(enemy, detector);
			}
		}
	}
}
