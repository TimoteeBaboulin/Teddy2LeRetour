using UnityEngine;

public class Character : MonoBehaviour, IInteractable {

    public string Dialogue;
    public Item ItemToGive;
    
    public Vector3 Position => transform.position;

    public void Interact(Player player) {
        if (ItemToGive) {
            Debug.Log("Tiens, prend cette clef");
            player.GiveItem(ItemToGive);
            ItemToGive = null;
        }
        else
        {
            Debug.Log("Je n'ai rien à te donner'");
        }
    }
     
}