using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManagerDeleter : MonoBehaviour
{

    public float timeAlive;
    public TextMeshProUGUI timeText;

    void Start()
    {
        TimeManager tm = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        timeAlive = tm.time;
        Destroy(tm.gameObject);

        timeAlive = Mathf.Round(timeAlive * 10) / 10f;
        timeText.text = timeAlive.ToString() + " secs";
    }
}
