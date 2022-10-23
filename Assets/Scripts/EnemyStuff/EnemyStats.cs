using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float Health;

    public GameObject bullet;
    public float ROF;
    private float gunCD;

    public GameObject explosion;

    public bool isHordeEnemy;

    void Start()
    {
        if (isHordeEnemy)
        {
            gunCD = ROF + (Random.Range(1, 100) / 100f);
        }
        else
        {
            gunCD = ROF;
        }
    }

    void Update()
    {
        gunCD -= Time.deltaTime;

        if (gunCD <= 0)
        {
            Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
            if (isHordeEnemy)
            {
                gunCD = ROF + (Random.Range(1, 100) / 100f);
            }
            else
            {
                gunCD = ROF;
            }
        }

        if (Health <= 0)
        {
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            Bullet b = collision.GetComponent<Bullet>();
            Health -= b.damage;
            Destroy(collision.gameObject);
        }
    }

}
