using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessSettings : MonoBehaviour
{
    public Slider SliderBright;
    public float sliderValue;
    public Image panelBright;
    // Start is called before the first frame update
    void Start()
    {     
        SliderBright.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        panelBright.color = new Color(panelBright.color.r,panelBright.color.g,panelBright.color.b,SliderBright.value);      
    }

    public void ChangeSlider(float valor){
        sliderValue = valor;
        PlayerPrefs.SetFloat("brillo", sliderValue);
        panelBright.color = new Color(panelBright.color.r,panelBright.color.g,panelBright.color.b,SliderBright.value);
    }

}
