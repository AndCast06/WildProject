using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject optionsPanel;
    public GameObject settingsPanel;

    public void OptionsPanel(){
        Time.timeScale = 0;
        optionsPanel.SetActive(true);
        settingsPanel.SetActive(false);   
    }

    public void SettingsPanel(){
        settingsPanel.SetActive(true);       
    }

    public void Return(){
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
    }

    public void StartHome(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Nvl_1");
        Knight.vidas=100;
        Knight.TotalMoney=0;
        Knight.CMagics1 = 5;
        Knight.CMagics2 = 5;
        Knight.CMagics3 = 5;
        Knight.magic1Collect = false;
        Knight.magic2Collect = false;
        Knight.magic3Collect = false;
    }

    public void GoNvl2(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Nvl_2");
        Knight.TotalMoney = 30;
        Knight.CMagics1 = 5;
        Knight.CMagics2 = 5;
        Knight.CMagics3 = 5;
        Knight.magic1Collect = true;
        Knight.magic2Collect = true;
        Knight.magic3Collect = false;
    }

    public void GoHome(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Home");
    }

    public void RestartLevel2(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Knight.vidas=100;
        Knight.TotalMoney=30;
        Knight.CMagics1 = 5;
        Knight.CMagics2 = 5;
        Knight.CMagics3 = 5;
        Knight.magic3Collect = false;
    }

    public void RestartLevel(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Knight.vidas=100;
        Knight.TotalMoney=0;
        Knight.CMagics1 = 5;
        Knight.CMagics2 = 5;
        Knight.CMagics3 = 5;
        Knight.magic1Collect = false;
        Knight.magic2Collect = false;
        Knight.magic3Collect = false;
    }

    public void QuitGame(){
        Application.Quit();
    }
}
