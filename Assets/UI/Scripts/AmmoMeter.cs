using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoMeter : MonoBehaviour
{
    public Slider   slider;
    public Gradient gradient;
    public Image    fill;

    void Start()
    {
        
    }

 
    void Update()
    {
        
    }

    public void SetMaxAmmo(int ammo)
    {
        slider.maxValue = ammo;       
        fill.color      = gradient.Evaluate(1f);
    }

    public void SetAmmo(float ammo)
    {
        slider.value = ammo;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
