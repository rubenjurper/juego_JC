using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlPlayer : MonoBehaviour
{
    public int speed;
    private Rigidbody2D phisicPlayer;
    private SpriteRenderer spritePlayer;
    public float jumpForce = 10f;
    public float rayFloor = 0.1f;
    public LayerMask layerFloor;
    private Animator animator;
    private bool animationPlay;
    private int scoreGeneral; //--------------PUNTUACION
    private bool vulnerable;
    private float FirstTime; //----------------TIEMPO
    public float timeTotal; //----------------TIEMPO
    private int life = 3;

    private bool touchFloor;
    private Rigidbody2D rb;
    public Canvas HUD; //----------------TIEMPO
    private ControlHUD controlHUD; //----------------TIEMPO

    private void Start()
    {
        phisicPlayer = GetComponent<Rigidbody2D>();
        spritePlayer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animationPlay = true;
        vulnerable = true;
        controlHUD = HUD.GetComponent<ControlHUD>();
        scoreGeneral = 0; //---------------------PUNTUACION
        controlHUD.SetTextScore(scoreGeneral);

        FirstTime = Time.time; //----------------TIEMPO
    }
    private void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");

        phisicPlayer.velocity = new Vector2(inputX * speed, phisicPlayer.velocity.y);
        AnimationPlayer();
    }


    private void Update()
    {
        if (phisicPlayer.velocity.x > 0) spritePlayer.flipX = false;
        else if (phisicPlayer.velocity.x < 0) spritePlayer.flipX = true;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayFloor, layerFloor);
        touchFloor = hit.collider != null;

        if (touchFloor && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        controlHUD.SetTextTime(timeTotal - Time.time + FirstTime);
        if (timeTotal - Time.time + FirstTime <= 0) DeathPlayer();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayFloor);
    }

    private void AnimationPlayer()
    {
        if (animationPlay)
        {
            if (!touchFloor) animator.Play("jump");
            else if ((phisicPlayer.velocity.x > 1) || (phisicPlayer.velocity.x < -1) && (phisicPlayer.velocity.y == 0))
                animator.Play("walking");
            else if ((phisicPlayer.velocity.x < 1) && (phisicPlayer.velocity.x > -1) && (phisicPlayer.velocity.y == 0))
                animator.Play("idle");
        }
    }


    public void loseLife()
    {
        life--;
        controlHUD.desactivateHearts(life);
        vulnerable = false;
        spritePlayer.color = Color.red;
        if (life == 0) DeathPlayer();
        else if (life > 0)
        {
            Invoke("MakeVulnerable", 1f);
        }
    }

    private void DeathPlayer()
    {
        controlHUD.SetTextLost();
        Time.timeScale = 0f;
    }

    private void MakeVulnerable()
    {
        vulnerable = true;
        spritePlayer.color = Color.white;
    }


    public void AddScore(int score)
    {
        scoreGeneral += score;
        controlHUD.SetTextScore(scoreGeneral);
    }
    
}
