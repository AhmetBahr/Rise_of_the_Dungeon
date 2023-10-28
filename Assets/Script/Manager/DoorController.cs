using System.Collections.Generic;
using UnityEngine;

namespace MapController
{
	public class DoorController : MonoBehaviour
	{
		[SerializeField] private List<GameObject> spawnPoint;
		[SerializeField] private GameObject player;
		[SerializeField] private GameObject t_PressText;
		
		private bool isLock;
		private bool inZone = false;
		
		private void Start()
		{
			isLock = true;
		}

		private void Update()
		{
			if (inZone && Input.GetKeyDown(KeyCode.E))
			{
				ClickedGate();
			}

		}

		public void OpenLocke()
		{
			//ToDo Change sprite
 		}

		public void ClickedGate()
		{
			if (isLock)
			{
				player.transform.position = spawnPoint[UnityEngine.Random.Range(0,spawnPoint.Count)].transform.position;

			}
		}



		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("Player"))
			{
				t_PressText.SetActive(true);
				inZone = true;
				
				
			}
			
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.CompareTag("Player"))
			{
				t_PressText.SetActive(false);
				inZone = false;

			}
		}
		
	}

}
