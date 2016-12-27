using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameQuest : MonoBehaviour {

    dataQuest _data;

	void Start () {
        _data = GameObject.Find("QuestManager").GetComponent<dataQuest>();
        
	}
	
	void Update () {

        _data.ShowQuest();

	}

    public void EnterQuest()
    {
        _data._Degree = "talk";
        _data.QuestEnd();        
    }

}
