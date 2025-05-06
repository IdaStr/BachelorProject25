using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class NextLevelTrigger : MonoBehaviour
{
    public GameObject NextLevelEndCredits;


    private void OnTriggerEnter(Collider other)
    {
        {   if (other.tag == "Player")

                Debug.Log("Player has entered next level zone");
            NextLevelEndCredits.SetActive(true);
        }

    }
}
