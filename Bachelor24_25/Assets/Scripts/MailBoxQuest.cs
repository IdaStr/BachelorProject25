using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailBoxQuest : MonoBehaviour

{
    public GameObject MailboxExclamation;
    public GameObject InteractionKEY;
    public GameObject QuestRequest;
    public GameObject ActivateSignpost;


    private bool hasInteracted;
    private bool hasEnteredZone;


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

        if (!hasInteracted & hasEnteredZone)
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                Interact();
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                InteractionKEY.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.F)) 
            {
                ActivateSignpost.SetActive(true);
            }
        }

    }

    public void EnteredZone() 
    { 
    
    }
    

    public void Interact()
    {
        if (!hasInteracted)
        {
            InteractionKEY.SetActive(true);
            QuestRequest.SetActive(true);
            MailboxExclamation.SetActive(false);
            ActivateSignpost.SetActive(false);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InteractionKEY.SetActive(true);
            hasEnteredZone = true;

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
        hasEnteredZone = false;

        InteractionKEY.SetActive(false);

        Debug.Log("Player has left zone.");
    }

}
