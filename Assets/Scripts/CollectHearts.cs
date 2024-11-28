using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectHearts : MonoBehaviour
{
    private AudioSource SoundHeartCollect;
    void Start(){
        SoundHeartCollect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other){ 
        if(other.CompareTag("Player"))
        { 
            SoundHeartCollect.Play();
            Knight.vidas = Knight.vidas+20;           
            Destroy(this.gameObject, 0.3f);
        }  
    }
    
}
