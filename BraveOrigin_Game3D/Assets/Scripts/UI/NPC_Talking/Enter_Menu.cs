using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enter_Menu : MonoBehaviour {
    public GameObject m_nu;
    public GameObject buttomNpc;
    public GameObject buttomNpcBuy;

    public enum NPC { Leader, Merchant, Blacksmith }
    public NPC NpcQuest;

    

    dataQuest _dataQuest;
    NPC_Talk _npc;
    Text _talk;
    CheckActiveScreen cas;

	void Start () {
        _dataQuest = GameObject.Find("QuestManager").GetComponent<dataQuest>();
        _npc = GameObject.Find("QuestManager").GetComponent<NPC_Talk>();
        cas = GameObject.Find("DataCenter").GetComponent<CheckActiveScreen>();
	}
	

	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            m_nu.SetActive(true);
            buttomNpc.SetActive(true);

            BuyItem ByItem = GameObject.Find("InventoryManager").GetComponent<BuyItem>();
            ByItem.enterValue.SetActive(false);
            ByItem.enterSell.SetActive(false);
            cas.BuySell.SetActive(false);

            _dataQuest._Stage = NpcQuest.ToString();
           
            //LeaderTalk
            if (NpcQuest == NPC.Leader)
            {
                m_nu.transform.GetChild(3).GetComponent<Text>().text = "เจฟ\t(หัวหน้าหมู่บ้าน)";
                for (int i = 0; i < 12; i++)
                {
                    if(_dataQuest.QuestComplete[i].ToString() == "Active")
                    {
                        m_nu.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = _npc.LeaderTalk[i];
                        break;
                    }
                }               
            }
            //MerachantTalk
            else if (NpcQuest == NPC.Merchant)
            {
                m_nu.transform.GetChild(3).GetComponent<Text>().text = "ลูน่า\t(ซื้อขายไอเทม)";
                for (int i = 0; i < 12; i++)
                {
                    if (_dataQuest.QuestComplete[i].ToString() == "Active")
                    {
                        m_nu.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = _npc.MerchantTalk[i];
                    }
                    if (_dataQuest.QuestComplete[3].ToString() != "Active")
                    {
                        if(buttomNpcBuy != null)
                            buttomNpcBuy.SetActive(true);
                    }
                }
            }
            //BlacksmithTalk
            else if (NpcQuest == NPC.Blacksmith)
            {
                m_nu.transform.GetChild(3).GetComponent<Text>().text = "รารอฟ\t(ช่างตีเหล็ก)";
                for (int i = 0; i < 12; i++)
                {
                    if (_dataQuest.QuestComplete[i].ToString() == "Active")
                    {
                        m_nu.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = _npc.Blacksmith[0];
                    }
                }
            }
        }

    }


    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            m_nu.SetActive(false);
            buttomNpc.SetActive(false);          
            if(buttomNpcBuy != null)
                buttomNpcBuy.SetActive(false);
            cas.BuySell.SetActive(false);
            cas.Enchant.SetActive(false);
            cas.Sell.SetActive(false);
            cas.inventory.SetActive(false);
            GameObject inv = GameObject.Find("InventoryManager");
            inv.GetComponent<BuyItem>().CancelSell();
            inv.GetComponent<Enchan>().CancelUpGrend();
        }
    }
}
