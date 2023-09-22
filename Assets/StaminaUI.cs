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

    CanvasGroup cg;

    // Start is called before the first frame update
    void Start()
    {
        raccoon = GameObject.Find("Coon").GetComponent<Movement>();

        slider = GetComponent<Slider>();
        sliderImage = transform.Find("StaminaArea/Fill").GetComponent<Image>();
        staminaDmg = transform.Find("StaminaDmg").GetComponent<Slider>();
        staminaDmgImage = transform.Find("StaminaDmg/Fill Area/Fill").GetComponent<Image>();
        background = transform.Find("Background").GetComponent<Image>();

        sliderImage.color = new Color(70f / 255, 1f, 55f / 255);
        staminaDmgImage.color = new Color(1f, 1f, 1f);

        cg = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        float stamina = raccoon.stamina;
        if (stamina != 1) change = 1;

        var alpha = Mathf.Clamp01(change);

        Color c = backgroundColor.Evaluate(1f - stamina);
        background.color = c;

        cg.alpha = alpha;
        

        staminaDmg.value = Mathf.Lerp(staminaDmg.value, stamina, 0.025f);
        slider.value = stamina;



        if(change > 0) change -= Time.deltaTime;
    }
}
