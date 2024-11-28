using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword1 : MonoBehaviour
{   
    private AudioSource SoundAttackEspada;
    private Animator animator;
    public static bool isAttack;
    public static int dañoSword1=10;
    private PolygonCollider2D Polygincollider;

    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        animator = GetComponent<Animator>();
        SoundAttackEspada = GetComponent<AudioSource>();
        Polygincollider = GetComponent<PolygonCollider2D>();
    }
   
    void Update()
    {
        if(Input.GetButtonDown("Slash")){
            Attack();                    
        }
        else{
            animator.SetBool("estaAtacando",false);
            isAttack=false;
        }        

        if(Knight.vidas<=0){
            Destroy(this.gameObject);
        }

        if(Input.GetButtonDown("Fire1")){
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else if(Input.GetButtonDown("Fire2")){
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else if(Input.GetButtonDown("Fire3")){
            GetComponent<SpriteRenderer>().enabled = false;
        }

    }

    public void Attack(){
        if(Knight.isGrounded){             
            GetComponent<SpriteRenderer>().enabled = true;
            Polygincollider.enabled=true;
            SoundAttackEspada.Play();
            animator.SetBool("estaAtacando",true);
            Knight.animator.SetBool("estaCaminando",false);
            Knight.rigidbody2D.velocity = new Vector2(0, Knight.rigidbody2D.velocity.y);
            Invoke("DisableCollider",0.5f);
        }  
    }

    public void DisableCollider(){
        Polygincollider.enabled=false;
    }
   
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag=="Golem1G"){  
            collision.GetComponent<Golem1>().vidasGolemG-=dañoSword1;
            Polygincollider.enabled=false;       
        }   
        else if(collision.gameObject.tag=="Golem2P"){  
            collision.GetComponent<Golem2>().vidasGolemG-=dañoSword1;
            Polygincollider.enabled=false;       
        }  
        else if(collision.gameObject.tag=="Golem3T"){  
            collision.GetComponent<Golem3>().vidasGolemG-=dañoSword1;
            Polygincollider.enabled=false;       
        }
    }
    
}
