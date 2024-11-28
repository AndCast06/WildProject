using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSettings : MonoBehaviour
{
    public Toggle toggle;
    public Dropdown resolucionesDropDown;
    Resolution[] resoluciones;
    // Start is called before the first frame update
    void Start()
    {     
        if(Screen.fullScreen){
            toggle.isOn = true;
        }
        else{
            toggle.isOn = false;
        }
        RevisarResolution();
    }

    public void ActivateFullScreen(bool fullscreen){
        Screen.fullScreen = fullscreen;
    }

    public void RevisarResolution(){
        resoluciones = Screen.resolutions;
        resolucionesDropDown.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActual = 0;

        for(int i=0; i < resoluciones.Length; i++){
            string opcion = resoluciones[i].width + "x" + resoluciones[i].height;
            opciones.Add(opcion);
            if(Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height){
                resolucionActual = i;
            }
        }
        resolucionesDropDown.AddOptions(opciones);
        resolucionesDropDown.value = resolucionActual;
        resolucionesDropDown.RefreshShownValue();
    }

    public void ChangeResolution(int indResolution){
        Resolution resolucion = resoluciones[indResolution];
        Screen.SetResolution(resolucion.width,resolucion.height,Screen.fullScreen);
    }

}
