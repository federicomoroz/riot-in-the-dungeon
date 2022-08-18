using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoeHealthBar : MonoBehaviour
{
                      private FoeMain  mainScript;
    [HideInInspector] public  Slider   slider;
                      public  Gradient gradient;
                      public  Image    fill;


    void Start()
    {
        mainScript = GetComponent<FoeMain>();
        slider     = GetComponent<Slider>();
        SetMaxHealth(40);
       
    }


    void Update()
    {
        //SetHealth(mainScript.statsManager.hpCurrent);

    }

    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        fill.color = gradient.Evaluate(1f);

    }
}
