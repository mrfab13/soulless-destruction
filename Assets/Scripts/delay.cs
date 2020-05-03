using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delay : MonoBehaviour
{
    public float deleyclipby = 0.5f;

    void Start()
    {
        StartCoroutine(Delay());
    }

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(deleyclipby);

        this.gameObject.GetComponent<AudioSource>().Play();

        yield return null;
    }
}
