using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerEndGame : MonoBehaviour
{
    void Start(){
        SoundGameWin = GetComponent<AudioSource>();
    }
    private AudioSource SoundGameWin;
    public GameObject gameWinPanel;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag=="Player"){  
            Time.timeScale = 0;    
            SoundGameWin.Play();
            gameWinPanel.SetActive(true);  
        }   
    }
}
