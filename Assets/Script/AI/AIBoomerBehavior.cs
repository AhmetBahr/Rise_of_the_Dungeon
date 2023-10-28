using Enemy;
using UnityEngine;

namespace AI
{
	public abstract class AIBoomerBehavior : MonoBehaviour
	{
		public abstract void PerformBoomerAction(BoomerController enemy, AIDetector detector);

	}
}