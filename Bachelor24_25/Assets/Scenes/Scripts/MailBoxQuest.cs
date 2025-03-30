using UnityEngine;

public class MailBoxQuest : MonoBehaviour

{
    public GameObject MailboxExclamation;
    public GameObject InteractionKEY;
    public GameObject QuestRequest;


    private bool hasInteracted;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

        if (MailboxExclamation != null)
        {
            MailboxExclamation.transform.LookAt(Camera.main.transform.position);
            MailboxExclamation.transform.Rotate(0, 180, 0);
            //makes the ! in the scene follow and be rotated towards the camera so its always visible to player.
        }

        if (!hasInteracted)
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                Interact();
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                InteractionKEY.SetActive(false);
            }
        }

    }

    public void Interact()
    {
        if (!hasInteracted)
        {
            InteractionKEY.SetActive(true);
            QuestRequest.SetActive(true);
            MailboxExclamation.SetActive(false);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InteractionKEY.SetActive(true);

            //if (!hasInteracted)
            // {
            //  MailboxExclamation.SetActive(true);
            //}

            // else if (!hasInteracted)
            // {
            //   MailboxExclamation.SetActive(false);
            //  }


            Debug.Log("Player has entered zone.");
        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && hasInteracted)
        {

            MailboxExclamation.SetActive(true);

        }

        InteractionKEY.SetActive(false);

        Debug.Log("Player has fucked off out of zone.");
    }

}
