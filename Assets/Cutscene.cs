using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public CameraMovement cm;
    public Movement pm;

    float time = 5;

    Vector3 originalPos;

    Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
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
            lastPosition = cm.transform.position;
            cm.transform.position = Vector3.Lerp(pm.transform.position + new Vector3(0,1), originalPos, time/5 * EaseInOut(time/5));

            Vector3 speed = cm.transform.position - lastPosition;
            Quaternion target = Quaternion.Euler(5 - speed.y * 2, speed.x * 2, 0);

            transform.rotation = Quaternion.Lerp(transform.rotation, target, .05f);
        }
        else
        {
            changeEnabled(true);
            Destroy(gameObject);
        }


        time -= Time.deltaTime;
    }
}
