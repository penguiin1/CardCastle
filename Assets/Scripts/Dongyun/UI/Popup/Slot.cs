using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : UI_Popup 
{

    public CardItem card; // 획득한 아이템.
    public int CardCount; // 획득한 아이템의 개수.
    public Image CardImage; // 아이템의 이미지.

    public Text CardExplainText ;
    public Image CardExplainImage ;

  
    // 필요한 컴포넌트.
    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;


    void start()
    {
      /*     EventTrigger eventTrigger = gameObject.AddComponent<EventTrigger>();
      
       EventTrigger.Entry clickevt  =new EventTrigger.Entry() ;
       clickevt.eventID = EventTriggerType.PointerClick ; 
       clickevt.callback.AddListener(SlotInfo) ;
        eventTrigger.triggers.Add(clickevt); */
         //  BindEvent(this.gameObject, SlotInfo, Define.UIEvent.Click);

    }

  
    // 이미지의 투명도 조절.
    private void SetColor(float _alpha)
    {
        Color color = CardImage.color;
        color.a = _alpha;
        CardImage.color = color;
    }

    // 아이템 획득
    public void AddCard(CardItem _card, int _count = 1)
    {   this.gameObject.SetActive(true);
        card = _card;
        CardCount = _count;
        CardImage.sprite = _card.Card_Image;

  
            go_CountImage.SetActive(true);
            text_Count.text = CardCount.ToString();
        
      

        SetColor(1);
    }

    // 아이템 개수 조정.
    public void SetSlotCount(int _count)
    {
        CardCount += _count;
        text_Count.text = CardCount.ToString();

        if (CardCount <= 0)
            ClearSlot();
    }

    // 슬롯 초기화.
    private void ClearSlot()
    {
        card = null;
        CardCount = 0;
        CardImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }

   public void SlotInfo()
    {   
        if(this.card!=null)
        {
           CardExplainText.text = card.explain ;
           CardExplainImage.sprite = card.Card_Image ; 
        }
        Debug.Log("연결완료") ;
    }
}