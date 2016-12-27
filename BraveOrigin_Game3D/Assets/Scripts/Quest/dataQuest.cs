using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dataQuest : MonoBehaviour {


    public string[] DataQuest = new string[13];
    public int[] monney = new int[13];
    public int[] Exp = new int[13];
    public int[] Potion = new int[13];

    public enum statusQuest { Inactive, Active, Complete}
    public statusQuest[] QuestComplete = new statusQuest[13];

    public enum DegreeType { S, A, B, C, talk }
    public DegreeType[] DegreeComplete = new DegreeType[13];
    public string _Degree;

    public enum StageType { Stage_1, Stage_2, Stage_3, Leader, Merchant, Blacksmith }
    public StageType[] StageComplete = new StageType[13];
    public string _Stage;

    public int Num_Quest;
    
    

    void start()
    {
        
    }


    public void LoadQuest()
    {
        for (int i = 0; i < QuestComplete.Length; i++)
        {
            QuestComplete[i] = statusQuest.Complete;
            if (i == Num_Quest)
            {
                for (int j = Num_Quest; j < QuestComplete.Length; j++)
                {
                    QuestComplete[i] = statusQuest.Inactive;
                }
                QuestComplete[i] = statusQuest.Active;
                break;
            }
        }
        
    }

    public void ShowQuest()
    {
        Text QuestShow;
        QuestShow = GameObject.Find("Quest").transform.GetChild(0).GetComponent<Text>();
        for (int i = 0; i < QuestComplete.Length; i++)
        {
            if (QuestComplete[i] == statusQuest.Active)
            {
                QuestShow.text = DataQuest[i];
            }
        }
    }

    public void QuestEnd()
    {
        PlayerStatus ps = GameObject.Find("Player").GetComponent<PlayerStatus>();
        Inventory inv = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        CheckActiveScreen Chack = GameObject.Find("DataCenter").GetComponent<CheckActiveScreen>();
        Text textData = GameObject.Find("Canvas").GetComponent<UI_Screen>().data;
        for (int i = 0; i < QuestComplete.Length; i++)
        {
            if (_Stage == StageComplete[i].ToString() &&
                (_Degree == "S" ? 5 : _Degree == "A" ? 4 : _Degree == "B" ? 3 : _Degree == "C" ? 2 : _Degree == "talk" ? 1 : 0) >=
                (DegreeComplete[i].ToString() == "S" ? 5 : DegreeComplete[i].ToString() == "A" ? 4 :
                DegreeComplete[i].ToString() == "B" ? 3 : DegreeComplete[i].ToString() == "C" ? 2 :
                DegreeComplete[i].ToString() == "talk" ? 1 : 0))
            {
                if (QuestComplete[i] == statusQuest.Active)
                {
                    ps.Exp += Exp[i];
                    ps.Money += monney[i];
                    if (Exp[i] > 0)
                        textData.text += "\n ท่านได้รับค่าประสบการณ์ " + Exp[i] + " หน่วย";
                    if (monney[i] > 0)
                        textData.text += "\n ท่านได้รับเงิน " + monney[i] + " ฿";
                    if (Potion[i] > 0)
                    {
                        for (int j = 0; j < Potion[i]; j++)
                        {
                            inv.addItem(1);
                            inv.addItem(3);
                        }
                        textData.text += "\n ท่านได้รับยาฟื้นฟู HP,MP ขนาดใหญ่จำนวน " + Potion[i] + " ขวด";
                    }
                    StartCoroutine(inv.ScrollDown());
                                        
                    QuestComplete[i] = statusQuest.Complete;
                    QuestComplete[i + 1] = statusQuest.Active;
                    break;
                }
            }

        }

    }

    public void DataTalk()
    {

        for (int i = 0; i < QuestComplete.Length; i++)
        {
            QuestComplete[i] = statusQuest.Inactive;
            switch (i)
            {
                case 0:
                    {
                        DataQuest[i] = "พูดคุยกับหัวหน้าหมู่บ้าน \n เดินทางตามหาหัวหน้าหมู่บ้าน";
                        DegreeComplete[i] = DegreeType.talk;
                        StageComplete[i] = StageType.Leader;
                        QuestComplete[i] = statusQuest.Active;
                        monney[i] = 0;
                        Exp[i] = 0;
                        Potion[i] = 10;      
                        break;
                    }
                case 1:
                    {
                        DataQuest[i] = "การทดสอบความสามารถของหัวหน้าหมู่บ้าน \n ผ่านดันเจี้ยนเส้นทางสู่ปราสาท (ระดับใดก็ได้)";
                        DegreeComplete[i] = DegreeType.C;
                        StageComplete[i] = StageType.Stage_1;
                        monney[i] = 0;
                        Exp[i] = 0;
                        Potion[i] = 0;
                        break;
                    }
                case 2:
                    {
                        DataQuest[i] = "การทดสอบความสามารถของหัวหน้าหมู่บ้าน \n กลับไปรายงานแก่หัวหน้าหมู่บ้าน";
                        DegreeComplete[i] = DegreeType.talk;
                        StageComplete[i] = StageType.Leader;
                        monney[i] = 1000;
                        Exp[i] = 500;
                        Potion[i] = 0;
                        break;
                    }
                case 3:
                    {
                        DataQuest[i] = "คุยกับหญิงสาวร้านขายยา \n เดินทางตามหาหญิงสาวร้านขายยา";
                        DegreeComplete[i] = DegreeType.talk;
                        StageComplete[i] = StageType.Merchant;
                        monney[i] = 0;
                        Exp[i] = 0;
                        Potion[i] = 0;
                        break;
                    }
                case 4:
                    {
                        DataQuest[i] = "คุยกับหญิงสาวร้านขายยา \n กลับไปรายงานแก่หัวหน้าหมู่บ้าน";
                        DegreeComplete[i] = DegreeType.talk;
                        StageComplete[i] = StageType.Leader;
                        monney[i] = 0;
                        Exp[i] = 0;
                        Potion[i] = 10;
                        break;
                    }
                case 5:
                    {
                        DataQuest[i] = "การทดสอบความสามารถของหัวหน้าหมู่บ้านครั้งที่ 2 \n ผ่านดันเจี้ยนเส้นทางสู่ปราสาท (ระดับ A ขึ้นไป)";
                        DegreeComplete[i] = DegreeType.A;
                        StageComplete[i] = StageType.Stage_1;
                        monney[i] = 0;
                        Exp[i] = 0;
                        Potion[i] = 0;
                        break;
                    }
                case 6:
                    {
                        DataQuest[i] = "การทดสอบความสามารถของหัวหน้าหมู่บ้านครั้งที่ 2 \n กลับไปรายงานแก่หัวหน้าหมู่บ้าน";
                        DegreeComplete[i] = DegreeType.talk;
                        StageComplete[i] = StageType.Leader;
                        monney[i] = 3000;
                        Exp[i] = 1000;
                        Potion[i] = 10;
                        break;
                    }
                case 7:
                    {
                        DataQuest[i] = "กำจัดมอสเตอร์ปราสาทชั้นที่ 1 \n ผ่านดันเจี้ยนปราสาทชั้นที่ 1 (ระดับ A ขึ้นไป)";
                        DegreeComplete[i] = DegreeType.A;
                        StageComplete[i] = StageType.Stage_2;
                        monney[i] = 0;
                        Exp[i] = 0;
                        Potion[i] = 0;
                        break;
                    }
                case 8:
                    {
                        DataQuest[i] = "กำจัดมอสเตอร์ปราสาทชั้นที่ 1 \n กลับไปรายงานแก่หัวหน้าหมู่บ้าน";
                        DegreeComplete[i] = DegreeType.talk;
                        StageComplete[i] = StageType.Leader;
                        monney[i] = 5000;
                        Exp[i] = 2000;
                        Potion[i] = 10;
                        break;
                    }
                case 9:
                    {
                        DataQuest[i] = "กำจัดราชาก็อบบลิน \n ผ่านดันเจี้ยนปราสาทชั้นที่ 2 (ระดับ A ขึ้นไป)";
                        DegreeComplete[i] = DegreeType.C;
                        StageComplete[i] = StageType.Stage_3;
                        monney[i] = 0;
                        Exp[i] = 0;
                        Potion[i] = 0;
                        break;
                    }
                case 10:
                    {
                        DataQuest[i] = "กำจัดราชาก็อบบลิน \n กลับไปรายงานแก่หัวหน้าหมู่บ้าน";
                        DegreeComplete[i] = DegreeType.talk;
                        StageComplete[i] = StageType.Leader;
                        monney[i] = 10000;
                        Exp[i] = 4000;
                        Potion[i] = 0;
                        break;
                    }
                                 
                default:
                    {
                        DataQuest[i] = "เสร็จสิ้นภารกิจ(End)";
                        DegreeComplete[i] = DegreeType.S;
                        StageComplete[i] = StageType.Leader;
                        monney[i] = 0;
                        Exp[i] = 0;
                        Potion[i] = 0;
                        break;
                    }
                    

                    
            }
            
        }


        
    }


}


