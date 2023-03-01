using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class GameSceneUI : UI_Popup
{ 
  
  public GameObject Inven ;
  public Inventory InvenBase ;
  public GameObject ChoiceSystem ; 

  public GameObject On1 ;
   public GameObject On2 ;
 public GameObject On3 ;
  public bool GetCardScroll ;

  public bool CardChoicing = false ;
  
  public GameObject Player; 
  public PlayerInput _Player ;
 


  public CardSelector selector1;
  public CardSelector selector2;
  public CardSelector selector3;
   enum GameObjects
   {
      ActBtn,
      SettingBtn,
      InventoryBtn ,
      CardSelect1,
      CardSelect2,
      CardSelect3,
  
      
   }
    void Start()
    {   
       
          Init() ;
      
    }

    void Update()
    {
       
    }
    void LateUpdate()
    {
        if(selector1._Card ==null) CardSelectSetting_1() ;
         if(selector2._Card ==null) CardSelectSetting_2() ;
         if(selector3._Card ==null) CardSelectSetting_3() ;
    }

    public override void Init()
    {
        base.Init();
       Bind<GameObject>(typeof(GameObjects));
       Inven.SetActive(true) ;
       Inven.SetActive(false) ;
        
       GameObject Setting = GetObject((int)GameObjects.SettingBtn).gameObject;
       GameObject Inventory = GetObject((int)GameObjects.InventoryBtn).gameObject;
       GameObject ActButton = GetObject((int)GameObjects.ActBtn).gameObject;
       GameObject CardSelect1 = GetObject((int)GameObjects.CardSelect1).gameObject;
      GameObject CardSelect2 = GetObject((int)GameObjects.CardSelect2).gameObject;
      GameObject CardSelect3 = GetObject((int)GameObjects.CardSelect3).gameObject;
      selector1 = CardSelect1.GetComponent<CardSelector>() ;
      selector2 = CardSelect2.GetComponent<CardSelector>() ;
      selector3 = CardSelect3.GetComponent<CardSelector>() ;
      
        StartCoroutine(SlotSetting()) ;
       
       
      
        BindEvent(Setting,OnbuttonSetting,Define.UIEvent.Click);  
       BindEvent(ActButton,actbtncontroller,Define.UIEvent.Click);  
        BindEvent(Inventory,invenopen,Define.UIEvent.Click);  
          BindEvent(CardSelect1,(PointerEventData date)=>{if(CardChoicing==false){On1.SetActive(true); On2.SetActive(false);On3.SetActive(false);CardChoicing =true;}else{On1.SetActive(false); On2.SetActive(false);On3.SetActive(false);CardChoicing =false;}} ,Define.UIEvent.Click);  
          BindEvent(CardSelect2,(PointerEventData date)=>{if(CardChoicing==false){On1.SetActive(false); On2.SetActive(true);On3.SetActive(false);CardChoicing =true;}else{On1.SetActive(false); On2.SetActive(false);On3.SetActive(false);CardChoicing =false;}} ,Define.UIEvent.Click);  
          BindEvent(CardSelect3,(PointerEventData date)=>{if(CardChoicing==false){On1.SetActive(false); On2.SetActive(false);On3.SetActive(true);CardChoicing =true;}else{On1.SetActive(false); On2.SetActive(false);On3.SetActive(false);CardChoicing =false;}} ,Define.UIEvent.Click);  
        
        Managers.Sound.Clear();
        Managers.Sound.Play("Prefabs/Sounds/BGM_Ingame",Define.Sound.Bgm) ; 
	
    }

    IEnumerator SlotSetting()
    {  
         Inven.SetActive(true) ;
        yield return 0.1f ;
        Inven.SetActive(false) ;

    }


    public void  closeButton()
    {
       Managers.UI.CloseAllPopupUI() ; 
    }

    void OnbuttonSetting(PointerEventData evt)
    {
          	Managers.UI.ShowPopupUI<UI_setting1>("UI_SettingCanvas");
       
    }

    void invenopen(PointerEventData data)
    {
       
         Inven.SetActive(true) ;
    }
     public   void invenclose()
    {
        
         Inven.SetActive(false) ;
    }

    public void actbtncontroller(PointerEventData data)
    {  
        if(CardChoicing == true)
        {
           return ; 
        } 


        if(_Player.indoor==true)
        {   Debug.Log("들어갈꺼야?!");
            ChoiceSystem.SetActive(true) ;
            UI_ChoiceSystem _choice  =  ChoiceSystem.GetComponent<UI_ChoiceSystem>() ;
            //_choice.ShowRoomChoice() ;
            return ;
           
        }

   

        if(_Player.cardscroll==true)
        {
                   Debug.Log("어떤 카드를 고를래?");
            ChoiceSystem.SetActive(true) ;
            UI_ChoiceSystem _choice  =  ChoiceSystem.GetComponent<UI_ChoiceSystem>() ;
            _choice.ShowCardChoice() ;
              return ;
        }
    }

    public void CardSelectSetting_1()  //중복처리 해결 x
    {       int num = Random.Range(0, InvenBase.CurCard_list.Count);
          
            CardItem SelectedCard =  InvenBase.CurCard_list[num] ;
            InvenBase.CurCard_list.RemoveAt(num) ; 

            InvenBase.UsedCard.Add(SelectedCard) ;
            selector1.Setting(SelectedCard) ;
            int _count = 0 ;
           foreach(var _card in InvenBase.CurCard_list)
           {
               if(_card.num == SelectedCard.num)
               {
                _count ++ ;
               }

           }
           if(_count ==0)
           {
              foreach(var _slot in InvenBase.slots)
              {
                 if(_slot.card.num == SelectedCard.num) _slot.LockImage.SetActive(true) ; 
              }
           }

            
         
    }
      public void CardSelectSetting_2()
    {
              int num = Random.Range(0, InvenBase.CurCard_list.Count);
          
            CardItem SelectedCard =  InvenBase.CurCard_list[num] ;
            InvenBase.CurCard_list.RemoveAt(num) ; 

            InvenBase.UsedCard.Add(SelectedCard) ;
            selector2.Setting(SelectedCard) ;
            int _count = 0 ;
           foreach(var _card in InvenBase.CurCard_list)
           {
               if(_card.num == SelectedCard.num)
               {
                _count ++ ;
               }

           }
           if(_count ==0)
           {
              foreach(var _slot in InvenBase.slots)
              {
                 if(_slot.card.num == SelectedCard.num) _slot.LockImage.SetActive(true) ; 
              }
           }
             
    }

      public void CardSelectSetting_3()
    {
            int num = Random.Range(0, InvenBase.CurCard_list.Count);
          
            CardItem SelectedCard =  InvenBase.CurCard_list[num] ;
            InvenBase.CurCard_list.RemoveAt(num) ; 

            InvenBase.UsedCard.Add(SelectedCard) ;
            selector3.Setting(SelectedCard) ;
            int _count = 0 ;
           foreach(var _card in InvenBase.CurCard_list)
           {
               if(_card.num == SelectedCard.num)
               {
                _count ++ ;
               }

           }
           if(_count ==0)
           {
              foreach(var _slot in InvenBase.slots)
              {
                 if(_slot.card.num == SelectedCard.num) _slot.LockImage.SetActive(true) ; 
              }
           }
    }

    
}
