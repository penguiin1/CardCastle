using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using static Define;



[Serializable]
public class GameData
{

    // 저장할 데이터 목록
    //플레이어 관련
	public string jobtitle;
	public int Hp;
	public int defense;
	public int attack;
	public int Money_Soul;


    //몬스터 관련


    //수집아이템 관련
    public List<CardItem> _cardlist ;


    //UI설정관련 -- 소리크기 값

    
    public float SfxVolume =0.5f; 
    public float BgmVolume =0.5f;


}

public class GameManagerEx
{
	GameData _gameData = new GameData();
	public GameData SaveData { get { return _gameData; } set { _gameData = value; } }

	#region 프로퍼티 설정
	public string Job
	{
		get { return _gameData.jobtitle; }
		set { _gameData.jobtitle = value; }
	}


	public int Hp
	{
		get { return _gameData.Hp; }
		//set { _gameData.Hp = Mathf.Clamp(value, 0, MaxHp); }
	}

    public float BgmVolValue
    {
       get { return _gameData.BgmVolume; }
		set { _gameData.BgmVolume = value; }
    }

     public float SfxVolValue
    {
       get { return _gameData.SfxVolume; }
		set { _gameData.SfxVolume = value; }
    }

    public List<CardItem> CardList
    {
          get { return _gameData._cardlist; }
		set { _gameData._cardlist = value; }
    }


   #endregion

    




	

	

	public void StartInit()
	{   //새로하기 세팅용 
		//StartData data = Managers.Data.Start;  스타트데이터 가져와서 로딩 필요
        //아니면 수작업 작성필요

		

		
       // 예시
		//MaxHp = data.maxHp;
		//Hp = data.maxHp;
		//Money = data.money;
		  //	Hp = MaxHp;
	}

	#region Save & Load	
	public string _path = Application.persistentDataPath + "/SaveData.json";

	public void SaveGame()
	{
		string jsonStr = JsonUtility.ToJson(Managers.Game.SaveData);
		File.WriteAllText(_path, jsonStr);
		Debug.Log($"Save Game Completed : {_path}");
	}

	public bool LoadGame()
	{
		if (File.Exists(_path) == false)
			return false;

		string fileStr = File.ReadAllText(_path);
		GameData data = JsonUtility.FromJson<GameData>(fileStr);
		if (data != null)
		{
			Managers.Game.SaveData = data;
		}

		Debug.Log($"Save Game Loaded : {_path}");
		return true;
	}
	#endregion 
}
