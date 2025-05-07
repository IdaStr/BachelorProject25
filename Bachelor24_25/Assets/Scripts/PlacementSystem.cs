using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    public float placeDistance = 2f; // Distance in front of the player

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) PlaceItem("Crystal bowl"); 
        if (Input.GetKeyDown(KeyCode.Alpha2)) PlaceItem("Candles");
        if (Input.GetKeyDown(KeyCode.Alpha3)) PlaceItem("Flowerpot");
        if (Input.GetKeyDown(KeyCode.Alpha4)) PlaceItem("Sofa");
        if (Input.GetKeyDown(KeyCode.Alpha5)) PlaceItem("Table");
        if (Input.GetKeyDown(KeyCode.Alpha6)) PlaceItem("Cactus");

    }

    void PlaceItem(string itemName)
    {
        // Find the item in the inventory
        Item itemToPlace = InventoryManager.Instance.Items.Find(item => item.itemName == itemName);

        if (itemToPlace != null && itemToPlace.prefab != null)
        {
            // Calculate the target position in front of the player
            Vector3 forwardPosition = transform.position + transform.forward * placeDistance;

            // Start the ray from a bit above the position
            Vector3 rayStart = forwardPosition + Vector3.up * 2f;
            RaycastHit hit;

            // Cast the ray down to find ground
            if (Physics.Raycast(rayStart, Vector3.down, out hit, 5f))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    // Place the item on the ground
                    /*Renderer renderer = itemToPlace.prefab.GetComponentInChildren<Renderer>();
                    if (renderer == null)
                    {
                        Debug.LogError("No Renderer found in prefab or its children!");
                        return;
                    }

                    float itemHeight = renderer.bounds.size.y;
                    Vector3 placeOnGround = hit.point + Vector3.up * (itemHeight / 2f);
                    */
                    Vector3 placeOnGround = hit.point + Vector3.up; //object must have pivot at floor

                    Instantiate(itemToPlace.prefab, hit.point, Quaternion.identity);
                    print(hit.transform.gameObject.name);
                    // Remove item from inventory and refresh the UI
                    InventoryManager.Instance.Remove(itemToPlace);
                    InventoryManager.Instance.ListItems();
                }
                else
                {
                    Debug.Log("Hit something, but it's not tagged as 'Ground'.");
                }
            }
            else
            {
                Debug.Log("No ground detected below placement position.");
            }
        }
    }
}
