using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public ParticleSystem p1;
    public ParticleSystem p2;
    public ParticleSystem p3;
    public ParticleSystem p4;
    public ParticleSystem p5;
    public ParticleSystem p6;

    


    // Start is called before the first frame update
    void Start()
    {
        p1.Play();
        p2.Play();
        p3.Play();
        p4.Play();
        p5.Play();
        p6.Play();

        Finish.finish = true;
    }
    private void Awake()
    {
        p1.Play();
        p2.Play();
        p3.Play();
        p4.Play();
        p5.Play();
        p6.Play();

        Finish.finish = true;
    }
}
