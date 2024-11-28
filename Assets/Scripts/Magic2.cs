using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic2 : MonoBehaviour
{
    [SerializeField] private float speed;
    public static int dañoMagic2=30;
    public static Vector2 direction;
    public static Rigidbody2D rigidbody2D;
    public static AudioSource SoundMagic2;
    // Update is called once per frame
    void Start(){
        rigidbody2D = GetComponent<Rigidbody2D>();
        SoundMagic2 = GetComponent<AudioSource>();
        SoundMagic2.Play();
    }

    void FixedUpdate()
    {
       rigidbody2D.velocity=direction*speed;
       Destroy(this.gameObject, 5f);    
    }

    private void OnTriggerEnter2D(Collider2D other){    
        if(other.gameObject.tag=="Golem3T"){
            other.GetComponent<Golem3>().vidasGolemG-=dañoMagic2;    
            Destroy(this.gameObject); 
        }
    }
}
