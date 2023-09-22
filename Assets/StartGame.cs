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

    public AudioClip[] sound;

    private void Start()
    {
        NextText();
    }
    public void NextText()
    {
        
    }

    private IEnumerator waitForNext()
    {
        yield return new WaitForSeconds(4);
        id++;
        if (id >= text.Length)
        {
            Begin();
        }
        else display.text = text[id];
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
