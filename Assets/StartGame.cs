using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Febucci.UI;

public class StartGame : MonoBehaviour
{
    int id = -1;
    [TextArea(10, 10)]
    public string[] text = { "", "" };
    public TextMeshProUGUI display;
    public TextAnimatorPlayer animator;

    bool finished = false;

    public AudioClip[] sound;
    float speed;

    private void Start()
    {
        waitForNext();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (speed == 2) animator.SkipTypewriter();
            changeSpeed(2);
            if(finished == true)
            {
                NextText();
            }

        }
    }

    public void NextText()
    {
        waitForNext();
    }

    public void TextFinished()
    {
        finished = true;
    }

    private void waitForNext()
    {
        finished = false;
        changeSpeed(1);
        id++;
        if (id >= text.Length)
        {
            Begin();
        }
        else display.text = text[id];
    }

    private void changeSpeed(float newSpeed)
    {
        animator.SetTypewriterSpeed(newSpeed);
        speed = newSpeed;
    }

    public void MakeSound()
    {
        if (sound.Length > 0)
        {
            AudioClip c = sound[Random.Range(0, sound.Length - 1)];
            SoundManager.play(c, gameObject, 1, 0);
        }
    }

    public static void Begin()
    {
        SceneManager.LoadScene("Warehouse");
    }
}
