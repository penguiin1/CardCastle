using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : UI_Popup{

    public static bool inventoryActivated = false;

    


    // 필요한 컴포넌트
    [SerializeField]
     GameObject go_InventoryBase ;
    [SerializeField]
     GameObject go_SlotsParent;

     public  List<CardItem> CurCard_list ;

    // 슬롯들.
    public Slot[] slots;
     

    //   Managers.Resource.Load<CardItem>($"Prefabs/Item/Card/{Lottery[i]}");

  


    // Use this for initialization
    void Start()
    {   
       
        Init() ;
        
    }

    void Update()
    {
        
    }
 
    // Update is called once per frame
   public override void Init()
   {     
          slots = go_SlotsParent.GetComponentsInChildren<Slot>();
        foreach(var slot in slots)
        {
            slot.gameObject.SetActive(false) ;
        } 
        
       
          base.Init() ;
        
          
   }
    public void TryOpenInventory( )
    {
   
            inventoryActivated = !inventoryActivated;

            if (inventoryActivated)
                OpenInventory();
            else
                CloseInventory();
        
    }

    public void OpenInventory()
    {
        go_InventoryBase.SetActive(true);
    }

    public void CloseInventory()
    {
        go_InventoryBase.SetActive(false);
    }

    public void AcquireCard(CardItem _card, int _count = 1)
    {
       
            for (int i = 0; i < slots.Length; i++)
            {
                if(slots[i].card != null)
                {
                    if (slots[i].card.num == _card.num)
                    {  
                        
                        slots[i].SetSlotCount(_count);
                       
                         CurCard_list.Add(_card) ;
                         

                        return;
                    }
                }
            }
      

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].card == null)
            { 
                slots[i].AddCard(_card, _count);
               CurCard_list.Add(_card) ;
               
                return;
            }
        }
    }
    public void  closeall()
    {
       Managers.UI.CloseAllPopupUI() ; 
    }

  
}
