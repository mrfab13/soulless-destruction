using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    private float bulletSpeed;

    public GameObject Bigexplosion;

    public LayerMask Civilian;

    void Update()
    {
        this.gameObject.transform.position += transform.up * Time.deltaTime * bulletSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        gameLogic tmp = GameObject.Find("Main Camera").GetComponent<gameLogic>();
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10.0f, Civilian);
        for (int i = hitColliders.Length; i > 0; i--)
        {
            tmp.kills--;
            tmp.updatedkills();
            Destroy(hitColliders[i - 1].gameObject);
        }

        Instantiate(Bigexplosion, this.gameObject.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
