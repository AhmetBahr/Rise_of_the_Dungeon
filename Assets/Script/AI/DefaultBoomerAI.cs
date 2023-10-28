using Enemy;
using UnityEngine;

namespace AI
{
	public class DefaultBoomerAI : MonoBehaviour
	{
		[SerializeField]
		private AIBoomerBehavior shootBehaviour;

		[SerializeField] private BoomerController boomer;
		[SerializeField] private AIDetector detector4Boom;

		private void Awake()
		{
			detector4Boom = GetComponentInChildren<AIDetector>();
			boomer = GetComponentInChildren<BoomerController>();
		}

		private void Update()
		{
			if (detector4Boom.TargetVisible)
			{
				print("Boom");
				shootBehaviour.PerformBoomerAction(boomer, detector4Boom);
			}
			
		}
	}
}