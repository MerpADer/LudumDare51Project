using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PostPlayerDeath : MonoBehaviour
{
    
    public float timeAlive;

    void Start()
    {
        
    }

    
    void Update()
    {
        timeAlive -= Time.deltaTime;

        if (timeAlive <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}
