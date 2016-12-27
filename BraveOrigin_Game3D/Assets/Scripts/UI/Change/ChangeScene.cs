using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

    public GameObject P_Screen;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void PauseGame()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            P_Screen.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;


        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            P_Screen.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //PauseGame();
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            PauseGame();
        }
    }
}
