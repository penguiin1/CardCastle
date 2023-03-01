using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonController : MonoBehaviour
{
   public Dungeon CurDungeon ;
   public UI_ChoiceSystem ChoiceSelector ;

   public GameObject _player ; 

   public BoxCollider2D  DungeonDoor ;

   public Text DungeonTypeTxt ;
   
   public Vector3 returnpos ;

    public void RandomSelect()
    { 
        int Dun_num = Random.Range(1,8 ) ;
        CurDungeon =  Managers.Resource.Load<Dungeon>($"Prefabs/Item/Dungeon/{Dun_num}");
    }

    public void DungeonSetting(Dungeon _dungeon)
    { 
      returnpos = _player.transform.position ;
        _player.transform.position = _dungeon.spawnpos.position ;
       switch(_dungeon.Dungeon_num)
       {
        case 1 :   Dun_1();    break ;
        case 2 :   Dun_2(); break ;
        case 3 :   break ;
        case 4 :   break ;
        case 5 :   break ;
        case 6 :   break ;
        case 7 :   break ;

        default: break ;
       }
    }

    #region  roomsetting
   /*
    public void ShowRoomChoice() 
  { 
    TextClear();
     question_Text.alignment = TextAnchor.MiddleCenter;
    
    choiceIng = true ;   
   
    answer_Panel[2].SetActive(false) ;
    Card1.SetActive(false);
    Card2.SetActive(false);
     Card3.SetActive(false);

    List<string> questionlist =this.gameObject.GetOrAddComponent<Choice>().RoomQuestion ;
    _Dungeon = Managers.Resource.Load<Dungeon>("Prefabs/Item/Dungeon/1");
   
    question = this.gameObject.GetOrAddComponent<Choice>().RoomQuestion[Random.Range(0,questionlist.Count)] ; 
    question_Text.text = question ;
      result = 0 ;
      

     
      StartCoroutine(RoomTextSetting()) ;

       
       
   }

    IEnumerator RoomTextSetting()
  {    
      List<string> answer_enter =this.gameObject.GetOrAddComponent<Choice>().RoomAnswer_enter ;
      List<string> answer_quit =this.gameObject.GetOrAddComponent<Choice>().RoomAnswer_quit ;
         yield return new WaitForSeconds(0.2f) ;
       
           answerList.Add(answer_enter[Random.Range(0,answer_enter.Count)]) ;
       answer_Text[0].text = answerList[0] ;
        answer_Panel[0].SetActive(true); 
        //GameObject  Choice_1 = GetObject((int)GameObjects.Choice1_Button).gameObject;
        BindEvent(Choice_1, (PointerEventData data) => {_Player.transform.position = _Dungeon.spawnpos.position;this.gameObject.SetActive(false) ; }, Define.UIEvent.Click);
     
       yield return new WaitForSeconds(0.2f) ;

      answerList.Add(answer_quit[Random.Range(0,answer_quit.Count)]) ;
         answer_Text[1].text = answerList[1] ;
       answer_Panel[1].SetActive(true); 
          //  GameObject Choice_2 = GetObject((int)GameObjects.Choice2_Button).gameObject;
        BindEvent(Choice_2, (PointerEventData data) => { this.gameObject.SetActive(false) ; }, Define.UIEvent.Click);

       
      
  }
  */
  #endregion

    public void Dun_1()
    {    DungeonDoor.enabled = false ;
        DungeonTypeTxt.gameObject.SetActive(true);
        DungeonTypeTxt.text = CurDungeon.name ;
        ChoiceSelector.ShowRoomChoice(CurDungeon);
          ChoiceSelector.Dun1_Btn() ;
          ChoiceSelector.gameObject.SetActive(false);
          //몬스터 스폰 후 모두 처치 완료시 선택지 시스템이 뜨겠금 만들기 + 원래자리로 복귀{returnpos이용}
    }

    public void Dun_2()
    { 
       DungeonDoor.enabled = false ;
        DungeonTypeTxt.gameObject.SetActive(true);
        DungeonTypeTxt.text = CurDungeon.name ;
        ChoiceSelector.ShowRoomChoice(CurDungeon);
          ChoiceSelector.Dun2_Btn() ;
          ChoiceSelector.gameObject.SetActive(false);
          //몬스터 스폰 후 모두 처치 완료시 선택지 시스템이 뜨겠금 만들기  + 원래자리로 복귀 ; 
    }

      public void Dun_3()
    {
         DungeonTypeTxt.gameObject.SetActive(true);
         DungeonTypeTxt.text = CurDungeon.name ;
         ChoiceSelector.ShowRoomChoice(CurDungeon);
          ChoiceSelector.Dun3_Btn() ;
          ChoiceSelector.gameObject.SetActive(false);
          //몬스터 스폰 후 모두 처치 완료시 선택지 시스템이 뜨겠금 만들기 
    }
}
