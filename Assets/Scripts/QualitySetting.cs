using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QualitySetting : MonoBehaviour
{
    public Dropdown dropdown;
    public int calidad;
    // Start is called before the first frame update
    void Start()
    {     
       calidad = PlayerPrefs.GetInt("numeroDeCalidad", 3);
       dropdown.value = calidad;
       SetQuality();
    }

    public void SetQuality(){
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("numeroDeCalidad", dropdown.value);
        calidad = dropdown.value;
    }
}
