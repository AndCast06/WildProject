using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPotion2 : MonoBehaviour
{
    private AudioSource SoundPotionCollect;
    void Start(){
        SoundPotionCollect= GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other){ 
        if(other.CompareTag("Player")){ 
            SoundPotionCollect.Play(); 
            Knight.CMagics2 = Knight.CMagics2+1;           
            Destroy(this.gameObject, 0.65f);
        }  
    }
}
