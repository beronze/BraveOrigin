using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatusScreen : MonoBehaviour {

    PlayerStatus _Status;
    GameObject UpdateText, Sta;

    float damage, def, speed;

	void Start () {

        _Status = GameObject.Find("Player").GetComponent<PlayerStatus>();
        UpdateText = GameObject.Find("UpStatus");
        Sta = GameObject.Find("Status Panel");

        
    }


    void FixedUpdate()
    {
        TextUpdate();
        _Status.s_Point = ((_Status.Level-1) * 5) - (_Status.s_Def + _Status.s_Str + _Status.s_Vit - 30);

        
	}



    void TextUpdate()
    {
        //Status
        damage = _Status.Damage + _Status.item_Damage + _Status.buff_Damage;
        def = _Status.Def + _Status.item_Def;
        speed = _Status.Speed + _Status.item_Speed;
        UpdateText.transform.GetChild(2).GetComponent<Text>().text = (damage - (damage * 10 / 100)).ToString("##,###,##0")
            + "~" + (damage + (damage * 10 / 100)).ToString("##,###,##0") + "\n" + def + "\n" + speed
            + "\n\n" + _Status.CurrentHp.ToString("##,###,##0") + "/" + _Status.MaxHp.ToString("##,###,##0")
            + "\n" + _Status.CurrentMp.ToString("##,###,##0") + "/" + _Status.MaxMp.ToString("##,###,##0");

        //UpStatus
        UpdateText.transform.GetChild(0).GetComponent<Text>().text =
            "Str (Strength)\t\t" + _Status.s_Str + "\nVit (Vitality) \t\t\t" + _Status.s_Vit + "\nDef (Defend)\t\t\t" + _Status.s_Def;
        UpdateText.transform.GetChild(1).GetComponent<Text>().text = "Point " + (_Status.s_Point < 0 ? "0": ""+_Status.s_Point);



        //Name && Exp
        Sta.transform.GetChild(5).GetComponent<Text>().text = _Status.C_name + "   LV " + _Status.Level;
        Sta.transform.GetChild(6).GetComponent<Text>().text = "EXP " + (_Status.Exp - _Status.LevelExp[_Status.Level - 1])
            + " / " + (_Status.LevelExp[_Status.Level] - _Status.LevelExp[_Status.Level - 1]);
    }

    

    public void addStr()
    {
        if (_Status.s_Point > 0)
        {
            _Status.s_Str++;
            _Status.s_Point--;
        }
    }

    public void addDef()
    {
        if (_Status.s_Point > 0)
        {
            _Status.s_Def++;
            _Status.s_Point--;
        }
    }

    public void addVit()
    {
        if (_Status.s_Point > 0)
        {
            _Status.s_Vit++;
            _Status.s_Point--;          
        }
    }

}
