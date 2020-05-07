using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class googleplay : MonoBehaviour
{
    private bool isUserAuthenticated = false;

    void Start()
    {
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.DebugLogEnabled = true;
    }

    void Update()
    {
        if (isUserAuthenticated == false)
        {
            Social.localUser.Authenticate((bool sucess) =>
            {
                if (sucess)
                {
                    Debug.Log("logged in");
                    isUserAuthenticated = true;
                    GameObject.Find("ads").GetComponent<achivments>().openedTheGame();
                }
                else
                {
                    Debug.Log("failed to log in");
                }
            });


        }
    }
}
