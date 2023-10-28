using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Skilltree
{
	public class Skill : MonoBehaviour
	{
		private Image _image;
		[SerializeField] private TMP_Text _countText;

		[SerializeField] private int maxCount;

		private int currentCount;
		private void Awake()
		{
			_image = GetComponent<Image>();	
		}

		public bool Cliced()
		{
			if (currentCount < maxCount)
			{
				currentCount++;
				_countText.text = $"{currentCount}/{maxCount}";
				return true;
			}
			
			return false;
		}

		public void Lock()
		{
			_image.color = Color.gray;
			_countText.color = Color.gray;

		}

		public void Unlock()
		{
			_image.color = Color.white;
			_countText.color = Color.white;
		}

	}
}