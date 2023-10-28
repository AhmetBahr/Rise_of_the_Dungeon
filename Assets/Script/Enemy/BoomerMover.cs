using System;
using AI;
using Data;
using UnityEngine;

namespace Enemy
{
	public class BoomerMover : MonoBehaviour
	{
		
		public MovemntData movementData;
		public AIDetector aiDetector;

		[SerializeField] private Rigidbody2D enemyRigidbody;
		 
		private Vector2 movementVector;
		[SerializeField] private float currentSpeed = 0;

		[field: SerializeField] public bool canWalk;
		
		private void Awake()
		{
			enemyRigidbody = GetComponentInParent<Rigidbody2D>();
		}

		private void Start()
		{
			canWalk = true;
			currentSpeed = movementData.Speed;
		}

		private void FixedUpdate()
		{
			if(aiDetector.Target == null)
				return; //ToDo Burası değişicek

			if (!canWalk)
				currentSpeed = 0;

			Move();

		

		}
		
		private void Move()
		{
			Vector2 targetPosition = aiDetector.Target.position;
			Vector2 currentPosition = enemyRigidbody.position;

			float distanceToTarget = Vector2.Distance(currentPosition, targetPosition);

			if (distanceToTarget > movementData.StopDistance)
			{
				// Hedefe doğru ilerle
				Vector2 moveDirection = (targetPosition - currentPosition).normalized;
				enemyRigidbody.velocity = moveDirection * currentSpeed ;
			}
			
		}
		
	}
}