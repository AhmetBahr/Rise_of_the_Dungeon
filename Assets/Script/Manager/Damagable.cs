using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;
using UnityEngine.Events;

namespace Function
{
	public class Damagable : MonoBehaviour
	{
		public int MaxHealth = Config.MaximumHealth;
		[SerializeField] private int currentHealth;

		[SerializeField] private FloatingHealthBar _floatingHealthBar;

		public int Health
		{
			get { return currentHealth; }
			set
			{
				currentHealth = value;
				
			}
		}

		public UnityEvent OnDead;
		public UnityEvent<float> OnHealthChange;
		public UnityEvent OnHit, OnHeal;

		private void Start()
		{
			Health = MaxHealth;
			_floatingHealthBar.UpdateHealthBar(currentHealth,MaxHealth);
		}

		internal void Hit(int damagePoint)
		{
			Health -= damagePoint;
			_floatingHealthBar.UpdateHealthBar(currentHealth,MaxHealth);

			if (Health <= 0)
			{
				OnDead?.Invoke();
			}
			else
			{
				OnHit?.Invoke();
			}
		}

		public void Heal(int healthBoost)
		{
			Health += healthBoost;
			Health = Mathf.Clamp(Health, 0, MaxHealth);
			OnHeal?.Invoke();
		}

	}
}

