using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BulletBase
{
    void Start()
    {
        GameObject p = GameObject.Find("Player");
        Player player = p.GetComponent<Player>();
        speed = 8 + player.speedMod;
        damage = 1 + player.damageMod;
    }
}
