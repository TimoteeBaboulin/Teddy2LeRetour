using UnityEngine;
using UnityEngine.UI;

public class InventoryCaseParent : MonoBehaviour
{
    private bool _isCaseDragged = false;
    private Image _caseDragged;
    private void Start()
    {
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
