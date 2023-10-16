using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Febucci.UI;

public class Thoughts : MonoBehaviour
{
    static float time = 0;
    static bool finished = false;

    public static TextMeshProUGUI display;
 
    AudioClip s_raccoon;

    private void Start()
    {
        display = GetComponent<TextMeshProUGUI>();
        s_raccoon = Resources.Load<AudioClip>("Sounds/RaccoonSpeech");

        display.text = "";
    }

    private void Update()
    {
        if (time > 0 && finished)
        {
            time -= Time.deltaTime;
        }
        if(time <= 0) display.text = "";
    }

    public static void setText(string newtext)
    {
        display.text = newtext;
        finished = false;
        time = 999;
    }

    public void TextFinished()
    {
        finished = true;
        time = 3;
    }


    public void MakeSound()
    {
        SoundManager.play(s_raccoon, gameObject, 1, 0);
    }
}
