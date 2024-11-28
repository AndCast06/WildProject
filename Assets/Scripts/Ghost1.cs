using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost1 : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float rangoAgro; // A cuanta distancia el enemigo ve al jugador
    public float velocidadMov;
    private bool miraDerecha;
    Rigidbody2D rb2d;
    private bool isLive=true;
    private Animator anim;
    [SerializeField] private GameObject Coin;
    public int vidasGhost=50;
    private AudioSource SoundAttackGhost;
    [SerializeField] private float tiempoEntreDaño;
    private float tiempoSiguienteDaño;
    int contadorCoin=0;

    // Start is called before the first frame update
    void Start()
    {
        miraDerecha = true;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        SoundAttackGhost = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Distancia hasta el jugador
        float distJugador = Vector2.Distance(transform.position, player.position);
        if (distJugador < rangoAgro && Mathf.Abs(distJugador) > 1)
        {
            if(isLive){
                PerseguirJugador(); //Funcion de perseguir
            }        
        }
        else
        {
            if(isLive){
                NoPerseguir(); 
            }     
        }

        if(Knight.vidas<=0){
            NoPerseguir();
            anim.SetBool("GhostAtaca", false);
        } 

        if(vidasGhost<=0){
            isLive=false;
            rb2d.velocity = new Vector2(0,2); 
            anim.SetBool("GhostMoviendose", false); 
            NoPerseguir();  
            anim.SetBool("GhostAtaca", false);
            anim.SetBool("GhostMuere", true); 
            Destroy(this.gameObject, 0.8f);
            if(contadorCoin==0){
               Instantiate(Coin, transform.position, Quaternion.identity);
               contadorCoin+=1;
            }  
        }

    }
    
    private void OnCollisionStay2D(Collision2D collision){ 
        if(collision.gameObject.tag=="Player")
        {
            tiempoSiguienteDaño -= Time.deltaTime;
            if(tiempoSiguienteDaño <= 0){
                if(Knight.vidas>=0){
                    SoundAttackGhost.Play();
                    anim.SetBool("GhostAtaca", true);
                    Knight.vidas = Knight.vidas-30;
                    Knight.isHurt = true;
                    tiempoSiguienteDaño=tiempoEntreDaño;   
                    anim.SetBool("GhostMoviendose", false);    
                }
            }     
        }  
    }

    private void NoPerseguir()
    {
        rb2d.velocity = Vector2.zero;
        anim.SetBool("GhostMoviendose", false);
        anim.SetBool("GhostAtaca", false);
    }

    private void PerseguirJugador()
    {
        anim.SetBool("GhostMoviendose", true); 
        //Si estamos a la izquierda del jugador entonces movemos el enemigo hacia la derecha
        if (transform.position.x < player.position.x && !miraDerecha)
        {
            rb2d.velocity = new Vector2(velocidadMov,0f);
            Flip();
        }
        else if(transform.position.x > player.position.x && miraDerecha)
        {
            rb2d.velocity = new Vector2(-velocidadMov, 0f);
            Flip();
        }
        else if(!miraDerecha)
        {
            rb2d.velocity = new Vector2(-velocidadMov, 0f);
        }
        else if (miraDerecha)
        {
            rb2d.velocity = new Vector2(velocidadMov, 0f);
        }
    }

    private void Flip()
    {
        // Defino nuevamente hacia donde esta mirando el jugador
        miraDerecha = !miraDerecha;

        // Multiplicar la escala en X del personaje por -1
        Vector3 laEscala = transform.localScale;
        laEscala.x *= -1;
        transform.localScale = laEscala;
    }
}
