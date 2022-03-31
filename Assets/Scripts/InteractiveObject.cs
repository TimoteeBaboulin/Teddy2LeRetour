using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    private bool _open;

    public bool state;
    // Start is called before the first frame update
    void Start()
    {
        _open = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit = Physics2D.GetRayIntersection(ray);

        if (Input.GetButtonDown("Fire1"))
        {
            if (hit.collider == GetComponent<Collider2D>())
            {
                if (!_open)
                    return;
                if (state)
                    GetComponent<SpriteRenderer>().color = Color.blue;
                else
                    GetComponent<SpriteRenderer>().color = Color.green;

                state = !state;
            }
        }
    }

    public void UpdateState()
    {
        _open = !_open;
    }
}
