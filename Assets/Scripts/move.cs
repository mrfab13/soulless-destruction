using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    void Update()
    { 
        this.gameObject.GetComponent<Transform>().localPosition += new Vector3(0.0f, 0.0f, 0.5f * Time.deltaTime);
    }
}
