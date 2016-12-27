using UnityEngine;
using System.Collections;

public class On_Screen : MonoBehaviour {

    public GameObject m_nu, Look2, Look3;

    dataQuest _data;

	void Start () {
        _data = GameObject.Find("QuestManager").GetComponent<dataQuest>();
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            m_nu.SetActive(true);
        }

        for (int i = 0; i < 12; i++)
        {
            if (_data.QuestComplete[i].ToString() == "Active")
            {
                if (i > 6)
                    Look2.SetActive(false);
                if (i > 8)
                    Look3.SetActive(false);
                break;
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            m_nu.SetActive(false);
        }
    }
}
