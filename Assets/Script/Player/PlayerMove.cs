using System.Collections;
using System.Collections.Generic;
using Characters;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
	public class PlayerMove : Character
	{

		protected override void Update()
		{
			GetInput();

			base.Update();
		}

		private void GetInput()
		{
			direction = Vector2.zero;
			
			if (Input.GetKey(KeyCode.W))
			{
				direction += Vector2.up;
			}
			if (Input.GetKey(KeyCode.A))
			{
				direction += Vector2.left;

			}
			if (Input.GetKey(KeyCode.S))
			{				
				direction += Vector2.down;
			}
			if (Input.GetKey(KeyCode.D))
			{
				direction += Vector2.right;

			}
		}
	}

}
