using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AdminAddItem : MonoBehaviour {

    public Dropdown item1, item2, item3, item4, item5, item6;
    Inventory inv;

	void Start () {
        inv = GameObject.Find("InventoryManager").GetComponent<Inventory>();
	}
	

	void Update () {
	
	}

    public void addItemPotion(int id)
    {
        inv.addItem(id);
    }

    public void addSilverGreatSword()
    {
        inv.addItem(item1.value + 4);
    }

    public void addSilverSuit()
    {
        inv.addItem(item2.value + 10);
    }

    public void addSilverBoots()
    {
        inv.addItem(item3.value + 16);
    }

    public void addGoldGreatSword()
    {
        inv.addItem(item4.value + 22);
    }

    public void addGoldrSuit()
    {
        inv.addItem(item5.value + 28);
    }

    public void addGoldBoots()
    {
        inv.addItem(item6.value + 34);
    }
}
