using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPlace : MonoBehaviour
{
    public string name;
    public bool consumeItem = false;
    public int itemCount = 999;

    public bool haveActive = false;
    public GameObject activeItem;

    private bool itemOn = false;

    public void SetSprite(Sprite sprite)
    {
        if (!consumeItem)
            itemOn = true;
        
        itemCount--;
        if (haveActive)
            activeItem.GetComponent<InteractiveObject>().UpdateState();
        if (!consumeItem)
        {
            GetComponent<SpriteRenderer>().sprite = sprite;
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public bool ClickWithItem(Sprite sprite)
    {
        if (sprite.name != name || itemOn)
            return false;
        return true;
    }

    public bool ClickWithoutItem()
    {
        if (!itemOn)
            return false;
        return true;
    }

    public Sprite ResetSprite()
    {
        itemOn = !itemOn;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        GetComponent<SpriteRenderer>().enabled = false;
        return sprite;
    }
    
}
