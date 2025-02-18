using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_knockback : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Knockback(Transform playerTransform, float knockbackForce)
    {
        Vector2 direction = (transform.position - playerTransform.position).normalized;
    }
}
