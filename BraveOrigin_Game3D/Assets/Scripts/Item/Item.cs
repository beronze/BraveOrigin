using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    GameObject inventoryPanel;
    Inventory inv;
    public int slot;

	void Start () {
        inv = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        inventoryPanel = GameObject.Find("Inventory Panel");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0))
        {
            //offset = new Vector2(-20, 30);
            this.transform.SetParent(this.transform.parent.parent);
            this.transform.position = eventData.position;
            GetComponent<CanvasGroup>().blocksRaycasts = false;

            this.GetComponent<RectTransform>().transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);


        }
        Debug.Log(slot);

    }

    public void OnDrag(PointerEventData eventData)
    {

        this.transform.position = eventData.position;
        this.GetComponent<RectTransform>().transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(inv.Slots[slot].transform);
        this.transform.position = inv.Slots[slot].transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        this.GetComponent<RectTransform>().transform.localScale = new Vector3(1, 1, 1);

    }
}
