using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    private AudioSource SoundCoinCollect;

    void Start(){
        SoundCoinCollect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other){ 
        if(other.CompareTag("Player"))
        { 
            SoundCoinCollect.Play();
            Knight.TotalMoney+=1;           
            Destroy(this.gameObject, 0.25f);
        }  
    }
    
}
