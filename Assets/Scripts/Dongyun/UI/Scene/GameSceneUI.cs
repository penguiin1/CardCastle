using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class GameSceneUI : UI_Popup
{ 
  
  public GameObject Inven ;
  public GameObject ChoiceSystem ; 

  public GameObject On1 ;
   public GameObject On2 ;
 public GameObject On3 ;
  public bool GetCardScroll ;

  public bool CardChoicing = false ;
  
  public GameObject Player; 
  public PlayerInput _Player ;
 
 public List<CardItem> CurCardList ;
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
            _choice.ShowRoomChoice() ;
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

    public void CardSelectSetting_1()
    {
            CurCardList  = Util.FindChild(Inven,"Inventory_Base").GetComponent<Inventory>().CurCard_list ;
            CardItem SelectedCard = CurCardList[Random.Range(0, CurCardList.Count+1)] ;
            if(selector2._Card!=null &&selector3._Card!=null )
            {
                while(true)
               { 
                  SelectedCard = CurCardList[Random.Range(0, CurCardList.Count+1)] ;
                  if(SelectedCard.num !=selector2._Card.num &&SelectedCard.num !=selector3._Card.num )
                  {
                    selector1.Setting(SelectedCard) ;
                    break ;
                   }
                }
            }
            else   selector1.Setting(SelectedCard) ;
         
    }
      public void CardSelectSetting_2()
    {
            CurCardList  = Util.FindChild(Inven,"Inventory_Base").GetComponent<Inventory>().CurCard_list ;

            CardItem SelectedCard = CurCardList[Random.Range(0, CurCardList.Count+1)] ;
            if(selector1._Card!=null &&selector3._Card!=null )
            {
                while(true)
               { 
                  SelectedCard = CurCardList[Random.Range(0, CurCardList.Count+1)] ;
                  if(SelectedCard.num !=selector1._Card.num &&SelectedCard.num !=selector3._Card.num )
                  {
                    selector2.Setting(SelectedCard) ;
                    break ;
                   }
                }
            }
            else   selector2.Setting(SelectedCard) ;
    }

      public void CardSelectSetting_3()
    {
            CurCardList  = Util.FindChild(Inven,"Inventory_Base").GetComponent<Inventory>().CurCard_list ;
          CardItem SelectedCard = CurCardList[Random.Range(0, CurCardList.Count+1)] ;
            if(selector1._Card!=null &&selector2._Card!=null )
            {
                while(true)
               { 
                  SelectedCard = CurCardList[Random.Range(0, CurCardList.Count+1)] ;
                  if(SelectedCard.num !=selector1._Card.num &&SelectedCard.num !=selector2._Card.num )
                  {
                    selector3.Setting(SelectedCard) ;
                    break ;
                   }
                }
            }
            else   selector3.Setting(SelectedCard) ;
    }

    
}
