using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterActive : MonoBehaviour
{
    public bool active = false;

    public Transform follow;
    public GameObject explotion1;
    public GameObject explotion2;

    float speed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            transform.position = Vector3.Lerp(transform.position, follow.position, speed * Time.deltaTime);
            speed = Mathf.Min(speed + Time.deltaTime, 1f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Coon")
        {
            if (Vector3.Distance(transform.position, follow.position) < 1) SceneManager.LoadScene("Intro");
            if (Vector3.Distance(transform.position, follow.position) < 5) active = true;
        }
        if (other.name == "Die")
        {
            var g = Instantiate(explotion1);
            g.transform.position = transform.position;
            g = Instantiate(explotion2);
            g.transform.position = transform.position;

            Destroy(gameObject);
        }
    }
    
}
