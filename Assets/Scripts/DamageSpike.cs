using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSpike : MonoBehaviour
{
   private AudioSource SoundSpike;
   [SerializeField] private float tiempoEntreDaño;
   private float tiempoSiguienteDaño;
   void Start(){
        SoundSpike = GetComponent<AudioSource>();
    }
   private void OnTriggerStay2D(Collider2D other){ 
        if(other.CompareTag("Player"))
        { 
            tiempoSiguienteDaño -= Time.deltaTime;
            if(tiempoSiguienteDaño <= 0){
                SoundSpike.Play();
                Knight.vidas = Knight.vidas-20;
                Knight.isHurt = true;
                tiempoSiguienteDaño=tiempoEntreDaño;       
            }    
        }  
    }
}
