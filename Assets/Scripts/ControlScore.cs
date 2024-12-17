using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ControlScore : MonoBehaviour
{
    public int score;
    /*private AudioSource audioSource;
    [SerializeField] public AudioClip bread_sound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //audioSource.PlayOneShot(bread_sound);
            GameObject.FindGameObjectWithTag("Door").GetComponent<ControlComplete>().ObjectsTaken();
            collision.gameObject.GetComponent<ControlPlayer>().AddScore(score);
            Destroy(gameObject);
        }
    }
}
