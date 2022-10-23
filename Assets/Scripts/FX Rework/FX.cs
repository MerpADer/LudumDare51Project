using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FX : MonoBehaviour
{
    public float upTime;

    [SerializeField] private UnityEvent onTimeFinished;
    
    void Update()
    {
        upTime -= Time.deltaTime;

        if (upTime <= 0)
        {
            onTimeFinished.Invoke();
            Destroy(gameObject);
        }
    }
}
