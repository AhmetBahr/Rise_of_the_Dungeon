using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
	public interface IDataPersistence
	{
		void LoadData(GameData data);

		void SaveData(ref GameData data);

	}
}

