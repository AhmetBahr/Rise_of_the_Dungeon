using System;
using System.Collections;
using Function;
using Data;
using UnityEngine;

namespace Enemy
{
	public class BoomerController : MonoBehaviour
	{
		[Header("Core")]
		[SerializeField] private int BoombDamage;
		[SerializeField] private float waitTime;
		
		[Header("Bommer")]
		[SerializeField] private GameObject point;
		[SerializeField] private float stopeRadius;
		[SerializeField] private float BombRadius;
		[SerializeField] private LayerMask Damagelayers;

		public BoomerMover _boomerMover;

		private void Awake()
		{
			if (_boomerMover == null)
				_boomerMover = GetComponentInChildren<BoomerMover>();
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
				//ToDo hızı sıfırla 
				_boomerMover.canWalk = false;
				StartCoroutine(Boomb());
                
			}
			
		}
		
		
		IEnumerator Boomb()
		{
			yield return new WaitForSeconds(waitTime);
        
			Collider2D[] enemy = Physics2D.OverlapCircleAll(point.transform.position, BombRadius, Damagelayers);

			foreach (Collider2D enemyGameobject in enemy)
			{
				enemyGameobject.GetComponent<Damagable>().Hit(BoombDamage);
				//TODo Patlama animasyonu
			//	Destroy(gameObject);
				gameObject.SetActive(false);

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