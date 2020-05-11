using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameoverMenu : MonoBehaviour
{
    public gameLogic logic;
    private bool once = false;
    private Vector3 canvaspos;
    public float menuspeed = 1.5f;


    void Start()
    {
        logic = GameObject.Find("Main Camera").GetComponent<gameLogic>();
    }

    void Update()
    {
        if (logic.gameover != 0 && once == false)
        {
            once = true;
            StartCoroutine(screenappear());
            if (logic.gameover == 1)
            {
                this.transform.GetChild(1).GetComponent<Text>().text = "out of time";

            }
            else if (logic.gameover == 2)
            {
                this.transform.GetChild(1).GetComponent<Text>().text = "well done";


                GameObject.Find("ads").GetComponent<achivments>().level1done();
            }
        }
    }


    public IEnumerator screenappear()
    {
        canvaspos = new Vector3((this.gameObject.transform.parent.GetComponent<RectTransform>().rect.width / 2) * this.gameObject.transform.parent.transform.localScale.x, (this.gameObject.transform.parent.GetComponent<RectTransform>().rect.height / 2) * this.gameObject.transform.parent.transform.localScale.y, 0.0f);
        for (float i = 0.0f; i < 1.0f; i += Time.deltaTime * menuspeed)
        {
            float iinterprate = Mathf.Sin((i * Mathf.PI) / 2);
            this.gameObject.transform.position = Vector3.Lerp(new Vector3(0.0f, this.transform.parent.gameObject.GetComponent<RectTransform>().rect.height, 0.0f) + canvaspos, Vector3.zero + canvaspos, iinterprate);
            yield return null;
        }

        this.gameObject.transform.position = Vector3.zero + canvaspos;
        yield return null;
    }

    public void menuReturn()
    {
        if (logic.gameover == 1)
        {
            if (PlayerPrefs.GetInt("noads") == 1)
            {
                Debug.Log("thanks suporter");
            }
            else
            {
                GameObject.Find("ads").GetComponent<ads>().ShowAD();
            }
        }

        SceneManager.LoadScene(0);
    }

    public void retrylevel()
    {
        SceneManager.LoadScene(1);
    }
}
