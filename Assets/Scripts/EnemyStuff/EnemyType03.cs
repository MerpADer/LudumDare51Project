using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType03 : MonoBehaviour
{

    private int speed = 1;
    private Rigidbody2D rb;

    private float jumpCD = 5f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        jumpCD -= Time.deltaTime;

        if (jumpCD <= 0 && gameObject.transform.position.y != -2)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 2f);
            jumpCD = 5f;
        }

        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            speed = -speed;
        }
    }

}
