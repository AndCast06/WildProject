using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knight : MonoBehaviour
{
    private AudioSource SoundGameOver;
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject Mag1;
    [SerializeField] private GameObject Mag2;
    [SerializeField] private GameObject Mag3;
    public Text Money;
    public static int TotalMoney;
    public float fuerzaSalto;
    public float velocidad;
    public static Rigidbody2D rigidbody2D;
    public static bool isGrounded;
    private bool isLive=true;
    public static bool isHurt=false;
    public static bool magic1Collect;
    public static bool magic2Collect;
    public static bool magic3Collect;
    public static Animator animator;
    public static int vidas=100;
    public static int CMagics1=5;
    public static int CMagics2=5;
    public static int CMagics3=5;
    [SerializeField] Slider sliderVidas;
    [SerializeField] Slider sliderMagic1;
    [SerializeField] Slider sliderMagic2;
    [SerializeField] Slider sliderMagic3;
    public GameObject gameOverPanel;
    private CapsuleCollider2D Capsulecollider;
    void Start()
    {
        SoundGameOver = GetComponent<AudioSource>();
  
        sliderMagic3.value = sliderMagic3.maxValue;
  
        sliderMagic2.value = sliderMagic2.maxValue;
 
        sliderMagic1.value = sliderMagic1.maxValue;

        sliderVidas.value = sliderVidas.maxValue;
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        Capsulecollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {       
        Money.text = TotalMoney.ToString();
        sliderVidas.value = vidas;
        sliderMagic1.value = CMagics1;
        sliderMagic2.value = CMagics2;
        sliderMagic3.value = CMagics3;
        if(Input.GetButtonDown("Jump") && isGrounded){
                animator.SetBool("estaSaltando",true);
                animator.SetBool("estaCaminando",false);          
                isGrounded=false;
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, fuerzaSalto);
        }
        else if(Input.GetKey("d") || Input.GetKey("right")){
            if(isLive){
                animator.SetBool("estaAtacandoMagic",false);
                animator.SetBool("estaAtacandoEspada",false);
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                if(isGrounded){
                    animator.SetBool("estaCaminando",true);
                    animator.SetBool("estaSaltando",false); 
                                
                }         
                rigidbody2D.velocity = new Vector2(velocidad, rigidbody2D.velocity.y);
            }
        }
        else if(Input.GetKey("a") || Input.GetKey("left")){
            if(isLive){
                animator.SetBool("estaAtacandoMagic",false);
                animator.SetBool("estaAtacandoEspada",false);
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);           
                if(isGrounded){
                    animator.SetBool("estaCaminando",true);
                    animator.SetBool("estaSaltando",false);           
                }
                rigidbody2D.velocity = new Vector2(-velocidad, rigidbody2D.velocity.y);
            }
        }
        else if(Input.GetButtonDown("Slash")){
            if(isGrounded){ 
                animator.SetBool("estaAtacandoEspada",true);
                animator.SetBool("estaAtacandoMagic",false);
                animator.SetBool("estaCaminando",false);
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            }       
        }     
        else if(Input.GetButtonDown("Fire1")){
            if(magic1Collect){ 
                if(isGrounded){
                    if(CMagics1>=1){
                        Shoot1Magic();
                        CMagics1-=1;
                        animator.SetBool("estaAtacandoEspada",false);
                        animator.SetBool("estaCaminando",false);
                        animator.SetBool("estaAtacandoMagic",true);
                        rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
                    }
                }  
            }             
        } 
         else if(Input.GetButtonDown("Fire2")){
            if(magic2Collect){ 
                if(isGrounded){
                    if(CMagics2>=1){
                        Shoot2Magic();
                        CMagics2-=1;
                        animator.SetBool("estaAtacandoEspada",false);
                        animator.SetBool("estaCaminando",false);
                        animator.SetBool("estaAtacandoMagic",true);
                        rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
                    }
                }    
            }           
        } 
         else if(Input.GetButtonDown("Fire3")){
            if(magic3Collect){ 
                if(isGrounded){
                    if(CMagics3>=1){
                        Shoot3Magic();
                        CMagics3-=1;
                        animator.SetBool("estaAtacandoEspada",false);
                        animator.SetBool("estaCaminando",false);
                        animator.SetBool("estaAtacandoMagic",true);
                        rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
                    }
                }  
            }             
        } 
        else{
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            animator.SetBool("estaCaminando",false);
            animator.SetBool("estaAtacandoMagic",false);
            animator.SetBool("estaAtacandoEspada",false);
        }

        if(vidas<=0){
            animator.SetBool("estMuerto", true);  
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, fuerzaSalto-6);
            isLive=false;   
            Capsulecollider.enabled=false;
            Invoke("ActiveGameOver",3f);
        }

        if(vidas>=100){
            animator.SetBool("estMuerto", false);  
            vidas=100;       
        }
        
        if(isHurt){
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x-5, fuerzaSalto-3);
            isHurt=false;
        }


    }

    public void ActiveGameOver(){
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        SoundGameOver.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision){ 
        if(collision.gameObject.tag=="Ground")
        {
            animator.SetBool("estaSaltando", false);  
            isGrounded=true;          
        } 
        else if(collision.gameObject.tag=="Column"){
            animator.SetBool("estaSaltando", false);
            isGrounded=true;    
        }   
        else if(collision.gameObject.tag=="Golem1G"){
            animator.SetBool("estaSaltando", false);
            isGrounded=true;    
        } 
        else if(collision.gameObject.tag=="Ghost1"){
            animator.SetBool("estaSaltando", false);
            isGrounded=true;    
        } 
        else if(collision.gameObject.tag=="Barrel"){
            animator.SetBool("estaSaltando", false);
            isGrounded=true;    
        } 
    }

    private void Shoot1Magic(){
        if(transform.localScale.x == 1.0f){
            Magic1.direction = Vector2.right;
            Mag1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);   
        } 
        else{
            Magic1.direction = Vector2.left;
            Mag1.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);      
        }
        Instantiate(Mag1, controladorDisparo.position, controladorDisparo.transform.rotation);
    }  
    
    private void Shoot2Magic(){  
        if(transform.localScale.x == 1.0f){
            Magic2.direction = Vector2.right;
            Mag2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);   
        } 
        else{
            Magic2.direction = Vector2.left;
            Mag2.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);      
        }
        Instantiate(Mag2, controladorDisparo.position, controladorDisparo.transform.rotation);
    }  

    private void Shoot3Magic(){
        if(transform.localScale.x == 1.0f){
            Magic3.direction = Vector2.right;
            Mag3.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);   
        } 
        else{
            Magic3.direction = Vector2.left;
            Mag3.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);      
        }
        Instantiate(Mag3, controladorDisparo.position, controladorDisparo.transform.rotation);
    }  
}

