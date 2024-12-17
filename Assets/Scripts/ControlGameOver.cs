using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ControlGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;
    private ControlPlayer controlPlayer;

    private void Start()
    {
        controlPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlPlayer>();
        controlPlayer.GameOverPlayer += ActivateMenu;
    }

    private void ActivateMenu(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true);
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Main(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
