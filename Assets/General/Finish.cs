using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public HaveThoughts haveThoughts;
    public static bool finish = false;

    // Update is called once per frame
    private void Start()
    {
        haveThoughts = GetComponent<HaveThoughts>();
    }
    void Update()
    {
        if(finish)
        {   
            haveThoughts.text = "All finished at last.";
            haveThoughts.repeating = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (finish) StartCoroutine(drive());
    }

    private IEnumerator drive()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Credits");
    }
}
