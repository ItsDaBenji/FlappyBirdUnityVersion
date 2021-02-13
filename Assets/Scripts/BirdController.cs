using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{

    private bool isDead = false;

    public int lives = 3;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;
    private PolygonCollider2D poly;


    [SerializeField] float upForce = 200.0f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        poly = GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        if (!isDead)
        {
            if (Input.GetButtonDown("FLAP"))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, upForce));
                animator.SetTrigger("Flap");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {
            rb.velocity = Vector2.zero;
            isDead = true;
            animator.SetTrigger("Die");
            GameManager.instance.BirdDied();
        }

        else if (other.gameObject.CompareTag("Column"))
        {
            lives--;

            if (lives <= 0)
            {
                rb.velocity = Vector2.zero;
                isDead = true;
                animator.SetTrigger("Die");
                GameManager.instance.BirdDied();
            }
            else
            {
                poly.enabled = false;
                sr.color = Color.black;
                StartCoroutine(EnableBox());
            }
        }
    }

    IEnumerator EnableBox()
    {
        yield return new WaitForSeconds(1.5f);
        poly.enabled = true;
        sr.color = Color.white;
    }



}
