using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    public float placeDistance = 2f; // Distance in front of the player

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) PlaceItem("CubeBlue");
        if (Input.GetKeyDown(KeyCode.Alpha2)) PlaceItem("CubeYellow");
        if (Input.GetKeyDown(KeyCode.Alpha3)) PlaceItem("CubePurple");
    }

    void PlaceItem(string itemName)
    {
        // Find the item in the inventory
        Item itemToPlace = InventoryManager.Instance.Items.Find(item => item.itemName == itemName);

        if (itemToPlace != null && itemToPlace.prefab != null)
        {
            // Get the player's position and forward direction
            Vector3 placePosition = transform.position + transform.forward * placeDistance;

            // Instantiate the item in front of the player
            Instantiate(itemToPlace.prefab, placePosition, Quaternion.identity);

            // Remove the item from the inventory and update UI
            InventoryManager.Instance.Remove(itemToPlace);
            InventoryManager.Instance.ListItems();
        }
    }
}