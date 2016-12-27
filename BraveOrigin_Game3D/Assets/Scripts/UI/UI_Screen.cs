using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class UI_Screen : MonoBehaviour {
    

	PlayerStatus _PlayerStatus;
    public Image Fill_HP, Fill_MP, Fill_Exp;
    public Text T_HP, T_MP, T_LV;

    PlayerController _PlayerController;
    public Image[] Skill;
    public Text[] Time_Skill;
    public Image Buff_Time;
    public GameObject Buff;

    public Text text_time;
    //string h, m;

    public GameObject Showdata;
    public Text data;
    public Scrollbar S_Bar;
    bool Fading;

    private CheckActiveScreen screen;

    void Start () 
    {
        screen = GameObject.Find("DataCenter").GetComponent<CheckActiveScreen>();
        _PlayerStatus = GameObject.Find ("Player").GetComponent<PlayerStatus>();
        _PlayerController = GameObject.Find("Player").GetComponent<PlayerController>();


        //TextShowData
        if (Application.loadedLevelName == "Village")
            data.text += "ท่านได้เข้าสู่หมู่บ้าน";
        else if (Application.loadedLevelName == "Stage_1")
            data.text += "ท่านได้เข้าสู่ เส้นทางสู่ปราสาท";
        else if (Application.loadedLevelName == "Stage_2")
            data.text += "ท่านได้เข้าสู่ ปราสาทชั้นที่ 1";
        else if (Application.loadedLevelName == "Stage_3")
            data.text += "ท่านได้เข้าสู่ ปราสาทชั้นที่ 2";
    }
	
	void Update () {
		if (_PlayerStatus != null)
		{
            //HP&MP Bar
			Fill_HP.fillAmount = _PlayerStatus.CurrentHp / _PlayerStatus.MaxHp;
            Fill_MP.fillAmount = _PlayerStatus.CurrentMp / _PlayerStatus.MaxMp;
            T_HP.text = _PlayerStatus.CurrentHp.ToString("##,###,##0") + " / " + _PlayerStatus.MaxHp.ToString("##,###,##0");
            T_MP.text = _PlayerStatus.CurrentMp.ToString("##,###,##0") + " / " + _PlayerStatus.MaxMp.ToString("##,###,##0");
            

    
            //Exp Bar
            Fill_Exp.fillAmount = (float)(_PlayerStatus.Exp - _PlayerStatus.LevelExp[_PlayerStatus.Level - 1])
                / (_PlayerStatus.LevelExp[_PlayerStatus.Level] - _PlayerStatus.LevelExp[_PlayerStatus.Level - 1]);
            T_LV.text = "LV " + _PlayerStatus.Level;



            //Skill
            for (int i = 0; i < Skill.Length; i++)
            {
                Skill[i].fillAmount = _PlayerController.CurrentCooldownSkill[i] / _PlayerController.MaxCooldownSkill[i];
                if (_PlayerController.CurrentCooldownSkill[i] != 0)
                {
                    Time_Skill[i].text = _PlayerController.CurrentCooldownSkill[i].ToString("#,##0.00") + " s";
                }
                else
                    Time_Skill[i].text = "";
            }

            Buff_Time.fillAmount = _PlayerController.CurrentBuff / _PlayerController.MaxBuff;

            if (_PlayerController.CurrentBuff < _PlayerController.MaxBuff)
                Buff.SetActive(true);
            else
                Buff.SetActive(false);
            

            //Inventory
            if (Input.GetKeyDown(KeyCode.I) && !screen.SeveGame.activeSelf && !screen.P_Screen.activeSelf)
            {
                if (screen.inventory.activeSelf)
                    screen.inventory.SetActive(false);
                else
                    screen.inventory.SetActive(true);
            }


            //PlayerStatus
            if (Input.GetKeyDown(KeyCode.C) && !screen.SeveGame.activeSelf && !screen.P_Screen.activeSelf)
            {
                if (screen.Status.activeSelf)
                    screen.Status.SetActive(false);
                else
                    screen.Status.SetActive(true);
            }

            //Admin
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.M))
            {
                if (screen.AdminScreen.activeSelf)
                    screen.AdminScreen.SetActive(false);
                else
                    screen.AdminScreen.SetActive(true);
            }

            //ExitManu
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (screen.Alt)
                {
                    screen.Alt = false;
                }
                else if (screen.Enchant.activeSelf)
                {
                    GameObject.Find("InventoryManager").GetComponent<Enchan>().CancelUpGrend();
                    screen.Enchant.SetActive(false);
                }
                else if (screen.Sell.activeSelf)
                    screen.Sell.SetActive(false);
                else if (screen.Buy.activeSelf)
                    screen.Buy.SetActive(false);
                else if (screen.BuySell.activeSelf)
                {
                    GameObject.Find("InventoryManager").GetComponent<BuyItem>().CancelSell();
                    screen.BuySell.SetActive(false);
                }
                else if (screen.Exit.activeSelf)
                    screen.Exit.SetActive(false);
                else if (screen.BackVillage.activeSelf)
                    screen.BackVillage.SetActive(false);
                else if (screen.AdminScreen.activeSelf)
                    screen.AdminScreen.SetActive(false);
                else if (screen.Status.activeSelf)
                    screen.Status.SetActive(false);
                else if (screen.Npc.activeSelf)
                    screen.Npc.SetActive(false);
                else if (screen.inventory.activeSelf)
                    screen.inventory.SetActive(false);
                else if (screen.Teleport.activeSelf)
                    screen.Teleport.SetActive(false);
                else if (screen.HelpKey.activeSelf)
                {
                    screen.HelpKey.SetActive(false);
                    screen.P_Screen.SetActive(true);
                }
                else if (screen.SeveGame.activeSelf)
                {
                    screen.SeveGame.SetActive(false);
                    screen.P_Screen.SetActive(true);
                }
                else if (screen.Setting.activeSelf)
                {
                    screen.Setting.SetActive(false);
                    screen.P_Screen.SetActive(true);
                }                
                else if (!screen.EndStage.activeSelf && !screen.Die.activeSelf)
                    PauseGame();

            }
            if (!screen.inventory.activeSelf)
                screen.Tooltip.SetActive(false);

            //Time
            text_time.text = System.DateTime.Now.Hour.ToString("00") + " : " + System.DateTime.Now.Minute.ToString("00");
        }
	}


    public void PauseGame()
    {

        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            screen.P_Screen.SetActive(true);
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            screen.P_Screen.SetActive(false);

        }
    }

    public void ShowHide()
    {
        StartCoroutine(screen.Wait(0.01f, Showdata, Fading));
        Fading = !Fading;
    }
}
