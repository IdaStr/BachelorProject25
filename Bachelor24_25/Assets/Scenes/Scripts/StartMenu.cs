using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject StartPanel;


    // Update is called once per frame
    void Update()
    {

    }

    public void Start()
    {
        StartPanel.SetActive(true);
        Time.timeScale = 0;

    }

    public void Exit()
    {
        StartPanel.SetActive(false);
        Time.timeScale = 1;


    }


}