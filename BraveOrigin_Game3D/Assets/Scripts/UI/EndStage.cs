using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class EndStage : MonoBehaviour {

    public float TimeStage;
    public GameObject slotStage;

    //public List<Item> items = new List<Item>();
    //public List<GameObject> slots = new List<GameObject>();

    GameObject itemPanel;
    public string LavelStage;
    public int itemAmount;


	void Start () {
        
        itemPanel = GameObject.Find("Item Panel");
        
	}
	

	void Update () {
        if (gameObject.activeSelf)
        {
            
            this.transform.GetChild(0).GetComponent<Text>().text = "สำเร็จ\t" + "<i>" + LavelStage + "</i>";

            this.transform.GetChild(1).GetComponent<Text>().text = "ใช้เวลาทั้งหมด \t\t\t<b>"
                + (TimeStage % 60 > 30 ? ((TimeStage / 60)-1).ToString("##0") : (TimeStage / 60).ToString("##0")) 
                + "." + (TimeStage % 60).ToString("0#") + "</b> นาที";


            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Escape))
            {
                SaveGame SG = GameObject.Find("DataCenter").GetComponent<SaveGame>();
                SG.AutoSave();
                this.gameObject.SetActive(false);
                //StartCoroutine(WaitForSeconds("Village"));
            }
        }      
	}

    public void addItemEnd(int itemValue, int[] itemAd, int ranMax)
    {
        Inventory inv = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        int[] item = itemAd;
        for (int i = 0; i < itemValue; i++)
        {
            int ran = Random.Range(0, ranMax);
            inv.addItem(item[ran]);

            GameObject NewSlot = (GameObject)Instantiate(slotStage);
            NewSlot.transform.SetParent(itemPanel.transform);
            NewSlot.GetComponent<RectTransform>().transform.localScale = new Vector3(1, 1, 1);

            GameObject NewItem = (GameObject)Instantiate(inv.ItemId[item[ran]]);
            ItemData itemData = NewItem.GetComponent<ItemData>();
            NewItem.transform.SetParent(NewSlot.transform);
            NewItem.GetComponent<RectTransform>().transform.localScale = new Vector3(1, 1, 1);

            Text data = GameObject.Find("Canvas").GetComponent<UI_Screen>().data;
            data.text += "\n ท่านได้รับ " + itemData.nameItem;
        }
    }

    //IEnumerator WaitForSeconds(string scene)
    //{
    //    Time.timeScale = 1;
    //    yield return new WaitForSeconds(0.70f);

    //    Application.LoadLevel(scene);

    //}

}
