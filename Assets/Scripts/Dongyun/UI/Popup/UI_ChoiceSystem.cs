
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ChoiceSystem : UI_Popup
{
   public GameObject _Player ;
    public string question;
    public List<string> answerList; 
    
    public  Text question_Text;
    public Text[] answer_Text ; 
    
    public GameObject[] answer_Panel ; 
    public GameObject  Choice_1 ;
     public GameObject  Choice_2 ;
      public GameObject  Choice_3 ;


    public GameObject Card1;
    public GameObject Card2;

    public GameObject Card3;
     
     
     public  List<CardItem> card_List;

     
  
  

     public Dungeon _Dungeon ;
      

    public Inventory _inven ;
    private int count ;
    private int result ;

    public int Cardcount =3 ; 


    private WaitForSeconds waitTime = new WaitForSeconds(0.01f) ; 
    public bool choiceIng ; 
    
      enum GameObjects
    {
 
        ExplainImage  ,
      
    }

    void Start()
    {    
          Init() ;
      	

     
      answerList = new List<string>();
     
      for(int i=0; i<=2; i++)
      {
         answer_Text[i].text = " ";
         answer_Panel[i].SetActive(false) ;
      }
      
    }

    public override void Init()
    {
        base.Init();
       	Bind<GameObject>(typeof(GameObjects));
       
   
	}

  public void ShowRoomChoice(Dungeon _dungeon) 
  { 
    TextClear();
     question_Text.alignment = TextAnchor.MiddleCenter;
    
    choiceIng = true ;   
     answer_Panel[0].SetActive(false) ;
    answer_Panel[1].SetActive(false) ;
    answer_Panel[2].SetActive(false) ;
    Card1.SetActive(false);
    Card2.SetActive(false);
     Card3.SetActive(false);
   
   
    
    question_Text.text = _dungeon.Dungeon_Explain;
      result = 0 ;
      

     
      StartCoroutine(RoomTextSetting(_dungeon)) ;

       
       
   }

    IEnumerator RoomTextSetting(Dungeon _dungeon)
  {    
    foreach(string _answer in _dungeon.Room_AnswerList)
    {
        answerList.Add(_answer) ;
    }
      
         
       
     for(int i=0 ; i<_dungeon.Room_AnswerList.Count; i++)
     {
         answer_Panel[i].SetActive(true);
         answer_Text[i].text = answerList[i] ;

         yield return new WaitForSeconds(0.2f) ;

     }

     
   }
  #region DungeonBtn 관리
   public void Dun1_Btn()
   {
       // 버튼 설정 필요
        //GameObject  Choice_1 = GetObject((int)GameObjects.Choice1_Button).gameObject;
       // BindEvent(Choice_1, (PointerEventData data) => {_Player.transform.position = _Dungeon.spawnpos.position;this.gameObject.SetActive(false) ; }, Define.UIEvent.Click);
       //  GameObject Choice_2 = GetObject((int)GameObjects.Choice2_Button).gameObject;
        //BindEvent(Choice_2, (PointerEventData data) => { this.gameObject.SetActive(false) ; }, Define.UIEvent.Click);
   }
     public void Dun2_Btn()
     {

     }

       public void Dun3_Btn()
     {
      
     }

        public void Dun4_Btn()
     {
      
     }

        public void Dun5_Btn()
     {
      
     }

        public void Dun6_Btn()
     {
      
     }

        public void Dun7_Btn()
     {
      
     }
    

    #endregion

    public void ShowCardChoice( )  
  { 
    TextClear();
    
    card_List = new List<CardItem>(); 
    answerList.Clear() ;
    choiceIng = true ;   
    

      result = 0 ;
    
     question = "나는 방에 들어서자, 그곳이 몬스터들이 지키고있는 보물창고라는 사실을 알아챘다.귀중한 유물 옆에서 검을 들고 노려보고있는 해골들을 보았기 때문이다.그들은 유물을 지키기위해 그곳을 떠날것같지 않았다. 나의 성공과 관련해 저 유물은" ;
     question_Text.alignment = TextAnchor.UpperCenter;
     question_Text.text = question ;
    	
    CardImageSetting() ;

    StartCoroutine(CardTextSetting()) ;


     


   
  }

  IEnumerator CardTextSetting()
  {   
        
         yield return new WaitForSeconds(0.2f) ;
        Card1.SetActive(true);
        answerList.Add($"책의 첫부분을 읽었다.{ card_List[0]._name}를 획득합니다") ;
       answer_Text[0].text = answerList[0] ;
        answer_Panel[0].SetActive(true); 
        //GameObject  Choice_1 = GetObject((int)GameObjects.Choice1_Button).gameObject;
        BindEvent(Choice_1, (PointerEventData data) => { _inven.AcquireCard(card_List[0]); this.gameObject.SetActive(false) ; }, Define.UIEvent.Click);
     
       yield return new WaitForSeconds(0.2f) ;
      Card2.SetActive(true);
      answerList.Add($"책의 중간부분을 읽었다.{ card_List[1]._name}를 획득합니다") ;
         answer_Text[1].text = answerList[1] ;
       answer_Panel[1].SetActive(true); 
          //  GameObject Choice_2 = GetObject((int)GameObjects.Choice2_Button).gameObject;
        BindEvent(Choice_2, (PointerEventData data) => { _inven.AcquireCard(card_List[1]);this.gameObject.SetActive(false) ; }, Define.UIEvent.Click);

       yield return new WaitForSeconds(0.2f) ;
       Card3.SetActive(true);
       answerList.Add($"책의 마지막부분을 읽었다.{ card_List[2]._name}를 획득합니다") ;
         answer_Panel[2].SetActive(true); 
           answer_Text[2].text = answerList[2] ;
         //GameObject Choice_3 = GetObject((int)GameObjects.Choice3_Button).gameObject;
        BindEvent(Choice_3, (PointerEventData data) => { _inven.AcquireCard(card_List[2]);this.gameObject.SetActive(false) ; }, Define.UIEvent.Click);
  }

  public void CardImageSetting()
  {
    Image[] cardimagelist = new Image[3] ;
       
       

       Image card1_image = Card1.GetComponent<Image>() ;
        Image card2_image = Card2.GetComponent<Image>() ;
        Image card3_image =Card3.GetComponent<Image>() ;
       
       cardimagelist[0] = card1_image;
       cardimagelist[1] = card2_image;
       cardimagelist[2] = card3_image;
       int[] Lottery  = new int[3];

for (int i = 0; i < 3; i++)

{

    Lottery[i] = Random.Range(1, Cardcount+1);

 

    for (int j = 0; j <= i ; j++) //현재 발생시킨 지점까지 검색해서 같은수 비교

    {

        if (Lottery[i] == Lottery[j] && j != i)

        {

            i = i - 1; // 같은수 있으면 i하나 감소해서 다시 발생

        }

    }

}
        for(int i=0; i<3;i++)
        {
          
         CardItem test = Managers.Resource.Load<CardItem>($"Prefabs/Item/Card/{Lottery[i]}");
          card_List.Add(test) ; 
            cardimagelist[i].sprite = test.Card_Image ;
          
        }
  }

    public void ShowWeaponChoice( )  //미완성
  {    return ;
   
  }
    
 
  public int GetResult()
  {
    return result ;
  }
    public void ExitChoice()
    {
      for(int i=0; i<=count; i++)
      {
        answer_Text[i].text ="";
        answer_Panel[i].SetActive(false) ;
        
      }
     
       question_Text.text ="" ; 
         choiceIng = false ;
    }

 void TextClear()
 {
   question_Text.text ="" ;
   answer_Text[0].text= "" ; 
    answer_Text[1].text= "";
    answer_Text[2].text= "" ;
     answerList.Clear(); 
 }

}
