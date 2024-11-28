using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSuriken : MonoBehaviour
{
    private AudioSource SoundSuriken;
    [SerializeField] private float tiempoEntreDaño;
    private float tiempoSiguienteDaño;
    public static Animator animator;
    void Start(){
        SoundSuriken = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    void Update(){
        animator.SetBool("SurikenMove",true);
    }
    private void OnTriggerStay2D(Collider2D other){ 
        if(other.CompareTag("Player"))
        { 
            tiempoSiguienteDaño -= Time.deltaTime;
            if(tiempoSiguienteDaño <= 0){
                SoundSuriken.Play();
                Knight.vidas = Knight.vidas-30;
                Knight.isHurt = true;
                tiempoSiguienteDaño=tiempoEntreDaño;       
            }    
        }  
    }

}
