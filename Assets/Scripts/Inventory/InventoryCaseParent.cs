using UnityEngine;
using UnityEngine.UI;

public class InventoryCaseParent : MonoBehaviour
{
    private bool _isCaseDragged = false;
    private Image _caseDragged;
    private void Start()
    {
        //Flexible Grid Set-Up
        GetComponent<FlexibleLayoutGrid>().paddingHorizontal = Screen.width / (float)50;
        int height = (int) (GetComponentInParent<RectTransform>().rect.height/5);
        RectOffset rectangle = new RectOffset(height,height,height,height);
        GetComponent<FlexibleLayoutGrid>().padding = rectangle;
        GetComponent<FlexibleLayoutGrid>().enabled = false;

        int compteur = 1;
        foreach (Image child in GetComponentsInChildren<Image>())
        {
            compteur--;
            if (compteur == 0)
                child.color=Color.green;
            
        }
    }

    public void StartDragging(Image child)
    {
        _isCaseDragged = true;
        _caseDragged = child;
    }

    public bool IsCaseDragged ()
    {
        return _isCaseDragged;
    }

    public Image CaseDragged()
    {
        return _caseDragged;
    }

    public void StopDragging()
    {
        _isCaseDragged = false;
        _caseDragged = null;
    }

    public Image GetFirstVoid()
    {
        foreach (var child in GetComponentsInChildren<Image>())
        {
            if (!child.enabled)
                return child;
        }

        return null;
    }
}
