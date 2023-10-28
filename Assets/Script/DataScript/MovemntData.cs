using UnityEngine;

namespace Data
{
	[CreateAssetMenu(fileName = "NewMovemntData", menuName = "Data/MovemntData")]
	public class MovemntData : ScriptableObject
	{
		[Header("Core Settings")]
		public float Speed = 10;
		public float StopDistance; //Player'ın yanına gelince duracağı uzaklık
		public float retreatdistance; // Player üstüne yürüdüğü zaman geri kaçmaya başlıcağı uzaklık
  
		[Header("Dash Settings")]
		public float DashSpeed = 10;
		public float dashDuration = 1f;
		public float dashCooldown = 1f;
		
	}
}

