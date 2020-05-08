using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    private float spin = 0.0f;
    public float rate = 1.0f;

    void Update()
    {
        spin += rate * Time.deltaTime;
        transform.Rotate(new Vector3(0.0f, spin, 0.0f));
    }
}
