using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{
    void Start()
    {
        
    }

public void OnClickPlay()
    {
        Time.timeScale = 1f;
        Invoke("CargarEscena", 1f);
    }

public void OnclickExit()
    {
        Application.Quit();
    }

public void OnClickCredit()
    {
        SceneManager.LoadScene("Credit");
    }

public void OnClickMenu() 
    {
        SceneManager.LoadScene("Menu");
    }
private void CargarEscena()
    {
        SceneManager.LoadScene("Dificultad");
    }
}
