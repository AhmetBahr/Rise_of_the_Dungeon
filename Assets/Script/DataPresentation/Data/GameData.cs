using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Data
{
	[System.Serializable]
	public class GameData
	{
		public Vector3 PlayerPosition;
		public SerializableDictionary<string, bool> coinsCollected;

		#region Player

			public int PlayerCoin;
		
			public int PlayerLevel;
			public int Hp_Bonus;
			public int Damge_Bonus;
			public int AttackSPeed_Bonus;
			public int MoveSpeed_Bonus;
			
			public int LifeSteal_Bonus;
			public int CritChange_Bonus;
			public int Dodge_Bonus;
			

		#endregion
		

		public GameData()
		{
			PlayerPosition = Vector3.zero;
			coinsCollected = new SerializableDictionary<string, bool>();

			this.PlayerCoin = 0;
			this.PlayerLevel = 0;		
			this.Hp_Bonus = 0;
			this.Damge_Bonus = 0;
			this.AttackSPeed_Bonus = 0;
			this.MoveSpeed_Bonus = 0;
			this.LifeSteal_Bonus = 0;
			this.CritChange_Bonus = 0;
			this.Dodge_Bonus = 0;


		}

	}

}
