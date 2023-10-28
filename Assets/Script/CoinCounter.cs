using System.Collections;
using System.Collections.Generic;
using Data;
using Manager;
using TMPro;
using UnityEngine;

namespace UI
{
	public class CoinCounter : MonoBehaviour , IDataPersistence
	{
		private int CoinCount = 0;

		private TextMeshProUGUI PlayerMoneyText;

		private void Awake() 
		{
			PlayerMoneyText = this.GetComponent<TextMeshProUGUI>();
		}

		private void Start() 
		{
			// subscribe to events
			GameEventsManager.instance.onCoinCollected += OnCollectedCoin;
		}

		public void LoadData(GameData data)
		{
			this.CoinCount = data.PlayerCoin;
		}

		public void SaveData(ref GameData data)
		{
			data.PlayerCoin = this.CoinCount;
		}
		
		private void OnDestroy() 
		{
			// unsubscribe from events
			GameEventsManager.instance.onCoinCollected -= OnCollectedCoin;
		}

		private void OnCollectedCoin() 
		{
			CoinCount++;
		}

		private void Update() 
		{
			PlayerMoneyText.text = "Coin: " + CoinCount;
		}
	}

}
