using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ADVANCEFISHAI : MonoBehaviour
{
    public List<Vector3> positions = new List<Vector3>() { };
    public int poscurrent = 0;
    public float movespeed = 1.5f;

    void Update()
    {

        Vector3 movedir = (positions[poscurrent] - transform.position).normalized;
        transform.position += (movedir * movespeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, positions[poscurrent]) < 0.5f)
        {
            poscurrent++;
            if (poscurrent >= positions.Count)
            {
                poscurrent = 0;
            }
        }
    }
}
