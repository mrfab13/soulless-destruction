using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class googleplay : MonoBehaviour
{
    private bool isUserAuthenticated = true;

    void Start()
    {
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.DebugLogEnabled = true;
    }

    // Update is called once per frame
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
                }
                else
                {
                    Debug.Log("failed to log in");
                }
            });


        }
    }
}
