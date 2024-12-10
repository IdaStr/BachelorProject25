using UnityEngine;
using UnityEngine.UI;

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
            Pickup();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
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
    {
        // Logic for picking up the item
        Debug.Log("Item picked up!");

        // Disable the item (or destroy it, depending on your requirements)
        gameObject.SetActive(false);

        // Hide the prompt
        if (pickupPrompt != null)
        {
            pickupPrompt.enabled = false;
        }
    }
}


