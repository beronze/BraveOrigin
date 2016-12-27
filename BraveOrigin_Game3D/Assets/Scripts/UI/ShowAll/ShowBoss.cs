using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ShowBoss : MonoBehaviour, IPointerEnterHandler{

    public GameObject S_Boss, H_Boss, H_Boss2;


    public void OnPointerEnter(PointerEventData eventData)
    {
        S_Boss.SetActive(true);
        H_Boss.SetActive(false);
        H_Boss2.SetActive(false);
    }
}
