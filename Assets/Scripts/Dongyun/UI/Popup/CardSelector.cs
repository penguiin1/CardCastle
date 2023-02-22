using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelector : MonoBehaviour
{
    public CardItem _Card ; 
    public Image CardImage ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 public   void Setting(CardItem _card)
    {
       _Card = _card ;
       CardImage.sprite = _Card.Card_Image ;
    }
}
