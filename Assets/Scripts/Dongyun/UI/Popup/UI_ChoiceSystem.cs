using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ChoiceSystem : UI_Popup
{
    private string question;
    public List<string> answerList; 
    
    public  Text question_Text;
    public Text[] answer_Text ; 
    public GameObject go ;
    public GameObject[] answer_Panel ; 

    public GameObject Card1;
    public GameObject Card2;

    public GameObject Card3;
  
     public  List<CardItem> card_List;
      

    public Inventory _inven ;
    private int count ;
    private int result ;

    public int Cardcount =3 ; 


    private WaitForSeconds waitTime = new WaitForSeconds(0.01f) ; 
    public bool choiceIng ; 
    
      enum GameObjects
    {
        Choice1_Button,
        Choice2_Button,
        Choice3_Button,
 
        ExplainImage  ,
    }

    void Start()
    {    go.SetActive(false) ;
          Init() ;
      		Bind<GameObject>(typeof(GameObjects));

     
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

   
	}

  public void ShowRoomChoice() 
  { 
    TextClear();
     question_Text.alignment = TextAnchor.MiddleCenter;
    go.SetActive(true) ;
    choiceIng = true ;   
   
    answer_Panel[2].SetActive(false) ;
    Card1.SetActive(false);
    Card2.SetActive(false);
     Card3.SetActive(false);

    List<string> questionlist =this.gameObject.GetOrAddComponent<Choice>().RoomQuestion ;
     List<string> answerlist_enter =this.gameObject.GetOrAddComponent<Choice>().RoomAnswer_enter ;
      List<string> answerlist_quit =this.gameObject.GetOrAddComponent<Choice>().RoomAnswer_quit ;
    question = this.gameObject.GetOrAddComponent<Choice>().RoomQuestion[Random.Range(0,questionlist.Count)] ; 
      result = 0 ;
      

        answerList.Add(answerlist_enter[Random.Range(0,answerlist_enter.Count)]) ;
        answer_Panel[0].SetActive(true); 

       answerList.Add(answerlist_quit[Random.Range(0,answerlist_enter.Count)]) ;
        answer_Panel[1].SetActive(true); 


  
       count = 1 ; 
     StartCoroutine(ChoiceCoroutine()) ; 
   
  }
    public void ShowCardChoice( )  
  { 
    TextClear();
     go.SetActive(true) ;
    card_List = new List<CardItem>(); 
    choiceIng = true ;   
    

      result = 0 ;
     List<string> questionlist =this.gameObject.GetOrAddComponent<Choice>().CardQuestion ;
     question = questionlist[Random.Range(0,questionlist.Count)] ;
     question_Text.alignment = TextAnchor.UpperCenter;
    
    CardImageSetting() ;




       Card1.SetActive(true);
       
       answerList.Add($"책의 첫부분을 읽었다.{ card_List[0]._name}를 획득합니다") ;
        answer_Panel[0].SetActive(true); 
        GameObject  Choice_1 = GetObject((int)GameObjects.Choice1_Button).gameObject;
        BindEvent(Choice_1, (PointerEventData data) => { _inven.AcquireCard(card_List[0]); }, Define.UIEvent.Click);


      Card2.SetActive(true);
      answerList.Add($"책의 중간부분을 읽었다.{ card_List[1]._name}를 획득합니다") ;
       answer_Panel[1].SetActive(true); 
            GameObject Choice_2 = GetObject((int)GameObjects.Choice2_Button).gameObject;
        BindEvent(Choice_2, (PointerEventData data) => { _inven.AcquireCard(card_List[1]); }, Define.UIEvent.Click);


       Card3.SetActive(true);
       answerList.Add($"책의 마지막부분을 읽었다.{ card_List[2]._name}를 획득합니다") ;
         answer_Panel[2].SetActive(true); 
         GameObject Choice_3 = GetObject((int)GameObjects.Choice3_Button).gameObject;
        BindEvent(Choice_3, (PointerEventData data) => { _inven.AcquireCard(card_List[2]); }, Define.UIEvent.Click);


     count = 2 ;
     StartCoroutine(ChoiceCoroutine()) ; 
   
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

    public void ShowWeaponChoice(Choice _choice)  //미완성
  {    return ;
   
  }
    

    IEnumerator ChoiceCoroutine()
   {
       yield return new WaitForSeconds(0.2f) ;
       StartCoroutine(TypingQuestion());
        StartCoroutine(TypingAnswer_1());
        if(count >=1)  StartCoroutine(TypingAnswer_2());
       if(count >=2)  StartCoroutine(TypingAnswer_3());

       yield return new WaitForSeconds(0.5f); 
       
   }

   IEnumerator TypingQuestion()
   {
     for(int i=0; i< question.Length ; i++)
     {
       question_Text.text += question[i] ;
       yield return waitTime ;
     }
   }
   
   IEnumerator TypingAnswer_1()
   {
     for(int i=0; i< answerList[0].Length ; i++)
     {
       answer_Text[0].text += answerList[0][i] ;
       yield return waitTime ;
     }
   }
    IEnumerator TypingAnswer_2()
   {
     for(int i=0; i< answerList[1].Length ; i++)
     {
       answer_Text[1].text += answerList[1][i] ;
       yield return waitTime ;
     }
   }
    IEnumerator TypingAnswer_3()
   {
     for(int i=0; i< answerList[2].Length ; i++)
     {
       answer_Text[2].text += answerList[2][i] ;
       yield return waitTime ;
     }
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
