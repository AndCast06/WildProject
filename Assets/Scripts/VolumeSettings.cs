using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public Slider SliderVolume;
    public float sliderValue;
    // Start is called before the first frame update
    void Start()
    {
        SliderVolume.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = SliderVolume.value;           
    }

    public void ChangeSlider(float valor){
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = SliderVolume.value;
    }

}
