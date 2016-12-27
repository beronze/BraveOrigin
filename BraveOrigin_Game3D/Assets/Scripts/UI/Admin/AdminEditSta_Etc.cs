using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class AdminEditSta_Etc : MonoBehaviour {

    public Text EXP, Money, Time;

    PlayerStatus ps;
    DayNightController dn;

	void Start () {
        ps = GameObject.Find("Player").GetComponent<PlayerStatus>();

        if(GameObject.Find("DayNightCycle") != null)
            dn = GameObject.Find("DayNightCycle").GetComponent<DayNightController>();
	}
	
	void Update () {
	
	}

    public void AddTime()
    {
        if(dn != null)
            dn.TimePlus(Convert.ToInt32(Time.text));
    }

    public void DelTime()
    {
        if (dn != null)
            dn.TimeDel(Convert.ToInt32(Time.text));
    }


    public void AddEXP()
    {
        ps.Exp += Convert.ToInt32(EXP.text);
    }

    public void DelEXP()
    {
        ps.Exp -= Convert.ToInt32(EXP.text);
    }

    public void AddMoney()
    {
        ps.Money += Convert.ToInt32(Money.text);
    }

    public void DelMoney()
    {
        ps.Money -= Convert.ToInt32(Money.text);
    }

}
