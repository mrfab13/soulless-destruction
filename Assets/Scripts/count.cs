using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class count : MonoBehaviour
{
    public ads ADManager;
    public int tempcount = 0;

    //attach to button
    public void poke()
    {
        tempcount++;
        this.GetComponent<Text>().text = tempcount.ToString();

        if ((tempcount % 10) == 0)
        {
            ADManager.ShowAD();
        }

        if ((tempcount % 15) == 0)
        {
            ADManager.OpenTwitter();
        }
    }
}
