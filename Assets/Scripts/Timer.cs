using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public float time = 30f;
    private bool canCountDown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canCountDown)
        {
            time -= Time.deltaTime;
            timeText.text = "Time: " + Mathf.CeilToInt(time).ToString();
        }

    }
    public void StartCountDown(bool t)
    {
        this.canCountDown = t;
        if (time <= 0)
        {
            time = 0;
            timeText.text = "Game over!! ";
        }
    }
}
