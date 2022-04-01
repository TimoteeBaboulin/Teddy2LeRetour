using UnityEngine;
using UnityEngine.UI;

public class ClickHandler : MonoBehaviour
{
    public GameObject level;
    public GameObject player;
    public GameObject inventory;
    public GameObject itemSpaceParent;

    private string _draggedItem;
    private bool _skipFrame;

    private ItemPlace _toPlace;
    // Start is called before the first frame update
    void Start()
    {
        _skipFrame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_toPlace != null)
        {
            if (Input.GetButtonDown("Fire1") && !_skipFrame)
            {
                //Annule le placement de l'objet
                _toPlace = null;
                SetInventorySprite(Resources.Load<Sprite>(_draggedItem));
            }
            if (!Input.GetButtonDown("Fire1") && player.GetComponent<Movement>().NavMeshAgentStopped())
            {
                //Place l'objet
                _toPlace.SetSprite(Resources.Load<Sprite>(_draggedItem));
            }
        }
        
        //evite de run le test du click si il y a eu une interaction de l'UI
        if (!Input.GetButtonDown("Fire1") || _skipFrame)
        {
            _skipFrame = false;
            return;
        }

        //Si on a cliqué sans l'UI
        Collider2D space;
        if (CheckForSpace(out space))
        {

            if (space.GetComponent<ItemPlace>().ClickWithoutItem())
            {
                inventory.GetComponent<InventoryCaseParent>().AddCase(space.GetComponent<ItemPlace>().ResetSprite());
            }
        }



    }

    //change l'objet de dehors de la classe
    public void SetDragged(string item)
    {
        _draggedItem = item;
    }

    //Check si un espace pour objet a ete touche par le click
    private bool CheckForSpace(out Collider2D space)
    {
        RaycastHit2D hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit = Physics2D.GetRayIntersection(ray);

        foreach (var child in itemSpaceParent.GetComponentsInChildren<Collider2D>())
        {
            if (hit.collider == child)
            {
                space = child;
                return true;
            }
        }

        space = null;
        return false;
    }

    //Appele par la classe InventoryCase si on reclick pendant qu'elle est drag
    public bool ItemStopDragging(string name)
    {
        _skipFrame = true;
        Collider2D collider;
        if(CheckForSpace(out collider))
        {
            ItemPlace space = collider.GetComponent<ItemPlace>();
            
            if (space.ClickWithItem(name))
            {
                _toPlace = space;
                _draggedItem = name;

                return true;
            }
            else
            {
                
            }
        }
        
        SetDragged(null);
        return false;
    }

    //Change le sprite de l'espace d'objet si on l'atteint
    public void SwapSprites(Sprite sprite)
    {
        _toPlace.SetSprite(sprite);

        _toPlace = null;
        _draggedItem = null;
    }

    //Place un objet dans l'inventaire
    private void SetInventorySprite(Sprite sprite)
    {
        inventory.GetComponent<InventoryCaseParent>().AddCase(sprite);
    }
}
