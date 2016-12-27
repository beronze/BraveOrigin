using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
public class TimeStage : MonoBehaviour {

	public float t_Stage;
    public string lv_Stage;

    BebarBoss bebar;

	void Start () {
        if(GameObject.Find("Bebar") != null)
            bebar = GameObject.Find("Bebar").GetComponent<BebarBoss>();
	}
	

	void Update () {
		this.GetComponent<Text>().text = t_Stage == 0 ? "" : ((Int32)t_Stage/60).ToString("00") + " : " + ((Int32)t_Stage % 60).ToString("00");
        this.transform.GetChild(0).GetComponent<Text>().text = lv_Stage;

        if (bebar != null)
        {
            this.transform.GetChild(1).GetComponent<Text>().text = "ต้องกำจัดศัตรูอีก";
            this.transform.GetChild(2).GetComponent<Text>().text = "" + (bebar.bebarAmount - bebar.bebarNum);
        }
        else
        {
            this.transform.GetChild(1).GetComponent<Text>().text = "";
            this.transform.GetChild(2).GetComponent<Text>().text = "";
        }
	}
}
