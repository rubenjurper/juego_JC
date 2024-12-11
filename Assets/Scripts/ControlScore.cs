using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ControlScore : MonoBehaviour
{
    public int score;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Door").GetComponent<ControlComplete>().ObjectsTaken();
            collision.gameObject.GetComponent<ControlPlayer>().AddScore(score);
            Destroy(gameObject);
        }
    }
}
