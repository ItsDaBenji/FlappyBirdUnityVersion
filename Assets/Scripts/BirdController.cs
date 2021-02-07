using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{

    private bool isDead = false;


    private Rigidbody2D rb;
    private Animator animator;


    [SerializeField] float upForce = 200.0f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, upForce));
                animator.SetTrigger("Flap");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        rb.velocity = Vector2.zero;
        isDead = true;
        animator.SetTrigger("Die");
        GameManager.instance.BirdDied();
    }



}
