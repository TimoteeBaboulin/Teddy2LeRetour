using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryCase : MonoBehaviour, IPointerDownHandler
{
    private bool _dragged = false;
    
    public ClickHandler clickHandler;

    private Vector2 _basePosition;
    private InventoryCaseParent _parent;
    
    // Start is called before the first frame update
    void Start()
    {
        _parent = GetComponentInParent<InventoryCaseParent>();
        clickHandler = GameObject.Find("ClickHandler").GetComponent<ClickHandler>();
        _basePosition = GetComponent<RectTransform>().anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_dragged)
            return;
        GetComponent<RectTransform>().anchoredPosition = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_dragged)
            StartDragging();
        else
            StopDragging();
        
    }

    public void StartDragging()
    {
        clickHandler.SetDragged(name);
        _parent.StartDragging(GetComponent<Image>());
        _dragged = true;
        transform.SetParent(GameObject.Find("Drag Anchor").transform);
        GetComponent<Image>().color = Color.red;
    }

    public void StopDragging()
    {
        Debug.Log(GetComponent<Image>().sprite.name);
        if (clickHandler.ItemStopDragging(GetComponent<Image>().sprite.name))
        {
            Destroy(gameObject);
        }
        
        _dragged = false;
        transform.SetParent(_parent.transform);
        _parent.StopDragging();
        GetComponent<RectTransform>().anchoredPosition = _basePosition;
        GetComponent<Image>().color = Color.white;
    }

    public Sprite GetSprite()
    {
        return GetComponent<Image>().sprite;
    }
}
