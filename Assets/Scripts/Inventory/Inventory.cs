using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public RectTransform rectTransform;

    public float time;
    public float screenPercent = 10;

    private float _timer;
    public float ratio;

    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        _timer = 0f;
        ratio = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.mousePosition.x / Screen.width;
        float mouseY = Input.mousePosition.y / Screen.height;

        bool mouseCenter = mouseX > (float) 1 / 3 && mouseX < (float) 2 / 3;
        float mouseCenterFloat = mouseCenter ? 1 : 0;
        
        if ((mouseY < (screenPercent / 3) * 0.01f && mouseCenter)
            || mouseY < screenPercent * 0.01f * ratio + (screenPercent / 3) * 0.01f * mouseCenterFloat)
            _timer += Time.deltaTime;
        else
            _timer -= Time.deltaTime;
        _timer = Mathf.Clamp(_timer, 0f, time);

        ratio = _timer / time;
        rectTransform.anchorMin = new Vector2(0, screenPercent * -0.01f + (screenPercent * 0.01f * ratio));
        rectTransform.anchorMax = new Vector2(1, screenPercent * 0.01f * ratio);
    }

    public bool IsVectorOnInventory()
    {
        float mouseX = Input.mousePosition.x / Screen.width;
        float mouseY = Input.mousePosition.y / Screen.height;
        
        bool mouseCenter = mouseX > (float) 1 / 3 && mouseX < (float) 2 / 3;
        float mouseCenterFloat = mouseCenter ? 1 : 0;
        
        return ((mouseY < (screenPercent / 3) * 0.01f && mouseCenter)
                || mouseY < screenPercent * 0.01f * ratio + (screenPercent / 3) * 0.01f * mouseCenterFloat);
    }
}
