using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlDiff : MonoBehaviour
{
    public void OnClickPlayFacil()
    {
        PlayerPrefs.SetFloat("levelChosen", 1);
        Time.timeScale = 1f;
        Invoke("CargarEscena", 1f);
    }
    public void OnClickPlayMedio()
    {
        PlayerPrefs.SetFloat("levelChosen", 3f);
        Time.timeScale = 1f;
        Invoke("CargarEscena", 1f);
    }
    public void OnClickPlayDificil()
    {
        PlayerPrefs.SetFloat("levelChosen", 5f);
        Time.timeScale = 1f;
        Invoke("CargarEscena", 1f);
    }

    private void CargarEscena()
    {
        SceneManager.LoadScene("Nivel 1");
    }
}
