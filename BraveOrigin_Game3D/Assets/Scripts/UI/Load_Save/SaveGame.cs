using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class SaveGame : MonoBehaviour {

    PlayerStatus _Status;
    dataQuest _data;
    Inventory inv;
    
	void Start () {
        _data = GameObject.Find("QuestManager").GetComponent<dataQuest>();
        _Status = GameObject.Find("Player").GetComponent<PlayerStatus>();
        inv = GameObject.Find("InventoryManager").GetComponent<Inventory>();

        for (int i = 1; i <= 3; i++)
        {
            GetComponent<ShowSave>().Show(i);
        }
        
        AutoLoad();
        _Status.CalculateStatus();
        DelStatus();

        _Status.CurrentHp = _Status.MaxHp;
        _Status.CurrentMp = _Status.MaxMp;

        _data.DataTalk();
        _data.LoadQuest();
	}

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AutoSave();

        }
    }

    public void DelStatus()
    {
        _Status.s_Point = ((_Status.Level - 1) * 10) - (_Status.s_Def + _Status.s_Str + _Status.s_Vit - 30);
        for (int i = 0; i > _Status.s_Point; i--)
        {
            if (_Status.s_Point < 0)
            {
                if (_Status.s_Str >= 0)
                    _Status.s_Str--;
            }
            else if (_Status.s_Point < 0)
            {
                if (_Status.s_Vit >= 0)
                    _Status.s_Vit--;
            }
            else if (_Status.s_Point < 0)
            {
                if (_Status.s_Def >= 0)
                    _Status.s_Def--;
            }
        }

    }


    public void AutoSave()
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream fStream = File.Open(Application.persistentDataPath + "/AutoSave.octo", FileMode.Open);
        SaveManager saver = new SaveManager();


        saver.Name = _Status.C_name;
        saver.Lv = _Status.Level;
        saver.Exp = _Status.Exp;
        saver.StatusPoint = _Status.s_Point;
        saver.Str = _Status.s_Str;
        saver.Vit = _Status.s_Vit;
        saver.Def = _Status.s_Def;
        saver.date = System.DateTime.Now.ToString();
        saver.Money = _Status.Money;

        for (int i = 0; i < _data.QuestComplete.Length; i++)
        {
            if (_data.QuestComplete[i].ToString() == "Active")
            {
                saver.Quest = i;
                break;
            }
        }


        for (int i = 0; i < saver.ItemId.Length; i++)
        {
            if (inv.Slots[i] != null)
            {
                if (inv.Slots[i].transform.childCount > 0)
                    saver.ItemId[i] = inv.Slots[i].transform.GetChild(0).GetComponent<ItemData>().id;
                else
                    saver.ItemId[i] = -1;
            }
        }

        for (int i = 0; i < saver.StackItem.Length; i++)
        {
            if (inv.Slots[i] != null)
            {
                if (inv.Slots[i].transform.childCount > 0)
                    saver.StackItem[i] = inv.Slots[i].transform.GetChild(0).GetComponent<ItemData>().Stack;
                else
                    saver.StackItem[i] = 0;
            }
        }

        binary.Serialize(fStream, saver);
        fStream.Close();

    }

    public void AutoLoad()
    {
        if (File.Exists(Application.persistentDataPath + "/AutoSave.octo"))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream fStream = File.Open(Application.persistentDataPath + "/AutoSave.octo", FileMode.Open);
            SaveManager saver = (SaveManager)binary.Deserialize(fStream);
            fStream.Close();

            _Status.C_name = saver.Name;
            _Status.Level = saver.Lv;
            _Status.Exp = saver.Exp;
            _Status.s_Point = saver.StatusPoint;
            _Status.s_Str = saver.Str;
            _Status.s_Vit = saver.Vit;
            _Status.s_Def = saver.Def;
            _Status.date = saver.date;
            _data.Num_Quest = saver.Quest;
            _Status.Money = saver.Money;

            for (int i = 0; i < saver.ItemId.Length; i++)
            {
                if (inv.Slots[i] != null)
                {
                    if (saver.ItemId[i] != -1)
                    {
                        GameObject NewItem = (GameObject)Instantiate(inv.ItemId[saver.ItemId[i]]);
                        ItemData NewData = NewItem.GetComponent<ItemData>();
                        NewItem.transform.SetParent(inv.Slots[i].transform);
                        NewData.slot = i;
                        inv.Slots[i].GetComponent<Slot>().remainItem = true;
                        NewItem.GetComponent<RectTransform>().transform.localScale = new Vector3(1, 1, 1);

                        NewData.Stack = saver.StackItem[i];
                        if (NewData.isStack)
                        {
                            NewItem.transform.GetChild(0).GetComponent<Text>().text = saver.StackItem[i].ToString();
                            inv.HpMp[NewData.id].text = saver.StackItem[i].ToString();
                        }
                        if (i == 30)
                        {
                            _Status.item_Damage = NewData.Atk;

                        }
                        if (i == 31)
                        {
                            _Status.item_Def = NewData.Def;

                        }
                        if (i == 32)
                        {
                            _Status.item_Speed = NewData.Speed;
                        }
                    }
                }
            }
        }
    }


	public void Save(int Ns) {      

        BinaryFormatter binary = new BinaryFormatter();
        FileStream fStream = File.Create(Application.persistentDataPath + "/saveFile" + Ns + ".octo");

        SaveManager saver = new SaveManager();

        saver.Name = _Status.C_name;
        saver.Lv = _Status.Level;
        saver.Exp = _Status.Exp;
        saver.StatusPoint = _Status.s_Point;
        saver.Str = _Status.s_Str;
        saver.Vit = _Status.s_Vit;
        saver.Def = _Status.s_Def;
        saver.date = System.DateTime.Now.ToString();
        saver.Money = _Status.Money;

        for (int i = 0; i < _data.QuestComplete.Length; i++)
        {
            if (_data.QuestComplete[i].ToString() == "Active")
            {
                saver.Quest = i;
                break;
            }
        }

        for (int i = 0; i < saver.ItemId.Length; i++)
        {
            if (inv.Slots[i] != null)
            {
                if (inv.Slots[i].transform.childCount > 0)
                    saver.ItemId[i] = inv.Slots[i].transform.GetChild(0).GetComponent<ItemData>().id;
                else
                    saver.ItemId[i] = -1;
            }
        }

        for (int i = 0; i < saver.StackItem.Length; i++)
        {
            if (inv.Slots[i] != null)
            {
                if (inv.Slots[i].transform.childCount > 0)
                    saver.StackItem[i] = inv.Slots[i].transform.GetChild(0).GetComponent<ItemData>().Stack;
                else
                    saver.StackItem[i] = 0;
            }
        }

        binary.Serialize(fStream, saver);
        fStream.Close();
    }


}

[Serializable]
class SaveManager
{
    public string Name;
    public int Lv;
    public int Exp;
    public int StatusPoint;
    public int Str, Vit, Def;
    public string date;
    public int Quest;
    public int[] ItemId = new int[60];
    public int[] StackItem = new int[60];
    public int Money;

}
