using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AC130 : MonoBehaviour
{
    public GameObject missile;
    public float missileSpeed;

    public cinematicMenu cam;

    public RectTransform joystick;
    public RectTransform Firebutton;

    public GameObject cloud;

    public AudioSource fire;
    public AudioSource reload;

    public float reloading = 0.0f;
    

    void Start()
    {
        cam = this.gameObject.GetComponent<cinematicMenu>();
    }

    void Update()
    {
        if (reloading > 0.0f)
        {
            reloading -= Time.deltaTime;
        }
        else if (reloading < 0.0f)
        {
            reloading = 0.0f;
        }

        if (Input.GetMouseButton(0) == true)
        {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(joystick, Input.mousePosition, null, out pos);

            Vector2 nullpos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(Firebutton, Input.mousePosition, null, out nullpos);


            Vector2 normalisedPos = new Vector2(0.0f, 0.0f);

            if (pos.x >= -(joystick.rect.width / 2) && pos.x < (joystick.rect.width / 2) && pos.y >= -(joystick.rect.height / 2) && pos.y < (joystick.rect.height / 2))
            {
                normalisedPos.x = pos.x / joystick.rect.width;
                normalisedPos.y = pos.y / joystick.rect.height;
            }



            if (nullpos.x >= -(Firebutton.rect.width / 2) && nullpos.x < (Firebutton.rect.width / 2) && nullpos.y >= -(Firebutton.rect.height / 2) && nullpos.y < (Firebutton.rect.height / 2))
            {
                normalisedPos = new Vector2(0.0f, 0.0f);
            }

            cam.aiming += new Vector2(-normalisedPos.y, normalisedPos.x);
        }


    }


    public void FIRE()
    {
        if (reloading <= 0.0f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                reloading = Mathf.Infinity;
                Instantiate(cloud, this.gameObject.transform.position + (transform.forward * 20.0f) + (transform.right * 20.0f), Quaternion.identity);
                fire.Play();
                StartCoroutine(camshake());
                GameObject tmp = Instantiate(missile, this.gameObject.transform.position + (transform.forward * 20.0f) + (transform.right * 10.0f), Quaternion.identity);
                tmp.transform.LookAt(hit.point);
                tmp.transform.Rotate(new Vector3(90.0f, 0.0f, 0.0f));
                tmp.GetComponent<missile>().bulletSpeed = missileSpeed;
            }
        }
    }

    public IEnumerator camshake()
    {
        int shakespeed = 15;
        Vector2 currentPOS = cam.camshake;


        for (int j = 0; j < ((float)shakespeed / 2.0f); j++)
        {

            Vector2 rand = new Vector2(Random.Range(0.6f, 0.8f), Random.Range(0.6f, 0.8f));

            if (Random.Range(-1.0f, 1.0f) < 0.0f)
            {
                rand.x = -rand.x;
            }
            if (Random.Range(-1.0f, 1.0f) < 0.0f)
            {
                rand.y = -rand.y;
            }

            currentPOS = cam.camshake;

            for (float i = 0.0f; i < 1.0f; i += Time.deltaTime * (float)shakespeed)
            {
                cam.camshake = new Vector2(Mathf.Lerp(currentPOS.x, rand.x, i), Mathf.Lerp(currentPOS.y, rand.y, i));
                yield return null;
            }


        }


        currentPOS = cam.camshake;

        for (float i = 1.0f; i > 0.0f; i -= Time.deltaTime * (float)shakespeed)
        {
            cam.camshake = new Vector2(currentPOS.x * i, currentPOS.y * i);
            yield return null;
        }

        cam.camshake = new Vector2(0.0f, 0.0f);

        reload.Play();
        reloading = reload.clip.length;

        yield return null;
    
    }
}
