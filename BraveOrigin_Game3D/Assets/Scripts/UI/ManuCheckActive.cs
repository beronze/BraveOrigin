using UnityEngine;
using System.Collections;

public class ManuCheckActive : MonoBehaviour {

    public GameObject Setting, StartGame, LoadGame, ExitGame, Admin;


	void Start () {
        Setting = GameObject.Find("Setting");
        StartGame = GameObject.Find("StartGame");
        LoadGame = GameObject.Find("LoadGame");
        ExitGame = GameObject.Find("ExitGame");
        Admin = GameObject.Find("AdminSetting");
        Hide_AllScreen();
	}

    public void Hide_AllScreen()
    {
        Setting.SetActive(false);
        StartGame.SetActive(false);
        LoadGame.SetActive(false);
        ExitGame.SetActive(false);
        Admin.SetActive(false);
    }

	void Update () {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.M))
        {
            if (!Admin.activeSelf)
                Admin.SetActive(true);
            else
                Admin.SetActive(false);
        }
        
	}
}
