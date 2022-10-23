using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySideParent : MonoBehaviour
{
    [SerializeField] List<Vector2> positions = new List<Vector2>();

    private int amount = 2;
    private int speed = 2;
    private Rigidbody2D rb;

    public GameObject enemy;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        positions.Add(new Vector2(0, 0));
        positions.Add(new Vector2(2, 0));
        positions.Add(new Vector2(-2, 0));

        for (int i = 0; i < amount; i++)
        {
            int choosewhich = Random.Range(0, positions.Count);
            Vector2 offset = positions[choosewhich];

            positions.RemoveAt(choosewhich);

            Instantiate(enemy, new Vector2(gameObject.transform.position.x + offset.x, gameObject.transform.position.y + offset.y), Quaternion.identity, gameObject.transform);
        }
    }

    void FixedUpdate()
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
