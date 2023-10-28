using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Function
{
	public class FloatingHealthBar : MonoBehaviour
	{
		[SerializeField] private Slider _slider;
		[SerializeField] private Camera _camera;
		[SerializeField] private Transform _target;
		[SerializeField] private Vector3 offset;
		
		public void UpdateHealthBar(float currentValue, float maxValue)
		{
			_slider.value = currentValue / maxValue;
		}

		private void Update()
		{
			transform.rotation = _camera.transform.rotation;
			transform.position = _target.position + offset;
		}
	}
}