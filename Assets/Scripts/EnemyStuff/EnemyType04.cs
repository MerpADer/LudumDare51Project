using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType04 : MonoBehaviour
{

    private int speed = 3;
    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            speed = -speed;
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1f);
        }
    }


}
