using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoinM2 : MonoBehaviour
{
    //private AudioSource SoundHeartCollect;
    public GameObject SBarMag2;
    void Start(){
        //SoundHeartCollect = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other){ 
        if(other.CompareTag("Player")){   
            Knight.magic2Collect=true; 
            SBarMag2.SetActive(true);
            //SoundHeartCollect.Play();        
            Destroy(this.gameObject, 0.65f);
        }  
    }  
}
