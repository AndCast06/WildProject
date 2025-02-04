using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject jugador;
    public Vector2 minimo;
    public Vector2 maximo;
    public float suavizado;
    Vector2 velocity;

    void FixedUpdate()
    {
        if (jugador != null){
            float posX = Mathf.SmoothDamp(transform.position.x, jugador.transform.position.x, ref velocity.x, suavizado);
            float posY = Mathf.SmoothDamp(transform.position.y, jugador.transform.position.y, ref velocity.y, suavizado);   
            transform.position = new Vector3(Mathf.Clamp(posX,minimo.x,maximo.x),Mathf.Clamp(posY,minimo.y,maximo.y), transform.position.z);
        }
     
  
        
    }
}
