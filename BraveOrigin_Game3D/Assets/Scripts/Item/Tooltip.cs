using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Tooltip : MonoBehaviour {

    public GameObject tooltip;
    string data;
    ItemData item;

	void Start () {
        //tooltip = GameObject.Find("Tooltip");
	}

    void Update()
    {
        if (tooltip.activeSelf)
        {
            tooltip.transform.position = Input.mousePosition;
        }
    }

    public void Activate(ItemData item)
    {
        this.item = item;
        ConstructDataString();
        tooltip.SetActive(true);
    }

    public void Deactivate()
    {
        tooltip.SetActive(false);
    }

    public void ConstructDataString()
    {
        data = "<color=#0000ff><b>" + item.nameItem + "</b></color>";
        data += item.Atk == 0 ? "" : "\n Power : " + item.Atk;
        data += item.Def == 0 ? "" : "\n Defence : " + item.Def;
        data += item.Speed == 0 ? "" : "\n Speed : " + item.Speed;
        data += item.Explanation == "" ? "" : "\n\t" + item.Explanation;
        data += "<color=#444444>\n\t\t\tราคา   " + item.Price + "</color>";
        tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
    }
}
