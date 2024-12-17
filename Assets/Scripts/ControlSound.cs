using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSound : MonoBehaviour
{
    [SerializeField] public AudioClip bread_sound;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SoundController_Script.Instance.AudioPlay(bread_sound);
        }
    }
}
