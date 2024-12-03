using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEnemy : MonoBehaviour
{
    private SpriteRenderer sprite;
    private float lastPositionX;
    private Animator animator;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        lastPositionX = transform.parent.position.x;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (lastPositionX - transform.parent.position.x > 0) sprite.flipX = true;
        else sprite.flipX = false;

        lastPositionX = transform.parent.position.x;
    }
}
