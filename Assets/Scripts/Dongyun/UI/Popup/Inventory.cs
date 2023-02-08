using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : UI_Popup{

    public static bool inventoryActivated = false;


   enum CardSlot{


   }
    // 필요한 컴포넌트
    [SerializeField]
     GameObject go_InventoryBase ;
    [SerializeField]
     GameObject go_SlotsParent;

    // 슬롯들.
    public Slot[] slots;


    // Use this for initialization
    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();
        go_InventoryBase.SetActive(false) ;
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                        return;
                    }
                }
            }
      

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].card == null)
            {
                slots[i].AddCard(_card, _count);
                return;
            }
        }
    }
}
