using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
 public Dictionary<int, Stat> StatDict { get; private set; } = new Dictionary<int, Stat>();
 

    public void Init()
    {
        StatDict = LoadJson<StatData, int, Stat>("StatData").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
		TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
	}

#region Save
/*private static string SavePath => Application.persistentDataPath + "/saves/";

		public static void Save(SaveData saveData, string saveFileName)
		{
			if(!Directory.Exists(SavePath))
			{
				Directory.CreateDirectory(SavePath);
			}

			string saveJson = JsonUtility.ToJson(saveData);

			string saveFilePath = SavePath + saveFileName + ".json";
			File.WriteAllText(saveFilePath, saveJson);
			Debug.Log("Save Success: " + saveFilePath);
		}

		public static SaveData Load(string saveFileName)
		{
			string saveFilePath = SavePath + saveFileName + ".json";
			
			if(!File.Exists(saveFilePath))
			{
				Debug.LogError("No such saveFile exists");
				return null;
			}

			string saveFile = File.ReadAllText(saveFilePath);
			SaveData saveData = JsonUtility.FromJson<SaveData>(saveFile);
			return saveData;
		}
	}
   */
   #endregion

}
