using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MoveScreen : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public void OnBeginDrag(PointerEventData eventData)
    {


    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0))
        {
            this.transform.parent.position = eventData.position;

        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {


    }
}
