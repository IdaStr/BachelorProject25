using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public string itemTag = "Trash"; // Tag to identify trash items (set in Unity Editor)
    private bool isInRange = false; // Check if the player is in range of an interactable object
    private GameObject currentItem = null; // Store the current item in range

    void Update()
    {
        // Check if the player presses E and if there is an item in range
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (currentItem != null)
            {
                // Check if the item is trash
                if (currentItem.CompareTag(itemTag))
                {
                    Destroy(currentItem); // Destroy the trash item
                    Debug.Log("Trash item deleted.");
                }


            }
        }
    }

    // Handle collision to detect if the player is near an item
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item")) // Only interact with objects tagged as "Item"
        {
            isInRange = true;
            currentItem = other.gameObject; // Store the item the player is near
        }
    }

    // Handle leaving the trigger area
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            isInRange = false;
            currentItem = null; // Reset when the player leaves the area
        }
    }
}


