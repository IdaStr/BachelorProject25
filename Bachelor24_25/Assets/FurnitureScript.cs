using UnityEngine;

public class FurnitureScript : MonoBehaviour
{

    public GameObject OpenOrderKey;
    public GameObject FurnitureOrderExlamation;
    public GameObject OrderBackground;
    //public GameObject FurnitureItems;

    private bool hasInteracted;


    // Update is called once per frame
    private void Update()
    {
        if (FurnitureOrderExlamation != null)
        {
            FurnitureOrderExlamation.transform.LookAt(Camera.main.transform.position);
            FurnitureOrderExlamation.transform.Rotate(0, 180, 0);
            //makes the ! in the scene follow and be rotated towards the camera so its always visible to player.
        }

        if (!hasInteracted)
        {

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Interact();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                OpenOrderKey.SetActive(false);
            }
        }

    }

    public void Interact()
    {
        if (!hasInteracted)
        {
            OpenOrderKey.SetActive(true);
            OrderBackground.SetActive(true);
            FurnitureOrderExlamation.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenOrderKey.SetActive(true);




            Debug.Log("Player has entered zone.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && hasInteracted)
        {

            FurnitureOrderExlamation.SetActive(true);

        }

        OpenOrderKey.SetActive(false);

        Debug.Log("Player has fucked off out of zone.");
    }
}

