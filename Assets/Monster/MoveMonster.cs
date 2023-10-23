using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMonster : MonoBehaviour
{
    public Vector3 position;
    public GameObject toDestroy;
    public AudioClip ac;

    public static GameObject monster;

    private void Start()
    {
        if (monster == null) monster = GameObject.Find("Monster");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Coon")
        {
            if (toDestroy != null) Destroy(toDestroy);
            if (ac != null) SoundManager.play(ac,gameObject);
            Destroy(monster);

            Destroy(this);
        }
    }
}
