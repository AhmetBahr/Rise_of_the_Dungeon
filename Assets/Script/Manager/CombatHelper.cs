using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Combat
{
	public class CombatHelper : MonoBehaviour 
	{
		public static CombatHelper instance;

		private void Start()
		{
			if (instance != null && instance != this)
			{
				Destroy(this);
			}
			else
			{
				instance = this;
			}
		}


		public static int RandomDice(int startInt, int lastInt)
		{
			int dice;

			dice = UnityEngine.Random.Range(startInt,lastInt);

			print(dice);
			return dice;
		}
		
	}
}

