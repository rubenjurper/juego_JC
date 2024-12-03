using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;

public class ControlHUD : MonoBehaviour
{
    public TextMeshProUGUI textTime;
    public TextMeshProUGUI textLife;



    public void SetTextLife(int numLife)
    {
        textLife.text = numLife.ToString();
    }


    public void SetTextTime(float numTime)
    {
        int numTimeInteger = (int)numTime;
        int numTimeMinutes = numTimeInteger / 60;
        int numTimeSeconds = numTimeInteger % 60;
        textTime.text = numTimeMinutes.ToString("00") + ":" + numTimeSeconds.ToString("00");
    }

    public void SetTextLost()
    {

    }
}
