using System;
using System.Collections.Generic;
using AI;
using Data;
using Script;
using UnityEngine;

namespace Enemy
{
	public class EnemyOctaController : MonoBehaviour
	{
		public EnemyMover enemyMover;
		public EnemyTaret[] turrets;

		private bool canShoot = true;
		private float currentDelay = 0;

		private void Awake()
		{
			if (enemyMover == null)
				enemyMover = GetComponentInChildren<EnemyMover>();

			if(turrets == null || turrets.Length == 0)
			{
				turrets = GetComponentsInChildren<EnemyTaret>();
			}
		}
		
		public void HandleShoot()
		{
			foreach (var turret in turrets)
			{
				turret.Shoot();
			}

		}

	}
}