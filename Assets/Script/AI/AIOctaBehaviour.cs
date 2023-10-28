using Enemy;
using UnityEngine;

namespace AI
{
	public abstract class AIOctaBehaviour : MonoBehaviour
	{
		public abstract void PerformOctaAction(EnemyOctaController enemy, AIDetector detector);

	}
}