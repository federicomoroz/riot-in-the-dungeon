using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [HideInInspector] public Slider   slider;
                      public Gradient gradient;
                      public Image    fill;


    void Start()
    {
        slider = GetComponent<Slider>();
        SetMaxHealth(GameManager.instance.playerHpMax);
    }    

  
    void Update()
    {         
        SetHealth(GameManager.instance.playerHpCurrent);    
        
    }

    public void SetHealth (float health)
    {
        slider.value   = health;
        fill.color     = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        fill.color      = gradient.Evaluate(1f);
        
    }
}
