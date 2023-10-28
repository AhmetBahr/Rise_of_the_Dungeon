using UnityEngine;

namespace Script
{
	public class AnimHash : MonoBehaviour
	{
		public static AnimHash instance;
		
		[field:SerializeField] public string MoveX = "moveX";
		[field:SerializeField] public string MoveY = "moveY";
		[field:SerializeField] public string Moving = "moving";
		[field:SerializeField] public string Attacking = "attacking";
		[field:SerializeField] public string RotZ = "rotZ";
		[field: SerializeField] public string Press_E = "press_E";
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

		

	}
}