using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy
{
	public class EnemyController: MonoBehaviour
	{
		public EnemyMover enemyMover;
		public EnemyAim aimTurret;
		public EnemyTaret[] turrets;

		private void Awake()
		{
			if (enemyMover == null)
				enemyMover = GetComponentInChildren<EnemyMover>();
			if (aimTurret == null)
				aimTurret = GetComponentInChildren<EnemyAim>();
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



		public void HandleTurretMovement(Vector2 pointerPosition)
		{
			aimTurret.Aim(pointerPosition);
        
		}
	}
}