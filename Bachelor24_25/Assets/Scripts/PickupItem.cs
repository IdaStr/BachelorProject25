using UnityEngine;
using UnityEngine.UI;
using UnityEngine.ProBuilder.MeshOperations;

public class PickupItem : MonoBehaviour
{
    // UI Text element for the popup
    public Text pickupPrompt;
    private bool isPlayerInRange = false;


    void Start()
    {
        // Ensure the prompt is initially hidden
        if (pickupPrompt != null)
        {
            pickupPrompt.enabled = false;
        }
    }

    void Update()
    {
        // Check if the player is in range and presses the E key
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Pickup();  // Call the Pickup method

        }


    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {

            Debug.Log("trigger enter");

            isPlayerInRange = true;

            // Show the pickup prompt
            if (pickupPrompt != null)
            {
                pickupPrompt.text = "Press E to pick up the item";
                pickupPrompt.enabled = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Hide the prompt when the player leaves the trigger zone
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;

            if (pickupPrompt != null)
            {
                pickupPrompt.enabled = false;
            }
        }
    }

    void Pickup()
    {   //ida stuff remove if problem


        //ida stuff ends

        // Logic for picking up the item
        Debug.Log("Item picked up!");

        // Disable the item (or destroy it, depending on your requirements)
        gameObject.SetActive(false);

        // Add the item to the inventory
        if (!gameObject.CompareTag("Trash"))
        {
         InventoryManager.Instance.Add(GetComponent<ItemController>().Item);
        }
        

        // Hide the prompt
        if (pickupPrompt != null)
        {
            pickupPrompt.enabled = false;
        }

        // Update inventory UI
        InventoryManager.Instance.ListItems();
    }
}



