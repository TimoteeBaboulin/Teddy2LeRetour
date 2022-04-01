using UnityEngine;
using System;

public class Door : MonoBehaviour, IInteractable {

    public Vector3 Position => transform.position;

    public GameObject CurrentLevel;
    public GameObject NextLevel;

    public Item ItemToUnlock;

    public void Interact(Player player) {
        if (player.TakeItem(ItemToUnlock)) {
            Debug.Log("Vous déverouillez la porte");
            NextLevel.SetActive(true);
            CurrentLevel.SetActive(false);
            LevelLoader.OnLevelChange.Invoke();
        }
        else {
            Debug.Log("Vous n'avez pas la clef'");
        }
    }
     
}