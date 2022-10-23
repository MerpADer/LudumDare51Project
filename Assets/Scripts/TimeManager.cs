using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public float time = 0f;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        time += Time.deltaTime;
    }
}
