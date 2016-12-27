using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour{

	GameObject inventoryPannel;
    public GameObject slotPanel;
    //GameObject itemPanel;
    
    public GameObject inventorySlot;
    public GameObject inventoryItem;

    GameObject inven;
    public GameObject[] Slots;
    private int slots = 30;
    private int emptySlot;

    public int beginId;

    public GameObject[] ItemId;

    public Text[] HpMp;
    public Text Money;
    PlayerStatus ps;

    Text textData;

    void Start()
    {
        inventoryPannel = GameObject.Find("Inventory Panel");
        inven = GameObject.Find("Inventory");
        ps = GameObject.Find("Player").GetComponent<PlayerStatus>();
        textData = GameObject.Find("Canvas").GetComponent<UI_Screen>().data;

        for (int i = 0; i < slots; i++)
        {
            GameObject NewSlot = (GameObject)Instantiate(inventorySlot);
            NewSlot.name = "Slot " + i;
            NewSlot.GetComponent<Slot>().id = i;
            NewSlot.transform.SetParent(slotPanel.transform);
           
            Slots[i] = NewSlot;          
        }
    }
	

	void Update () {
        Money.text = "" + ps.Money + " ฿";
        
	}

    public void addItem(int id)
    {
        if (ItemId[id].GetComponent<ItemData>().isStack && ChackStack(id))
        {
            for (int j = 0; j < slots; j++)
            {
                if (Slots[j].transform.childCount > 0)
                {
                    if (Slots[j].transform.GetChild(0).GetComponent<ItemData>().id == id)
                    {
                        ItemData data = Slots[j].transform.GetChild(0).GetComponent<ItemData>();
                        data.Stack++;
                        data.transform.GetChild(0).GetComponent<Text>().text = data.Stack.ToString();
                        HpMp[id].text = data.Stack.ToString();
                        break;
                    }
                }
            }
            
        }
        else
        {           
            for (int j = 0; j < slots; j++)
            {
                if (!Slots[j].GetComponent<Slot>().remainItem)
                {
                    GameObject NewItem = (GameObject)Instantiate(ItemId[id]);
                    ItemData data = NewItem.GetComponent<ItemData>();
                    NewItem.transform.SetParent(Slots[j].transform);
                    data.slot = j;
                    data.Stack++;
                    Slots[j].GetComponent<Slot>().remainItem = true;
                    NewItem.GetComponent<RectTransform>().transform.localScale = new Vector3(1, 1, 1);

                    if (data.isStack)
                    {
                        data.transform.GetChild(0).GetComponent<Text>().text = data.Stack.ToString();
                        HpMp[id].text = data.Stack.ToString();
                    }
                    break;
                }
            }      
        }


    }


    public string name_tem(int item)
    {
        for (int i = 0; i < ItemId.Length; i++)
        {
            if (i == item)
            {
                return ItemId[i].GetComponent<ItemData>().nameItem;            
            }
        }
        return "";
    }

    public bool ChackStack(int item)
    {
        for (int i = 0; i < slots; i++)
        {
            if (Slots[i].transform.childCount > 0)
            {
                if (Slots[i].transform.GetChild(0).GetComponent<ItemData>().id == item)
                    return true;
            }
        }
        return false;
    }


    public void DeleteItem(int item)
    {
        for (int i = 0; i < slots; i++)
        {
            if (Slots[i].transform.childCount > 0)
            {
                ItemData data = Slots[i].transform.GetChild(0).GetComponent<ItemData>();
                if (data.id == item)
                {
                    data.De_troy();
                    if (data.isStack)
                    {
                        if (data.Stack > 1)
                        {
                            data.transform.GetChild(0).GetComponent<Text>().text = data.Stack.ToString();
                            HpMp[data.id].text = data.Stack.ToString();
                        }
                        else
                        {
                            HpMp[data.id].text = "0";
                            Slots[data.slot].GetComponent<Slot>().remainItem = false;
                        }
                    }
                    break;
                }
            }
        }        
    }


    public void sellItem(int i)
    {
        if (Slots[i].transform.childCount > 0)
        {
            ItemData IData = Slots[i].transform.GetChild(0).GetComponent<ItemData>();
            IData.DtroySell();
            Slots[i].GetComponent<Slot>().remainItem = false;           
            textData.text += "\n ท่านขาย " + IData.nameItem + " ราคา " + IData.Price * IData.Stack + " ฿";
           
        }
    }

    public IEnumerator ScrollDown()
    {
        yield return new WaitForSeconds(0.01f);
        GameObject.Find("Canvas").GetComponent<UI_Screen>().S_Bar.value = 0;
       
    }
    
}
