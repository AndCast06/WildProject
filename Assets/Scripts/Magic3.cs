using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic3 : MonoBehaviour
{
    [SerializeField] private float speed;
    public static int dañoMagic3=20;
    public static Vector2 direction;
    public static Rigidbody2D rigidbody2D;
    public AudioSource SoundMagic3;
    // Update is called once per frame
    void Start(){
        rigidbody2D = GetComponent<Rigidbody2D>();
        SoundMagic3 = GetComponent<AudioSource>();
        SoundMagic3.Play();
    }

    void FixedUpdate()
    {
       rigidbody2D.velocity=direction*speed;
       Destroy(this.gameObject, 5f);    
    }

    private void OnTriggerEnter2D(Collider2D other){    
        if(other.gameObject.tag=="Ghost1"){
            other.GetComponent<Ghost1>().vidasGhost-=dañoMagic3;    
            Destroy(this.gameObject); 
        }
    }
}
