using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public  bool  indoor  ;

    public bool outdoor ;
    public bool cardscroll  ; 

    public CardItem SelectedCard ;
    

    void Start()
    {
        
    }
    public void PlayerRMove()
    {
        transform.Translate(2.5f, 0, 0);
    }
    public void PlayerLMove()
    {
        transform.Translate(-2.5f, 0, 0);
    }


void OnTriggerEnter2D(Collider2D other)
{
    Debug.Log("충돌 발생!");
} 


void OnTriggerStay2D(Collider2D other)
{    Debug.Log("문충돌!");
     if(other.CompareTag("Door"))
        {   
           indoor = true ;
        }

       if(other.CompareTag("DungeonDoor"))
        {   
           outdoor = true ;
        }   
    if(other.CompareTag("Scroll") )
    {
         cardscroll = true ; 
    }
} 

void OnTriggerExit2D(Collider2D other)
{    Debug.Log("콜라이더 나감!");
     
    indoor = false ;

    outdoor = false ;
    
    cardscroll = false ; 
    
} 


 
}
