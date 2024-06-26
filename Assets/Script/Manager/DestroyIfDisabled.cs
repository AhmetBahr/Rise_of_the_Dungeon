﻿using UnityEngine;

namespace Script
{
	public class DestroyIfDisabled : MonoBehaviour
	{
		public bool SelfDestructionEnabled { get; set; } = false;

		private void OnDisable()
		{
			if (SelfDestructionEnabled)
			{
				Destroy(gameObject);
			}
		}
	}
}