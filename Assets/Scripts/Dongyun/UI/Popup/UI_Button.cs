using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Button : UI_Popup
{

    enum GameObjects
    {
        ExitButton,
        SettingButton,
        GameStartButton,
    }

    

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
       BindEvent(Setting, (PointerEventData data) => {  }, Define.UIEvent.Click);   // 아직 ui제작안함
       BindEvent(Exit, (PointerEventData data) => { Application.Quit(); }, Define.UIEvent.Click);
		

		//GetButton((int)Buttons.PointButton).gameObject.BindEvent(OnButtonClicked);

		//GameObject go = GetImage((int)Images.ItemIcon).gameObject;
		//BindEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
	}

  

    public void OnButtonClicked(PointerEventData data)
    {
        
    }

}
