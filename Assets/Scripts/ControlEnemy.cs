using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemy : MonoBehaviour
{
    public float speedEnemy;
    private Vector3 posInitial;
    public Vector3 posEnd;
    public bool moveToEnd;

    public GameObject bat;
    //private FlipEnemy flipEnemy;

    private void Start()
    {
        posInitial = transform.position;
        moveToEnd = true;

        //flipEnemy = bat.GetComponent<FlipEnemy>();
    }

    private void Update()
    {
        Vector3 posDestiny = (moveToEnd ? posEnd : posInitial);
        transform.position = Vector3.MoveTowards(transform.position, posDestiny, speedEnemy * Time.deltaTime * PlayerPrefs.GetFloat("levelChosen"));
        if (transform.position == posEnd) moveToEnd = false;
        if (transform.position == posInitial) moveToEnd = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<ControlPlayer>().loseLife();
    }

    private void DeathPlayer()
    {
        //ControlHUD.SetTextLost();
        Time.timeScale = 0f;
    }
}
