using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SoundsManager : MonoBehaviour {

    public int _Music, _UISounds, _PlayerSounds, _BossSounds, _MonsterSounds, _NPCSounds;

    AudioSource audio,audio2;

    public void SetSound()
    {
        if (File.Exists(Application.persistentDataPath + "/Setting.octo"))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream fStream = File.Open(Application.persistentDataPath + "/Setting.octo", FileMode.Open);
            GameSetting saver = (GameSetting)binary.Deserialize(fStream);

            for (int i = 0; i < _Music; i++)
                GameObject.Find("Music").transform.GetChild(i).GetComponent<AudioSource>().volume = saver.music;

            for (int i = 0; i < _UISounds; i++)
                GameObject.Find("UISounds").transform.GetChild(i).GetComponent<AudioSource>().volume = saver.effectSound;

            for (int i = 0; i < _PlayerSounds; i++)
                GameObject.Find("PlayerSounds").transform.GetChild(i).GetComponent<AudioSource>().volume = saver.effectSound;

            for (int i = 0; i < _BossSounds; i++)
                GameObject.Find("BossSounds").transform.GetChild(i).GetComponent<AudioSource>().volume = saver.effectSound;

            for (int i = 0; i < _MonsterSounds; i++)
                GameObject.Find("MonsterSounds").transform.GetChild(i).GetComponent<AudioSource>().volume = saver.effectSound;

            for (int i = 0; i < _NPCSounds; i++)
                GameObject.Find("NPCSounds").transform.GetChild(i).GetComponent<AudioSource>().volume = saver.effectSound;

            binary.Serialize(fStream, saver);
            fStream.Close();
        }
    }

    public void PlaySound(string NameOj, int Number)
    {
        audio = GameObject.Find(NameOj).transform.GetChild(Number).GetComponent<AudioSource>();
        audio.Play();

    }




}
