using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class AdminSetting : MonoBehaviour
{
    public Text Username;
    public Dropdown Savename, Lv, Quest;
    public Slider Str, Vit, Def;

    public int[] Exp;

    int s_Point, s_Str, s_Vit, s_Def;
    public GameObject Adm;

    public Text[] SaveGame_Text;

    void Start()
    {
        CurrentLevel();

    }

    public void Save()
    {

        BinaryFormatter binary = new BinaryFormatter();
        FileStream fStream = File.Create(Application.persistentDataPath + "/saveFile" + (Savename.value + 1) + ".octo");

        SaveManager saver = new SaveManager();

        saver.Name = Username.text.ToString();
        saver.Lv = Lv.value+1;
        saver.Exp = Exp[Lv.value];
        saver.StatusPoint = 0;
        saver.Str = (Int32)Str.value;
        saver.Vit = (Int32)Vit.value;
        saver.Def = (Int32)Def.value;
        saver.date = System.DateTime.Now.ToString();
        saver.Quest = Quest.value;

        for (int i = 0; i < saver.ItemId.Length; i++)
            saver.ItemId[i] = -1;

        binary.Serialize(fStream, saver);
        fStream.Close();

        for (int i = 1; i <= 3; i++)
        {
            Show(i);
        }
    }


    void CurrentLevel()
    {

        Exp[0] = 0;
        Exp[1] = 100;
        for (int i = 2; i <= 30; i++)
        {
            Exp[i] = Exp[i - 1] + 50 + (Exp[i - 1] - Exp[i - 2]);
        }

    }

    void FixedUpdate()
    {
        s_Point = ((Lv.value) * 5) + 30 - ((Int32)Def.value + (Int32)Str.value + (Int32)Vit.value);

        Str.maxValue = Str.value + s_Point;
        Vit.maxValue = Vit.value + s_Point;
        Def.maxValue = Def.value + s_Point;

        Adm.transform.GetChild(1).GetComponent<Text>().text = Str.value.ToString("0");
        Adm.transform.GetChild(2).GetComponent<Text>().text = Vit.value.ToString("0");
        Adm.transform.GetChild(3).GetComponent<Text>().text = Def.value.ToString("0");
        Adm.transform.GetChild(4).GetComponent<Text>().text = s_Point.ToString("0");
        
    }


    public void Show(int Ns)
    {
        if (File.Exists(Application.persistentDataPath + "/saveFile" + Ns + ".octo"))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream fStream = File.Open(Application.persistentDataPath + "/saveFile" + Ns + ".octo", FileMode.Open);
            SaveManager saver = (SaveManager)binary.Deserialize(fStream);
            fStream.Close();


            SaveGame_Text[Ns - 1].text = saver.Name + "   LV " + saver.Lv.ToString("#0");
            SaveGame_Text[Ns + 2].text = saver.date;
        }
    }
}