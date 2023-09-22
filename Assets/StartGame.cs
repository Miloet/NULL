using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartGame : MonoBehaviour
{
    int id = -1;
    public string[] text = { "", "" };
    public TextMeshProUGUI display;

    bool active = false;

    public AudioClip[] sound;

    private void Start()
    {
        StartCoroutine(waitForNext(0));
    }
    public void NextText()
    {
        if(!active) StartCoroutine(waitForNext(3));
    }

    private IEnumerator waitForNext(int time)
    {
        active = true;
        yield return new WaitForSeconds(time);
        id++;
        if (id >= text.Length)
        {
            Begin();
        }
        else display.text = text[id];
        active = false;
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
