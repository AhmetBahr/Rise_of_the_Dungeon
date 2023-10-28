using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

namespace AI
{
	public class OctaEnemyAI : MonoBehaviour
	{
		[SerializeField]
		private AIOctaBehaviour shootBehaviour;

		[SerializeField] private EnemyOctaController enemy;
		[SerializeField] private AIDetector detector;

		private void Awake()
		{
			detector = GetComponentInChildren<AIDetector>();
			enemy = GetComponentInChildren<EnemyOctaController>();
		}

		private void Update()
		{
			if (detector.TargetVisible)
			{
				shootBehaviour.PerformOctaAction(enemy, detector);
			}
		}
	}
	
}
