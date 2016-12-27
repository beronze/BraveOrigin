using UnityEngine;
using System.Collections;

public class BtmHideScreen : MonoBehaviour
{

    public GameObject H_Screen, S_Screen, S_Screen2;


    public void HideScreen()
    {
        //SaveGame SG = GameObject.Find("DataCenter").GetComponent<SaveGame>();
        //SG.AutoSave();

        if (H_Screen != null)
            H_Screen.SetActive(false);
        if (S_Screen != null)
            S_Screen.SetActive(true);
        if (S_Screen2 != null)
            S_Screen2.SetActive(true);
        
    }

    public bool B_Time =false;

    public void continues()
    {
        H_Screen.SetActive(false);
        Time.timeScale = 1;

    }
    void Update()
    {

    }
}
