using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Function
{
	public class DestroyAnimationOnEnd : MonoBehaviour
	{
		public void DestroyParent()
		{
			GameObject parent = gameObject.transform.parent.gameObject;
			Destroy(parent); 
		}
	}
}



