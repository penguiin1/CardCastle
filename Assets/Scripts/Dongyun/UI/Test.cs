using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : UI_Popup
{
    public List<CardItem> card_List;
        enum GameObjects
    {
        card1,
        card2,
        card3,
    }
    public int num; 
    
        public override void Init()
    {
        

	}
    
    // Start is called before the first frame update
    void Start()
    {  
        Image[] cardimagelist = new Image[3] ;
        Bind<GameObject>(typeof(GameObjects));
       

       Image card1_image = GetObject((int)GameObjects.card1).gameObject.GetComponent<Image>() ;
        Image card2_image = GetObject((int)GameObjects.card2).gameObject.GetComponent<Image>() ;
        Image card3_image = GetObject((int)GameObjects.card3).gameObject.GetComponent<Image>() ;
       
       cardimagelist[0] = card1_image;
       cardimagelist[1] = card2_image;
       cardimagelist[2] = card3_image;

        for(int i=0; i<3;i++)
        {
           num = Random.Range(1,3);
         CardItem test = Managers.Resource.Load<CardItem>($"Prefabs/Item/Card/{num}");
          card_List.Add(test) ; 
            cardimagelist[i].sprite = test.Card_Image ;
          
        }
     
        Init() ;
      
    }

}
