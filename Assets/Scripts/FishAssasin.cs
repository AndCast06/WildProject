using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAssasin : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float rangoAgro; // A cuanta distancia el enemigo ve al jugador
    public float velocidadMov;
    private bool miraDerecha;
    Rigidbody2D rb2d;
    private Animator anim;
    [SerializeField] private float tiempoEntreDaño;
    private float tiempoSiguienteDaño;

    // Start is called before the first frame update
    void Start()
    {
        miraDerecha = true;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Distancia hasta el jugador
        float distJugador = Vector2.Distance(transform.position, player.position);
        if (distJugador < rangoAgro && Mathf.Abs(distJugador) > 1)
        {

            PerseguirJugador(); //Funcion de perseguir    
        }
        else
        {
            NoPerseguir();   
        }

        if(Knight.vidas<=0){
            NoPerseguir();
            anim.SetBool("FishAttack", false);
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision){ 
        if(collision.gameObject.tag=="Player")
        {
            tiempoSiguienteDaño -= Time.deltaTime;
            if(tiempoSiguienteDaño <= 0){
                if(Knight.vidas>=0){
                    Knight.vidas = Knight.vidas-25;
                    Knight.isHurt = true;
                    tiempoSiguienteDaño=tiempoEntreDaño;   
                    anim.SetBool("FishAttack", true);  
                }
            }     
        }  
    }

    private void NoPerseguir()
    {
        rb2d.velocity = Vector2.zero;
        anim.SetBool("FishAttack", false);
    }

    private void PerseguirJugador()
    {
         anim.SetBool("FishAttack", true);
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
