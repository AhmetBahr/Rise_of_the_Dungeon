using System.Collections;
using Function;
using UnityEngine;

namespace Enemy
{
	public class BasicEnemyController : MonoBehaviour
	{
		[Header("Core")]
		[SerializeField] private int melleDamage;
		[SerializeField] private bool canAttack = true;
		[SerializeField] private float timeBetweenfiring;
		private float timer;

		
		[Header("Bommer")]
		[SerializeField] private GameObject point;
		[SerializeField] private float stopeRadius;
		[SerializeField] private float BombRadius;
		[SerializeField] private LayerMask Damagelayers;

		public BasicEnemyMover _basicEnemyMover;

		private void Awake()
		{
			if (_basicEnemyMover == null)
				_basicEnemyMover = GetComponentInChildren<BasicEnemyMover>();
		}

		private void Update()
		{
			Detected();
		}

		public void Detected()
		{
			Collider2D[] enemy = Physics2D.OverlapCircleAll(point.transform.position, stopeRadius, Damagelayers);

			
			foreach (Collider2D enemyGameobject in enemy)
			{
				canAttack = false;
				BasicEnemyAttack();
			}
			
		}
		
		private void BasicEnemyAttack()
		{
			waitingAttack();
			if (canAttack)
			{
				_basicEnemyMover.canWalk = false;

				Collider2D[] enemy = Physics2D.OverlapCircleAll(point.transform.position, BombRadius, Damagelayers);

				foreach (Collider2D enemyGameobject in enemy)
				{
					enemyGameobject.GetComponent<Damagable>().Hit(melleDamage);
					//TODo Attack animasyonu
				
					print("Enemy attack");
				
				}
				_basicEnemyMover.canWalk = true;
			}
			
		}

		private void waitingAttack()
		{
			if (!canAttack)
			{
				timer += Time.deltaTime;
				if (timer > timeBetweenfiring)
				{
					canAttack = true;
					timer = 0;
				}
			}
		}
		private void OnDrawGizmos()
		{
			Gizmos.color = Color.white;
			Gizmos.DrawWireSphere(point.transform.position, stopeRadius);
			
			Gizmos.color = Color.blue;
			Gizmos.DrawWireSphere(point.transform.position, BombRadius);

		}

	}
}