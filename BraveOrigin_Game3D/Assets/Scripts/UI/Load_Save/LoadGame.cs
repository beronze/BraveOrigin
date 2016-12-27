using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LoadGame : MonoBehaviour {

    public void LoadSave(int Ns)
    {
        if (File.Exists(Application.persistentDataPath + "/saveFile" + Ns + ".octo"))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream fStream = File.Create(Application.persistentDataPath + "/AutoSave.octo");
            SaveManager saver = new SaveManager();


            BinaryFormatter binary2 = new BinaryFormatter();
            FileStream fStream2 = File.Open(Application.persistentDataPath + "/saveFile" + Ns + ".octo", FileMode.Open);
            SaveManager saver2 = (SaveManager)binary2.Deserialize(fStream2);
            fStream2.Close();

            saver.Name = saver2.Name;
            saver.Lv = saver2.Lv;
            saver.Exp = saver2.Exp;
            saver.StatusPoint = saver2.StatusPoint;
            saver.Str = saver2.Str;
            saver.Vit = saver2.Vit;
            saver.Def = saver2.Def;
            saver.date = saver2.date;
            saver.Quest = saver2.Quest;
            saver.Money = saver2.Money;
            
            for (int i = 0; i < saver.ItemId.Length; i++)
            {
                saver.ItemId[i] = saver2.ItemId[i];
            }

            for (int i = 0; i < saver.StackItem.Length; i++)
            {
                saver.StackItem[i] = saver2.StackItem[i];
            }

            binary.Serialize(fStream, saver);
            fStream.Close();

            ChageScene("Village");
        }

    }



    public void ChageScene(string scenename)
    {

        StartCoroutine(WaitForSeconds(scenename));

    }
    IEnumerator WaitForSeconds(string scene)
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.50f);

        Application.LoadLevel(scene);

    }
}
