using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Networking;

public class ads : MonoBehaviour
{
    public void ShowAD()
    {
        const string skipable = "video";

        if (Advertisement.IsReady())
        {
            Advertisement.Show(skipable, new ShowOptions() { resultCallback = adViewResult });
        }
    }

    void adViewResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                {
                    Debug.Log("player finished ad");
                    break;
                }
            case ShowResult.Skipped:
                {
                    Debug.Log("player skipped ad");
                    break;
                }
            case ShowResult.Failed:
                {
                    Debug.Log("problem showing ad");
                    break;
                }
        }
    }


    public void OpenTwitter()
    {
        string twitterAdress = "http://twitter.com/intent/tweet";
        string message = "i sure love Soulless Destruction";
        string descriptionPeram = "wow its even got twitter intergration, dowload from here and pay for no ads because im broke pls and thx :)";
        string storelink = "https://sleepdeficiency.studio/";

        Application.OpenURL(twitterAdress + "?text=" + UnityWebRequest.EscapeURL(message + "\n" + descriptionPeram + "\n" + storelink));
    }
}
