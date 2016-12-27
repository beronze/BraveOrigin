using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class ShowSave : MonoBehaviour {

    public Text[] SaveGame_Text;

    void Start()
    {
        for (int i = 1; i <= 3; i++)
        {
            Show(i);
        }
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
