using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Data
{
	public class DataPresentationManager : MonoBehaviour
	{
		[Header("File Storage Config")]
		[SerializeField] private string fileName;
		[SerializeField] private bool useEncryption;
		
		private GameData _gameData;
		private List<IDataPersistence> dataPersistenceObjects;
		private FileDataHandler _dataHandler;
		
		public static DataPresentationManager instance { get; private set; }

		private void Awake()
		{
			if (instance != null)
			{
				Debug.Log("Found more than one Data Persistence Manager in the scene");
			}

			instance = this;
		}

		private void Start()
		{
			this._dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
			this.dataPersistenceObjects = FindAllDataPersistenceObjects();
			LoadGame();
		}

		public void NewGame()
		{
			this._gameData = new GameData();

		}

		public void LoadGame()
		{
			// Load any saved data from a file using
			this._gameData = _dataHandler.Load();

			if (this._gameData == null)
			{
				Debug.Log("No data was found.");
				NewGame();
			}
			//ToDo push the loaded data all other scriots that need it
			foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
			{
				dataPersistenceObj.LoadData(_gameData);
			}
		}

		public void SaveGame()
		{
			//ToDo pass the data to other scripts so they can uptade it 
			foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
			{
				dataPersistenceObj.SaveData(ref _gameData);
			}
			
			// save that data to a file using the data handler 
			_dataHandler.Save(_gameData);
		}

		private void OnApplicationQuit()
		{
			SaveGame();
		}

		private List<IDataPersistence> FindAllDataPersistenceObjects()
		{
			IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
				.OfType<IDataPersistence>();
			
			return new List<IDataPersistence>(dataPersistenceObjects);
		}
	}
}

 

