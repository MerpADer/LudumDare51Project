using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    public float speed;
    public float damage = 1;

    private Rigidbody2D rb;
    private float destroyBullet = 5f;

    void Awake()
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
