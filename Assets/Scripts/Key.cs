using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
   private BoxCollider2D Boxcollider;
   private Animator animator;
   public AudioSource SoundDoor;
   void Start(){
        SoundDoor = GetComponent<AudioSource>();
   }
   private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag=="Player"){  
            Door.animator.SetBool("OpenDoorLv1",true);
            Door.Boxcollider.enabled=false;
            SoundDoor.Play();
            Destroy(this.gameObject);
        }   
    }
}
