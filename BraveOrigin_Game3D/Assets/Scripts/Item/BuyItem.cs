using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class BuyItem : MonoBehaviour
{

    int itemId;
    Inventory inv;
    PlayerStatus ps;


    public Text value;
    public GameObject enterValue;
    public GameObject enterSell;

    public Text MoneySell;
    public Text MoneySell2;

	void Start () {
        inv = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        ps = GameObject.Find("Player").GetComponent<PlayerStatus>();


	}


    void Update()
    {

    }

    public void buyItme(int itemId)
    {
        this.itemId = itemId;
        enterValue.SetActive(true);
        enterValue.transform.GetChild(0).GetComponent<Text>().text = "ซื้อ " + inv.ItemId[itemId].GetComponent<ItemData>().nameItem;
        enterValue.transform.GetChild(1).GetComponent<Text>().text = "ราคาชิ้นละ " + inv.ItemId[itemId].GetComponent<ItemData>().Price + " ฿";
    }

    public void OKbuy()
    {       
        ItemData item = inv.ItemId[itemId].GetComponent<ItemData>();
        int price = item.Price;
        int valu = Convert.ToInt32(value.text);
        if (ps.Money >= price * valu)
        {
            for (int i = 0; i < valu; i++)
            {
                inv.addItem(itemId);
                ps.Money -= price;
                enterValue.SetActive(false);              
            }
            GameObject.Find("Canvas").GetComponent<UI_Screen>().data.text += "\n ท่านซื้อ " + item.nameItem + " จำนวน " + valu + " ขวด";
            StartCoroutine(inv.ScrollDown());
        }
        else
        {
            enterValue.transform.GetChild(1).GetComponent<Text>().text = "ต้องการเงินอีก " + ((price * valu) - ps.Money) + " ฿";
        }
    }

    public void OnSell()
    {
        for (int i = 44; i < 56; i++)
        {
            GameObject Slot1 = inv.Slots[i];
            if (Slot1.transform.childCount > 0)
            {
                enterSell.SetActive(true);
                break;
            }
        }
    }

    public void SellItem()
    {
        //Text sumMoney = MoneySell2;
        for (int i = 44; i < 56; i++ )
        {
            inv.sellItem(i);
        }
        MoneySell2.text = MoneySell.text = "ทั้งหมด 0 ฿";
        StartCoroutine(inv.ScrollDown());
    }

    public void CancelSell()
    {       
        for (int i = 44; i < 56; i++)
        {
            GameObject Slot1 = inv.Slots[i];
            if (Slot1.transform.childCount > 0)
            {
                ItemData item1 = Slot1.transform.GetChild(0).GetComponent<ItemData>();
                inv.addItem(item1.id);
                Slot1.GetComponent<Slot>().remainItem = false;
                item1.De_troy();
            }
        }
    }
}
