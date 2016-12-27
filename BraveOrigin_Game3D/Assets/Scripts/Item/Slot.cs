using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour ,IDropHandler{

    public int id;    

    public bool remainItem;
    private Inventory inv;
    GameObject slotPanel;
    PlayerStatus ps;

	void Start () {
        inv = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        slotPanel = GameObject.Find("Slot Panel");
        ps = GameObject.Find("Player").GetComponent<PlayerStatus>();
	}

    void Update()
    {
            if (id == 30 && this.transform.childCount == 0)
                ps.item_Damage = 0;
            //---------------

            if (id == 31 && this.transform.childCount == 0)
                ps.item_Def = 0;
            //--------------
            
            if (id == 32 && this.transform.childCount == 0)
                ps.item_Speed = 0;

    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        if (id >= 30 && id <= 32)  //WearItem
        {
            if (id == 30 && droppedItem.Atk > 0 || id == 31 && droppedItem.Def > 0 || id == 32 && droppedItem.Speed > 0)
                ChangeItem(eventData);
        }
        else if (id >= 37 && id <= 38) //EnchanItem
        {
            if (droppedItem.id != 9 && droppedItem.id != 15 && droppedItem.id != 21
                && droppedItem.id != 27 && droppedItem.id != 33 && droppedItem.id != 39)
            {
                if (droppedItem.Atk > 0 || droppedItem.Def > 0 || droppedItem.Speed > 0)
                    ChangeItem(eventData);
            }
        }
        else
        {
            ChangeItem(eventData);      
        }

        GameObject.Find("InventoryManager").GetComponent<BuyItem>().MoneySell2.text = 
            GameObject.Find("InventoryManager").GetComponent<BuyItem>().MoneySell.text = "ทั้งหมด " + TextMoneySell().ToString() + " ฿";

    }

    public void ChangeItem(PointerEventData eventJa)
    {

        ItemData droppedItem = eventJa.pointerDrag.GetComponent<ItemData>();
        if (!remainItem)
        {
            GameObject.Find("Slot " + inv.beginId).GetComponent<Slot>().remainItem = false;
        }
        else if (this.transform.childCount > 0)
        {
            Transform item = this.transform.GetChild(0);
            item.GetComponent<ItemData>().slot = inv.beginId;
            item.transform.SetParent(inv.Slots[inv.beginId].transform);
            item.transform.position = inv.Slots[inv.beginId].transform.position;


        }
            remainItem = true;

        droppedItem.slot = id;
        droppedItem.transform.SetParent(this.transform);
        droppedItem.transform.position = this.transform.position;



    }

    public int TextMoneySell()
    {
        int Money = 0;
        
        for (int i = 44; i < 56; i++)
        {
            if (inv.Slots[i].transform.childCount > 0)
            {
                Money += inv.Slots[i].transform.GetChild(0).GetComponent<ItemData>().Price * inv.Slots[i].transform.GetChild(0).GetComponent<ItemData>().Stack;
            }

        }
        
        return Money;   
    }



}
