using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{

    public int id;
    public string nameItem;
    public int Upgrend, Atk, Def, Speed, Money, Stack;
    public bool isStack;
    public string Explanation;
    public int Price;

    Inventory inv;
    Tooltip tooltip;
    PlayerStatus ps;
    public int slot;

    void Start()
    {

        inv = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        tooltip = GameObject.Find("InventoryManager").GetComponent<Tooltip>();
        ps = GameObject.Find("Player").GetComponent<PlayerStatus>();



    }

    void Update() {

        ItemStatus();

    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0))
        {

            this.transform.SetParent(this.transform.parent.parent.parent.parent);
            this.transform.position = eventData.position;
            GetComponent<CanvasGroup>().blocksRaycasts = false;

            this.GetComponent<RectTransform>().transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

            inv.beginId = slot;
        }
       
    }

    public void OnDrag(PointerEventData eventData)
    {

        this.transform.position = eventData.position;
        this.GetComponent<RectTransform>().transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);


    }

    public void OnEndDrag(PointerEventData eventData)
    {

        this.transform.SetParent(inv.Slots[slot].transform);
        this.transform.position = inv.Slots[slot].transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        this.GetComponent<RectTransform>().transform.localScale = new Vector3(1, 1, 1);

        //Dtroy();
        
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.Activate(this.GetComponent<ItemData>());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.Deactivate();
    }

    public void ItemStatus()
    {
        if (slot == 30)
        {
            ps.item_Damage = Atk;

        }
        if (slot == 31)
        {
            ps.item_Def = Def;

        }
        if (slot == 32)
        {
            ps.item_Speed = Speed;
        }
    }


    public void DtroySell()
    {
        if (slot >= 44 && slot < 60)
        {
            if (isStack)
            {
                inv.HpMp[id].text = "0";
            }
            ps.Money += Price * Stack;
            Destroy(gameObject);
        }
    }

    public void De_troy()
    {

        if (Stack > 1)
        {
            Stack--;        
        }
        else
        {                      
            Destroy(gameObject);
        }
    }


}

