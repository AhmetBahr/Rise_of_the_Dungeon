using AI;
using Enemy;
using UnityEngine;

namespace AI
{
	public abstract class AIBehaviour : MonoBehaviour
	{
		public abstract void PerformAction(EnemyController enemy, AIDetector detector);
	}
	
}
