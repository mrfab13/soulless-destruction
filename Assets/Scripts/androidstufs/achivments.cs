using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class achivments : MonoBehaviour
{
    public void openedTheGame()
    {
        Social.ReportProgress(SoullessDestructionAchievements.achievement_play_the_game, 100, (bool success) => { });
    }
    public void level1done()
    {
        Social.ReportProgress(SoullessDestructionAchievements.achievement_completed_level_1, 100, (bool success) => { });
    }
    public void level2done()
    {
        Social.ReportProgress(SoullessDestructionAchievements.achievement_completed_level_2 , 100, (bool success) => { });
    }
    public void level3done()
    {
        Social.ReportProgress(SoullessDestructionAchievements.achievement_completed_level_3, 100, (bool success) => { });
    }
    public void noads()
    {
        Social.ReportProgress(SoullessDestructionAchievements.achievement_no_ads, 100, (bool success) => { });
    }


    public void openAchivments()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("logged in");
                Social.ShowAchievementsUI();
            }
            else
            {
                Debug.Log("login failed");
            }
        });
    }
}
