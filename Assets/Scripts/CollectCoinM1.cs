using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoinM1 : MonoBehaviour
{
    //private AudioSource SoundHeartCollect;
    public GameObject SBarMag1;
    void Start(){
        //SoundHeartCollect = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other){ 
        if(other.CompareTag("Player")){  
            Knight.magic1Collect=true; 
            SBarMag1.SetActive(true);
            //SoundHeartCollect.Play();        
            Destroy(this.gameObject, 0.65f);
        }  
    }  
}
