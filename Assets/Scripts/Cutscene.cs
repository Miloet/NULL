using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public CameraMovement cm;
    public Movement pm;

    Material m1;
    Material m2;

    float time = 5;

    Vector3 originalPos;

    Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        GameObject g = transform.Find("Plane").gameObject;
        g.SetActive(true);
        m1 = g.GetComponent<Renderer>().material;
        g = transform.Find("Plane2").gameObject;
        g.SetActive(true);
        m2 = transform.Find("Plane2").GetComponent<Renderer>().material;

        changeEnabled(false);
        originalPos = cm.transform.position;
    }

    private void changeEnabled(bool b)
    {
        cm.enabled = b;
        pm.enabled = b;
    }

    float EaseInOut(float t)
    {
        if (t <= 0.5f)
            return 2.0f * t * t;
        t -= 0.5f;
        return 2.0f * t * (1.0f - t) + 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            m1.color = new Color(0, 0, 0, EaseInOut(time / 5));
            m2.color = new Color(0, 0, 0, EaseInOut(time / 5));
            lastPosition = cm.transform.position;
            cm.transform.position = Vector3.Lerp(pm.transform.position + new Vector3(0,1), originalPos, time/5 * EaseInOut(time/5));

            cm.gameObject.transform.rotation = Quaternion.Euler(5, 0, 0);
        }
        else
        {
            changeEnabled(true);
            Destroy(gameObject);
        }


        time -= Time.deltaTime/2f;
    }
}
