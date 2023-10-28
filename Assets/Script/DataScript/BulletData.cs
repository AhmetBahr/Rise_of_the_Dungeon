using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Data
{
	[CreateAssetMenu(fileName = "NewBulletData", menuName = "Data/BulletData")]
	public class BulletData : ScriptableObject
	{
		public float speed = 25;
		public float maxDistance = 10;
		
		public int minDamage;
		public int maxDamage;
		 
	}
}

