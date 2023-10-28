using Enemy;
using UnityEngine;

namespace AI
{
	public class AiShootBehaviour : AIBehaviour
	{
		public float fieldOfVisionForShooting = 60;

		public override void PerformAction(EnemyController enemy, AIDetector detector)
		{
			if (TargetInFOV(enemy, detector))
			{
				enemy.HandleShoot();
			}
            
			enemy.HandleTurretMovement(detector.Target.position);
		}

		private bool TargetInFOV(EnemyController enemy, AIDetector detector)
		{
			var direction = detector.Target.position - enemy.aimTurret.transform.position;
			if (Vector2.Angle(enemy.aimTurret.transform.right, direction) < fieldOfVisionForShooting / 2)
			{
				return true;
			}
			return false;
		}
	}
}