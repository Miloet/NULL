using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaUI : MonoBehaviour
{
    Movement raccoon;
    float change;


    Slider slider;
    Image sliderImage;
    Slider staminaDmg;
    Image staminaDmgImage;
    Image background;
    public Gradient backgroundColor;

    // Start is called before the first frame update
    void Start()
    {
        raccoon = GameObject.Find("Coon").GetComponent<Movement>();

        slider = GetComponent<Slider>();
        sliderImage = GetComponent<Image>();
        staminaDmg = GameObject.Find("StaminaDmg").GetComponent<Slider>();
        staminaDmgImage = GameObject.Find("StaminaDmg").GetComponent<Image>();



        background = transform.Find("Background").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float stamina = raccoon.stamina;
        if (stamina != 1) change = 5;

        Color c = backgroundColor.Evaluate(1f - stamina);
        c.a = change;
        background.color = c;

        staminaDmg.value = Mathf.Lerp(staminaDmg.value, stamina, 0.1f);

        slider.value = stamina;

        change -= Time.deltaTime;
    }
}
