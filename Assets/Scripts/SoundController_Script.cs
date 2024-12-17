using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController_Script : MonoBehaviour
{
    public static SoundController_Script Instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void AudioPlay(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }
}
