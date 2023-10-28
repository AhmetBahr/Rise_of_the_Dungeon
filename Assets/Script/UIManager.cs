using System.Collections;
using DG.Tweening;
using Player;
using UnityEngine;

namespace UI
{
	public class UIManager : MonoBehaviour
	{
		[Header("Canvas")]
		[SerializeField] private RectTransform  C_Inventory;

		[field:SerializeField] public bool isC_InventoryOpen = false;
		private void Update()
		{
			PanelTurn();
		}

		private void PanelTurn()
		{
			if(Input.GetKeyDown(KeyCode.C) && !isC_InventoryOpen)
			{
				C_Inventory.DOAnchorPos(new Vector2(0, 0), 0f);
				PlayerMovement.instance.canMove = false;
				isC_InventoryOpen = true;

			}
			else if (Input.GetKeyDown(KeyCode.C) && isC_InventoryOpen)
			{
				C_Inventory.DOAnchorPos(new Vector2(-2000, 0), 0f);
				PlayerMovement.instance.canMove = true; 
				isC_InventoryOpen = false;
			}
			

		}

	}
}