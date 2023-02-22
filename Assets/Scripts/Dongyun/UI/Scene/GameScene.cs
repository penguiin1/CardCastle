using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScene : BaseScene
{
	 public List<CardItem> FirstcardSetting ;
    protected override bool Init()
    {
		if (base.Init() == false)
			return false;

        SceneType = Define.Scene.Game;
		//Managers.UI.ShowPopupUI<GameSceneUI>("UI_GameScene");
		 
		Debug.Log("Init");
         
        


		return true;
	}
}
