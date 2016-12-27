using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeNow : MonoBehaviour {

    public Text text_time;


	void Update () {
        //Time
        text_time.text = System.DateTime.Now.Hour.ToString("00") + " : " + System.DateTime.Now.Minute.ToString("00");
	}
}
