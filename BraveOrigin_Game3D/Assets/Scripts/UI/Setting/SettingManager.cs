using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class SettingManager : MonoBehaviour 
{

    public Dropdown ResolutionSet;
    public Toggle FullScreenSet;
    public Dropdown QualitySet;
    public Slider MusicSet;
    public Slider EffectSoundSet;


    public Resolution[] resolution;
    public GameSetting gameSetting;

    void Start()
    {
        
        AutoLoad();
        GameObject.Find("Sound").GetComponent<SoundsManager>().SetSound();       

    }

    public void OnEnable()
    {
        //gameSetting = new GameSetting();

        ResolutionSet.onValueChanged.AddListener(delegate { OnResolution(); });
        FullScreenSet.onValueChanged.AddListener(delegate { OnFullScreen(); });
        QualitySet.onValueChanged.AddListener(delegate { OnQuality(); });
        MusicSet.onValueChanged.AddListener(delegate { OnMusic(); });
        EffectSoundSet.onValueChanged.AddListener(delegate { OnEffectSound(); });

        resolution = Screen.resolutions;


    }

    public void OnResolution()
    {
      

        switch (ResolutionSet.value)
        {
            case 0:
                Screen.SetResolution(640, 480, FullScreenSet.isOn, 60);
                break;

            case 1:
                Screen.SetResolution(720, 480, FullScreenSet.isOn, 60);
                break;

            case 2:
                Screen.SetResolution(720, 576, FullScreenSet.isOn, 60);
                break;

            case 3:
                Screen.SetResolution(800, 600, FullScreenSet.isOn, 60);
                break;

            case 4:
                Screen.SetResolution(1024, 768, FullScreenSet.isOn, 60);
                break;

            case 5:
                Screen.SetResolution(1280, 720, FullScreenSet.isOn, 60);
                break;

            case 6:
                Screen.SetResolution(1280, 768, FullScreenSet.isOn, 60);
                break;

            case 7:
                Screen.SetResolution(1280, 800, FullScreenSet.isOn, 60);
                break;

            case 8:
                Screen.SetResolution(1360, 768, FullScreenSet.isOn, 60);
                break;

            case 9:
                Screen.SetResolution(1366, 768, FullScreenSet.isOn, 60);
                break;
        }
    }

    public void OnFullScreen()
    {
        Screen.fullScreen = FullScreenSet.isOn;
    }

    public void OnQuality()
    {
        
        QualitySettings.SetQualityLevel(QualitySet.value, true);

    }


    public void OnMusic()
    {

        for (int i = 0; i < GameObject.Find("Sound").GetComponent<SoundsManager>()._Music; i++)
            GameObject.Find("Music").transform.GetChild(i).GetComponent<AudioSource>().volume = MusicSet.value;
       

    }


    public void OnEffectSound()
    {

        for (int i = 0; i < GameObject.Find("Sound").GetComponent<SoundsManager>()._UISounds; i++)
            GameObject.Find("UISounds").transform.GetChild(i).GetComponent<AudioSource>().volume = EffectSoundSet.value;

        for (int i = 0; i < GameObject.Find("Sound").GetComponent<SoundsManager>()._PlayerSounds; i++)
            GameObject.Find("PlayerSounds").transform.GetChild(i).GetComponent<AudioSource>().volume = EffectSoundSet.value;

        for (int i = 0; i < GameObject.Find("Sound").GetComponent<SoundsManager>()._BossSounds; i++)
            GameObject.Find("BossSounds").transform.GetChild(i).GetComponent<AudioSource>().volume = EffectSoundSet.value;

        for (int i = 0; i < GameObject.Find("Sound").GetComponent<SoundsManager>()._MonsterSounds; i++)
            GameObject.Find("MonsterSounds").transform.GetChild(i).GetComponent<AudioSource>().volume = EffectSoundSet.value;

        for (int i = 0; i < GameObject.Find("Sound").GetComponent<SoundsManager>()._NPCSounds; i++)
            GameObject.Find("NPCSounds").transform.GetChild(i).GetComponent<AudioSource>().volume = EffectSoundSet.value;
    }


    public void AutoLoad()
    {
        if (File.Exists(Application.persistentDataPath + "/Setting.octo"))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream fStream = File.Open(Application.persistentDataPath + "/Setting.octo", FileMode.Open);
            GameSetting saver = (GameSetting)binary.Deserialize(fStream);

            ResolutionSet.value = saver.resolution;
            FullScreenSet.isOn = saver.fullScreen;
            QualitySet.value = saver.quality;
            MusicSet.value = saver.music;
            EffectSoundSet.value = saver.effectSound;

            binary.Serialize(fStream, saver);
            fStream.Close();

        }
        else
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream fStream = File.Create(Application.persistentDataPath + "/Setting.octo");
            GameSetting saver = new GameSetting();

            saver.resolution = 7;
            saver.fullScreen = true;
            saver.quality = 2;
            saver.music = 0.8f;
            saver.effectSound = 0.8f;

            binary.Serialize(fStream, saver);
            fStream.Close();
        }

    }


    public void Save()
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream fStream = File.Create(Application.persistentDataPath + "/Setting.octo");
        GameSetting saver = new GameSetting();

        saver.resolution = ResolutionSet.value;
        saver.fullScreen = FullScreenSet.isOn;
        saver.quality = QualitySet.value;
        saver.music = MusicSet.value;
        saver.effectSound = EffectSoundSet.value;

        binary.Serialize(fStream, saver);
        fStream.Close();

    }

}


[Serializable]
public class GameSetting{
    public int resolution;
    public bool fullScreen;
    public int quality;
    public float music;
    public float effectSound;


}

