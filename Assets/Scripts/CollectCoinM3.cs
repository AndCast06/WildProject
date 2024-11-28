using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoinM3 : MonoBehaviour
{
    //private AudioSource SoundHeartCollect;
    public GameObject SBarMag3;
    void Start(){
        //SoundHeartCollect = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other){ 
        if(other.CompareTag("Player")){   
            Knight.magic3Collect=true; 
            SBarMag3.SetActive(true);
            //SoundHeartCollect.Play();        
            Destroy(this.gameObject, 0.65f);
        }  
    }  
}
