using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Lobby : UI_Popup
{
    
   // public GameObject SettingCanvas ;
    enum GameObjects
    {
        ExitButton,
        SettingButton,
        GameStartButton,
    }

    public GameObject SettingCanvas ;

    private void Start()
    {
        Init();
     

     	

        

       
     
    }

    public override void Init()
    { 
        base.Init();
         Bind<GameObject>(typeof(GameObjects));
       GameObject Start = GetObject((int)GameObjects.GameStartButton).gameObject;
       GameObject Setting = GetObject((int)GameObjects.SettingButton).gameObject;
       GameObject Exit = GetObject((int)GameObjects.ExitButton).gameObject;

       BindEvent(Start, (PointerEventData data) => { SceneManager.LoadScene(1); }, Define.UIEvent.Click);
       BindEvent(Setting,OnButtonClicked);  
       BindEvent(Exit, (PointerEventData data) => { Application.Quit(); }, Define.UIEvent.Click);
	   
        Managers.Sound.Clear();
        Managers.Sound.Play("Prefabs/Sounds/LobbyBgm",Define.Sound.Bgm) ; 
       
		

		
	}

  

    public void OnButtonClicked(PointerEventData data)
    {
        
       Managers.UI.ShowPopupUI<UI_setting1>("UI_SettingCanvas") ;
       
    }

}
