using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;


public class TextUpdater : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;

    public void SetText(float Progress)
    {
        Text.SetText($"{(Progress * 100).ToString("N2")}%");

    }
}
