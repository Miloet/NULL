using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingController : MonoBehaviour
{
    Buffer attack ;
    public TrailRenderer trail;
    void Start()
    {
        attack = Buffer.SetBuffer(gameObject, 0.3f, false);
        //trail = GetComponent<TrailRenderer>();
        trail.emitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) attack.Pressed();

        if (attack.GetPress()) StartCoroutine(BeginAttack());

    }

    IEnumerator BeginAttack()
    {
        trail.emitting = true;

        yield return new WaitForSeconds(0.2f);

        trail.emitting = false;
    }
}
