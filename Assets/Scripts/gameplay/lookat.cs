using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour
{
    public GameObject cam;

    void Update()
    {
        this.gameObject.transform.LookAt(cam.transform.position);
    }
}
