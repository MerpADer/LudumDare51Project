using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    private float TimeBetween = 0;
    private float AddedSpeed;

    private int numSpawn = 1;
    int currSpawn = 0;

    public List<GameObject> EnemyTypes = new List<GameObject>();

    void Update()
    {
        TimeBetween -= Time.deltaTime;
        int type = Random.Range(0, 4);
        
        if (TimeBetween <= 0 && currSpawn <= numSpawn)
        {
            Instantiate(EnemyTypes[type], transform.position, Quaternion.identity, transform);
            currSpawn++;

            if (currSpawn == numSpawn)
            {
                TimeBetween = 6 - AddedSpeed;
                HarderWave();
            }
            else
            {
                TimeBetween = 4 - AddedSpeed;
            }
        }

    }

    private void HarderWave()
    {
        numSpawn++;

        if (AddedSpeed < 3.5f)
        {
            AddedSpeed += 0.25f;
        }

    }
}
