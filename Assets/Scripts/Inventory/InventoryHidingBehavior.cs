using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryHidingBehavior : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject inventoryCanvas;
    // Start is called before the first frame update
    void Start()
    {
        inventoryCanvas.GetComponent<Animator>().SetBool("Inventory", false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        inventoryCanvas.GetComponent<Animator>().SetBool("Inventory", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inventoryCanvas.GetComponent<Animator>().SetBool("Inventory", false);
    }
}
