using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class CreateCharacter : MonoBehaviour {

    [SerializeField] private Text Username_field;

    [SerializeField] private AudioSource m_NoName,m_AudioSource;

    public void ChageScene(string scenename)
    {
        string scene = scenename;
        string userID = Username_field.text.ToString();
        if (userID != "")
        {
            m_AudioSource.Play();
            StartCoroutine(WaitForSeconds(scene));
        }
        else
        {
            m_NoName.Play();
        }
    }


    IEnumerator WaitForSeconds(string scene)
    {
        yield return new WaitForSeconds(1.0f);
        Application.LoadLevel(scene);
        
    }



    public void CreateName()
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream fStream = File.Create(Application.persistentDataPath + "/AutoSave.octo");
        SaveManager saver = new SaveManager();


        saver.Name = Username_field.text;
        saver.Lv = 1;
        saver.Exp = 0;
        saver.StatusPoint = 0;
        saver.Str = 10;
        saver.Vit = 10;
        saver.Def = 10;
        saver.date = "";
        saver.Quest = 0;
        saver.Money = 1000;

        for (int i = 0; i < saver.ItemId.Length; i++ )
            saver.ItemId[i] = -1;

        saver.ItemId[0] = 4;
        saver.ItemId[1] = 10;
        saver.ItemId[2] = 16;
        //for (int i = 0; i < saver.StackItem.Length; i++)
        //    saver.ItemId[i] = 0;

        binary.Serialize(fStream, saver);
        fStream.Close();

    }



}
