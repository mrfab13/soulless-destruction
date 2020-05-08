using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class mainMenu : MonoBehaviour
{
    public bool creditsToggle = false;
    public bool LevelToggle = false;

    public GameObject cList;
    public GameObject MList;
    public GameObject Llist;

    private Vector3 cListtop;
    private Vector3 cListmid = Vector3.zero;
    private Vector3 cListbot;
    private Vector3 MListtop;
    private Vector3 MListmid = Vector3.zero;
    private Vector3 MListbot;
    private Vector3 LListtop;
    private Vector3 LListmid = Vector3.zero;
    private Vector3 LListbot;
    private GameObject canvas;

    private Vector3 canvaspos;
    private GameObject ads;
    float menuspeed = 1.5f;

    public enum state
    {
        credits,
        menu,
        level,
    }

    public state theState = state.menu;

    void Start()
    {
        ads = GameObject.Find("ads");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        canvas = GameObject.Find("Canvas");
        canvaspos = new Vector3((this.gameObject.GetComponent<RectTransform>().rect.width / 2) * canvas.transform.localScale.x, (this.gameObject.GetComponent<RectTransform>().rect.height / 2) * canvas.transform.localScale.y, 0.0f);
        cListtop = new Vector3(0.0f, this.gameObject.GetComponent<RectTransform>().rect.height, 0.0f);
        cListbot = new Vector3(0.0f, -this.gameObject.GetComponent<RectTransform>().rect.height, 0.0f);
        MListtop = new Vector3(0.0f, this.gameObject.GetComponent<RectTransform>().rect.height, 0.0f);
        MListbot = new Vector3(0.0f, -this.gameObject.GetComponent<RectTransform>().rect.height, 0.0f);
        LListtop = new Vector3(0.0f, this.gameObject.GetComponent<RectTransform>().rect.height, 0.0f);
        LListbot = new Vector3(0.0f, -this.gameObject.GetComponent<RectTransform>().rect.height, 0.0f);

    }



    public void play()
    {
        if (LevelToggle == true)
        {
            LevelToggle = false;
            StartCoroutine(Down(state.level, state.menu));
        }
        else
        {
            Social.LoadAchievements(achives =>
            {
                if (achives.Length > 0)
                {
                    foreach (IAchievement achive in achives)
                    {
                        if (achive.id == SoullessDestructionAchievements.achievement_completed_level_1)
                        {
                            if (achive.completed == true)
                            {
                                GameObject.Find("levle2").GetComponent<Button>().interactable = true;
                            }
                        }
                        if (achive.id == SoullessDestructionAchievements.achievement_completed_level_2)
                        {
                            if (achive.completed == true)
                            {
                                GameObject.Find("levle3").GetComponent<Button>().interactable = true;
                            }
                        }
                    }
                }
            });



            LevelToggle = true;
            StartCoroutine(Down(state.menu, state.level));
        }
    }

    public void credits()
    {
        if (creditsToggle == true)
        {
            creditsToggle = false;
            StartCoroutine(Down(state.credits, state.menu));
        }
        else
        {
            creditsToggle = true;
            StartCoroutine(Down(state.menu, state.credits));
        }
    }

    public void showLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }

    public void quit()
    {
        Application.Quit();
    }

    public void twitter()
    {
        ads.GetComponent<ads>().OpenTwitter();
    }

    public void noads()
    {
        ads.GetComponent<IAP>().buyProductID(IAP.RemoveAds);
    }

    public void loadlevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public IEnumerator Down(state fromX, state toY)
    {
        canvaspos = new Vector3((this.gameObject.GetComponent<RectTransform>().rect.width / 2) * canvas.transform.localScale.x, (this.gameObject.GetComponent<RectTransform>().rect.height / 2) * canvas.transform.localScale.y, 0.0f);
        cListtop = new Vector3(0.0f, this.gameObject.GetComponent<RectTransform>().rect.height, 0.0f);
        cListbot = new Vector3(0.0f, -this.gameObject.GetComponent<RectTransform>().rect.height, 0.0f);
        MListtop = new Vector3(0.0f, this.gameObject.GetComponent<RectTransform>().rect.height, 0.0f);
        MListbot = new Vector3(0.0f, -this.gameObject.GetComponent<RectTransform>().rect.height, 0.0f);
        LListtop = new Vector3(0.0f, this.gameObject.GetComponent<RectTransform>().rect.height, 0.0f);
        LListbot = new Vector3(0.0f, -this.gameObject.GetComponent<RectTransform>().rect.height, 0.0f);

        GameObject from = null;
        Vector3 from1 = Vector3.zero;
        Vector3 from2 = Vector3.zero;
        GameObject to = null;
        Vector3 to1 = Vector3.zero;
        Vector3 to2 = Vector3.zero;

        if (fromX == state.menu)
        {
            from = MList;
            from1 = MListmid;
            from2 = MListbot;
        }
        else if (fromX == state.credits)
        {
            from = cList;
            from1 = cListmid;
            from2 = cListbot;
        }
        else if (fromX == state.level)
        {
            from = Llist;
            from1 = LListmid;
            from2 = LListbot;
        }

        if (toY == state.menu)
        {
            to = MList;
            to1 = MListtop;
            to2 = MListmid;
        }
        else if (toY == state.credits)
        {
            to = cList;
            to1 = cListtop;
            to2 = cListmid;
        }
        else if (toY == state.level)
        {
            to = Llist;
            to1 = LListtop;
            to2 = LListmid;
        }


        for (float i = 0.0f; i < 1.0f; i += Time.deltaTime * menuspeed)
        {
            float iinterprate = Mathf.Sin((i * Mathf.PI) / 2);

            to.transform.position = Vector3.Lerp(to1 + canvaspos, to2 + canvaspos, iinterprate);
            from.transform.position = Vector3.Lerp(from1 + canvaspos, from2 + canvaspos, iinterprate);

            yield return null;
        }

        to.transform.position = to2 + canvaspos;
        from.transform.position = from2 + canvaspos;

        yield return null;
    }
}
