using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{

    private Rigidbody2D rb;

    public float scrollSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(scrollSpeed, 0);
    }

    private void Update()
    {
        if (GameManager.instance.gameOver)
        {
            rb.velocity = Vector2.zero;
        }
    }

}
