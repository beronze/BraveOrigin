using UnityEngine;
using System.Collections;

public class CheckActiveScreen : MonoBehaviour {

    public GameObject inventory, Teleport, P_Screen, BackVillage, BackManu, Exit, SeveGame, EndStage, Status, Npc,
        Die, Setting, Tooltip, BuySell, Enchant, Buy, Sell, HelpKey, AdminScreen, EndButtom;

    public GameObject ButtomBackVillage;
    
    public bool NullSreen, NullSreenNPC;
    public bool Alt;

	void Start () {
        inventory = GameObject.Find("Inventory");
        Teleport = GameObject.Find("Teleport");
        P_Screen = GameObject.Find("P_Screen");
        BackVillage = GameObject.Find("C_BackVillage");
        BackManu = GameObject.Find("C_BackManu");
        Exit = GameObject.Find("C_Exit");
        SeveGame = GameObject.Find("SaveGame_Screen");
        EndStage = GameObject.Find("EndStage");
        Status = GameObject.Find("Status");
        Npc = GameObject.Find("NpcScreen");
        Die = GameObject.Find("Die_Screen");
        Setting = GameObject.Find("Setting");
        Tooltip = GameObject.Find("Tooltip");
        BuySell = GameObject.Find("BuySell");
        HelpKey = GameObject.Find("Help");
        AdminScreen = GameObject.Find("AdminScreen");
        EndButtom = GameObject.Find("EndButtom");

        Hide_AllScreen();       
	}

    public void Hide_AllScreen()
    {
        
        Teleport.SetActive(false);
        P_Screen.SetActive(false);
        BackVillage.SetActive(false);
        BackManu.SetActive(false);
        Exit.SetActive(false);
        SeveGame.SetActive(false);
        EndStage.SetActive(false);
        Status.SetActive(false);
        Npc.SetActive(false);
        Die.SetActive(false);
        Setting.SetActive(false);
        Tooltip.SetActive(false);
        BuySell.SetActive(false);
        Enchant.SetActive(false);
        HelpKey.SetActive(false);
        AdminScreen.SetActive(false);
        Sell.SetActive(false);
        Buy.SetActive(false);
        EndButtom.SetActive(false);
        inventory.SetActive(false);

        if (Application.loadedLevelName == "Village")
            ButtomBackVillage.SetActive(false);     
        else
            ButtomBackVillage.SetActive(true);
    }
	
	
	void Update () {
        

        if (inventory.activeSelf || Teleport.activeSelf || P_Screen.activeSelf || Exit.activeSelf || SeveGame.activeSelf
            || EndStage.activeSelf || Status.activeSelf || Npc.activeSelf || Setting.activeSelf || BuySell.activeSelf || 
            Enchant.activeSelf || Sell.activeSelf || HelpKey.activeSelf || AdminScreen.activeSelf || Die.activeSelf || Buy.activeSelf
            || BackVillage.activeSelf || BackManu.activeSelf || Alt)
            NullSreen = false;
        else
            NullSreen = true;

        if (inventory.activeSelf || Npc.activeSelf || Status.activeSelf || Teleport.activeSelf || EndStage.activeSelf
            || BuySell.activeSelf || Enchant.activeSelf || Sell.activeSelf || Alt)
            NullSreenNPC = false;
        else
            NullSreenNPC = true; 
            
	}

    public IEnumerator Wait(float waitTime, GameObject Show, bool Fading)
    {
        if (!Fading)
        {
            Show.GetComponent<CanvasGroup>().alpha -= 0.05f;
        }
        else
        {
            Show.GetComponent<CanvasGroup>().alpha += 0.05f;
        }

        yield return new WaitForSeconds(waitTime);

        if (Show.GetComponent<CanvasGroup>().alpha <= 0)
        {
            Fading = true;
        }
        else if (Show.GetComponent<CanvasGroup>().alpha >= 1)
        {
            Fading = false;
        }
        else
            StartCoroutine(Wait(waitTime, Show, Fading));
    }
}
