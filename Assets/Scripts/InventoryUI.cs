using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    [Header("References")]
    public Player Player;
    
    [Header("Data")]
    public GameObject ItemPrefab;
    
    private List<GameObject> Items = new List<GameObject>();

    private void Awake() {
        Player.OnInventoryUpdate += UpdateIcons;
    }

    private void UpdateIcons() {
        // Destroy old icons
        foreach (GameObject item in Items) {
            Destroy(item);
        }
        Items.Clear();
        // Update icons
        foreach (Item item in Player.Inventory) {
            GameObject instantiate = Instantiate(ItemPrefab, transform);
            instantiate.GetComponent<ItemUI>().Icon.sprite = item.Icon;
            Items.Add(instantiate);
        }
    }
    
}