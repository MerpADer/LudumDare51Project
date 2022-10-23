using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    public float damage = 1;

    private Rigidbody2D rb;
    private float destroyBullet = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject p = GameObject.Find("Player");
        Player player = p.GetComponent<Player>();
        speed = 8 + player.speedMod;
        damage = 1 + player.damageMod;
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
