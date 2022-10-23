using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    private int health = 5;

    public TextMeshProUGUI hp;
    public TextMeshProUGUI up;
    public TextMeshProUGUI time;

    private Rigidbody2D rb;

    public float horizontalSpeed;
    public float verticalSpeed;

    public float ROF;
    private float gunCD;

    public Transform gunSpot01;
    public Transform gunSpot02;
    private bool isGunSpot01 = true;

    public GameObject bullet;
    public float speedMod = 0;
    public float damageMod = 0;

    private float tenSecTimer = 0f;
    float[] minorUpgrades = { 0.1f, 1, 3, 0.5f };
    float[] majorUpgrades = { 0.2f, 2, 5, 1f };
    string[] upgradeName = {"Rate of Fire", "Bullet Speed", "Player Speed", "Damage"};
    private float upgradeNum = 0;

    public GameObject PPD; // post player death

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        gunCD = ROF;
        speedMod = 0;
        damageMod = 0;
    }

    void Update()
    {
        hp.text = health.ToString();
        time.text = ((Mathf.Round(tenSecTimer * 10)) / 10f).ToString();

        if (health <= 0)
        {
            Instantiate(PPD, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        gunCD -= Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-horizontalSpeed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, verticalSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, -verticalSpeed);
        }

        if (Input.GetKey(KeyCode.Space) && gunCD <= 0)
        {
            if (isGunSpot01)
            {
                Instantiate(bullet, gunSpot01.position, Quaternion.identity);
                isGunSpot01 = !isGunSpot01;
            }
            else if (isGunSpot01 == false)
            {
                Instantiate(bullet, gunSpot02.position, Quaternion.identity);
                isGunSpot01 = !isGunSpot01;
            }

            gunCD = ROF;
        }

        tenSecTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E))
        {

            if (tenSecTimer < 5 || tenSecTimer > 15)
            {
                up.text = "No upgrade!";
                upgradeNum--;
            }
            else if (tenSecTimer > 5 && tenSecTimer < 8)
            {
                upgradeType(false);
            }
            else if (tenSecTimer > 8 && tenSecTimer < 12)
            {
                upgradeType(true);
            }
            else if (tenSecTimer > 12 && tenSecTimer < 15)
            {
                upgradeType(false);
            }

            upgradeNum++;
            if (upgradeNum >= 4)
            {
                upgradeNum = 0;
            }
            tenSecTimer = 0f;

        }
    }

    void upgradeType(bool isMajor)
    {

        if (upgradeNum == 0)
        {
            if (!isMajor)
            {
                ROF -= minorUpgrades[0];
                up.text = upgradeName[0] + "+";
            }
            else
            {
                ROF -= majorUpgrades[0];
                up.text = upgradeName[0] + "++";
            }
        }
        if (upgradeNum == 1)
        {
            if (!isMajor)
            {
                speedMod += minorUpgrades[1];
                up.text = upgradeName[1] + "+";
            }
            else
            {
                speedMod += majorUpgrades[1];
                up.text = upgradeName[1] + "++";
            }
        }
        if (upgradeNum == 2)
        {
            if (!isMajor)
            {
                verticalSpeed += minorUpgrades[2];
                horizontalSpeed += minorUpgrades[2];
                up.text = upgradeName[2] + "+";
            }
            else
            {
                verticalSpeed += majorUpgrades[2];
                horizontalSpeed += majorUpgrades[2];
                up.text = upgradeName[2] + "++";
            }
        }
        if (upgradeNum == 3)
        {
            if (!isMajor)
            {
                damageMod += minorUpgrades[3];
                up.text = upgradeName[3] + "+";
            }
            else
            {
                damageMod += majorUpgrades[3];
                up.text = upgradeName[3] + "++";
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
            health -= 1;
        }
    }

}
