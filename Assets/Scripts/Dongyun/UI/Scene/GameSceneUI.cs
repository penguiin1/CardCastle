using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameSceneUI : UI_Popup
{ 

    public GameObject SettingCanvas ;
    public GameObject Inventory ;
   enum GameObjects
   {
      ActBtn,
      SettingBtn,
      InventoryBtn ,
   }
    void Start()
    {
        Init() ;
       Managers.Sound.Play("Prefabs/Sounds/BGM_Ingame",Define.Sound.Bgm) ; 
    }

    public override void Init()
    {
        base.Init();
       Bind<GameObject>(typeof(GameObjects));

        
       GameObject Setting = GetObject((int)GameObjects.SettingBtn).gameObject;
       GameObject Inventory = GetObject((int)GameObjects.InventoryBtn).gameObject;

      
       BindEvent(Setting,OnSetting,Define.UIEvent.Click);  
       BindEvent(Inventory,OpenInven,Define.UIEvent.Click);  
	
    }

    public void OnSetting(PointerEventData data)
    {
        
        Managers.UI.ShowPopupUI<Ui_Setting>("SettingCanvas") ;
     
    }

    public void  closeall()
    {
       Managers.UI.CloseAllPopupUI() ; 
    }
    public void OpenInven(PointerEventData data)
    {
        Inventory.SetActive(true) ;
    }
     public void CloseInven()
    {
        Inventory.SetActive(false) ;
    }
}
