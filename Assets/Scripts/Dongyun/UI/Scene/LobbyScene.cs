using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyScene :BaseScene
{
    protected override bool Init()
    {
		if (base.Init() == false)
			return false;

        SceneType = Define.Scene.Lobby;
		Managers.UI.ShowPopupUI<UI_Lobby>("UI_Lobby");
		Debug.Log("Init");
		return true;
	}
}
