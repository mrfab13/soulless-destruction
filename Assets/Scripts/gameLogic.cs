using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameLogic : MonoBehaviour
{
    public float timeLeft;
    public GameObject UIobj;
    public bool gameover = false;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0.0f)
        {
            timeLeft = 0.0f;
            gameover = true;
        }

        if (timeLeft < 9.0f)
        {
            UIobj.GetComponent<Text>().text = "0:0" + Mathf.CeilToInt(timeLeft).ToString("F0");

        }
        else
        {
            UIobj.GetComponent<Text>().text = "0:" + Mathf.CeilToInt(timeLeft).ToString("F0");

        }

    }
}
