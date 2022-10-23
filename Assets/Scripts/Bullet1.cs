using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb;
    private float destroyBullet = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        destroyBullet -= Time.deltaTime;

        if (destroyBullet <= 0)
        {
            Destroy(gameObject);
        }

        rb.velocity = new Vector2(rb.velocity.x, speed);
    }
}
