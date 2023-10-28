using Enemy;
using UnityEngine;

namespace AI
{
	public class AiOctaShootBehaviour: AIOctaBehaviour
	{
		public float fieldOfVisionForShooting = 60;

		public override void PerformOctaAction(EnemyOctaController enemy, AIDetector detector)
		{
			enemy.HandleShoot();
			
		}
	}
}