using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic1 : MonoBehaviour
{
    [SerializeField] private float speed;
    public static int dañoMagic1=20;
    public static Vector2 direction;
    public static Rigidbody2D rigidbody2D;
    public AudioSource SoundMagic1;
    // Update is called once per frame
    void Start(){
        rigidbody2D = GetComponent<Rigidbody2D>();
        SoundMagic1 = GetComponent<AudioSource>();
        SoundMagic1.Play();
    }

    void FixedUpdate()
    {
       rigidbody2D.velocity=direction*speed;
       Destroy(this.gameObject, 5f);    
    }

    private void OnTriggerEnter2D(Collider2D other){    
        if(other.gameObject.tag=="Golem1G"){
            other.GetComponent<Golem1>().vidasGolemG-=dañoMagic1;    
            Destroy(this.gameObject); 
        }
        if(other.gameObject.tag=="Golem2P"){
            other.GetComponent<Golem2>().vidasGolemG-=dañoMagic1;    
            Destroy(this.gameObject); 
        }
    }
}
