using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Febucci.UI;

public class StartGame : MonoBehaviour
{
    public bool ending = false;
    int id = -1;
    [TextArea(10, 10)]
    public string[] text = { "", "" };

    public Speech[] voice;
    public TextMeshProUGUI display;
    public TextAnimatorPlayer animator;
    public Image image;

    bool finished = false;

    AudioClip s_raccoon;
    AudioClip s_amelia;
    AudioClip s_boss;
    AudioClip s_system;
    float speed;

    bool complete = false;

    public enum Speech
    {
        Raccoon,
        Boss,
        System,
        Lover
    }

    private void Start()
    {
        s_raccoon = Resources.Load<AudioClip>("Sounds/RaccoonSpeech");
        s_amelia = Resources.Load<AudioClip>("Sounds/LoverSpeech");
        s_boss = Resources.Load<AudioClip>("Sounds/BossSpeech");
        s_system = Resources.Load<AudioClip>("Sounds/SystemSpeech");
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
        if (complete != true)
        {
            finished = false;
            changeSpeed(1);
            id++;
            if (id >= text.Length)
            {
                if (!ending) Begin();
                else StartCoroutine(End());
                complete = true;
            }
            else display.text = text[id];
        }
    }

    private void changeSpeed(float newSpeed)
    {
        animator.SetTypewriterSpeed(newSpeed);
        speed = newSpeed;
    }

    public void MakeSound()
    {
        
        AudioClip c;
        
        switch (voice[id])
        {
            default:
            case Speech.Raccoon:
                c = s_raccoon;
                break;

            case Speech.Boss:
                c = s_boss;
                break;
            case Speech.System:
                c = s_system;
                break;
            case Speech.Lover:
                c = s_amelia;
                break;
        }
        SoundManager.play(c, gameObject, 1, 0);
    }

    public static void Begin()
    {
        SceneManager.LoadScene("Warehouse");
    }
    public IEnumerator End()
    {
        print("End");
        float time = 0;
        while (time < 1)
        {
            time += Time.deltaTime/4f;
            yield return null;
            image.color = new Color(0, 0, 0, time);
        }
    }
}
