using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enchan : MonoBehaviour {

    Inventory inv;
    Text textData;
    public Text upgrend;
    public GameObject enChan;

    GameObject SoundUI;

	void Start () {
        inv = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        textData = GameObject.Find("Canvas").GetComponent<UI_Screen>().data;
        SoundUI = GameObject.Find("UISounds");
	}
	

	void Update () {

        if (inv.Slots[37].transform.childCount > 0 && inv.Slots[38].transform.childCount > 0)
        {
            if (inv.Slots[37].transform.GetChild(0).GetComponent<ItemData>().id == inv.Slots[38].transform.GetChild(0).GetComponent<ItemData>().id)
                upgrend.text = "โอกาสสำเร็จ " + (100 - (inv.Slots[37].transform.GetChild(0).GetComponent<ItemData>().Upgrend * 20)) + " %";
            else
                upgrend.text = "อุปกรณ์ของท่านต่างกัน ข้าไม่สามารถเพิ่มระดับให้ท่านได้";
        }
        else
            upgrend.text = "ท่านโปรดนำไอเทมที่เหมือนกันมาให้ข้า";
	}

    public void upGrend()
    {
        
        GameObject Slot1 = inv.Slots[37];
        GameObject Slot2 = inv.Slots[38];

        if (Slot1.transform.childCount > 0 && Slot2.transform.childCount > 0)
        {
            ItemData item1 = Slot1.transform.GetChild(0).GetComponent<ItemData>();
            ItemData item2 = Slot2.transform.GetChild(0).GetComponent<ItemData>();
            PlayerStatus ps = GameObject.Find("Player").GetComponent<PlayerStatus>();

            if (item1.id == item2.id )
            {
                if (item1.id > 21)
                {
                    if (ps.Money < 500)
                    {
                        textData.text += "\n อุปกรณ์ระดับสูงต้องการเงิน 500 ฿ ในการอัพเกรดอุปกรณ์";
                    }
                    else
                    {
                        ps.Money -= 500;
                        textData.text += "\n ท่านจ่ายค่าอัพเกรดอุปกรณ์ 500 ฿";
                        upGrendNow(item1, item2);
                    }                    
                }
                else
                {
                    upGrendNow(item1, item2);
                }
            }
        }
        StartCoroutine(inv.ScrollDown());
    }

    void upGrendNow(ItemData item1, ItemData item2)
    {
        GameObject Slot1 = inv.Slots[37];
        GameObject Slot2 = inv.Slots[38];

        if (Random.Range(1, 100) < 100 - (item1.Upgrend * 20))
        {
            inv.addItem(item1.id + 1);
            textData.text += "\n ท่านอัพเกรดอุปกรณ์ สำเร็จ";
            textData.text += "\n ท่านได้รับ " + inv.name_tem(item1.id + 1);
            SoundUI.transform.GetChild(3).GetComponent<AudioSource>().Play();
        }
        else
        {
            inv.addItem(item1.id);
            textData.text += "\n ท่านอัพเกรดอุปกรณ์ ล้มเหลว";
            textData.text += "\n ท่านสูญเสีย " + inv.name_tem(item1.id);
            SoundUI.transform.GetChild(0).GetComponent<AudioSource>().Play();
        }

        Slot1.GetComponent<Slot>().remainItem = false;
        Slot2.GetComponent<Slot>().remainItem = false;
        item1.De_troy();
        item2.De_troy();
    }

    public void CancelUpGrend()
    {
        GameObject Slot1 = inv.Slots[37];
        GameObject Slot2 = inv.Slots[38];
        
        
        if (Slot1.transform.childCount > 0)
        {
            ItemData item1 = Slot1.transform.GetChild(0).GetComponent<ItemData>();
            inv.addItem(item1.id);
            Slot1.GetComponent<Slot>().remainItem = false;
            item1.De_troy();           
        }

        if (Slot2.transform.childCount > 0)
        {
            ItemData item2 = Slot2.transform.GetChild(0).GetComponent<ItemData>();
            inv.addItem(item2.id);
            Slot2.GetComponent<Slot>().remainItem = false;
            item2.De_troy();
        }

        enChan.SetActive(false);
    }
}
