using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    public float placeDistance = 2f; // Distance in front of the player

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) PlaceItem("CubeBlue");
        if (Input.GetKeyDown(KeyCode.Alpha2)) PlaceItem("CubeYellow");
        if (Input.GetKeyDown(KeyCode.Alpha3)) PlaceItem("CubePurple");
        if (Input.GetKeyDown(KeyCode.Alpha4)) PlaceItem("CubeRed");
        if (Input.GetKeyDown(KeyCode.Alpha5)) PlaceItem("CubeOrange");
        if (Input.GetKeyDown(KeyCode.Alpha6)) PlaceItem("CubeGreen");

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
                    float itemHeight = itemToPlace.prefab.GetComponentInChildren<Renderer>().bounds.size.y;
                    Vector3 placeOnGround = hit.point + Vector3.up * (itemHeight / 2f);
                    Instantiate(itemToPlace.prefab, placeOnGround, Quaternion.identity);

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
