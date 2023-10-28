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
		[SerializeField] private bool unlocked;
		
		private int currentCount;

		[SerializeField] private Skill[] ChildSkills;
		
		private void Awake()
		{
			_image = GetComponent<Image>();

			if (unlocked)
			{
				Unlock();
				
			}
		}

		public bool Cliced()
		{
			if (currentCount < maxCount && unlocked)
			{
				currentCount++;
				_countText.text = $"{currentCount}/{maxCount}";

				if (currentCount == maxCount)
				{
					foreach (var talent in ChildSkills)
					{
						if (talent != null)
						{
							talent.Unlock();
						}
					}
				}
				
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

			unlocked = true;
		}

	}
}