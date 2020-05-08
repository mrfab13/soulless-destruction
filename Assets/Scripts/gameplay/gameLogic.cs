using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameLogic : MonoBehaviour
{
    public float timeLeft;
    public GameObject UIobj;
    public int gameover = 0;
    public GameObject killsUI;
    public int kills;

    private void Start()
    {
        kills = GameObject.Find("people").transform.childCount;
        updatedkills();
    }

    void Update()
    {
        if (gameover != 0)
        {
            return;
        }

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0.0f)
        {
            timeLeft = 0.0f;
            gameover = 1;
        }

        if (kills < 1)
        {
            gameover = 2;
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

    public void updatedkills()
    {
        killsUI.GetComponent<Text>().text = "TANGOS " + kills.ToString();
    }

}
