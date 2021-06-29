using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float runSpeed =  7;
    public float rotationSpeed = 250;

    public Animator animator;

    private float x,y;

    public Rigidbody Rb;
    public float jumpHeight = 3;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    bool isGrounded;

    public float velocidaddemovimiento = 5.0f;
    public float velocidaddeRotacion = 200.0f;


    public float velocidadInicial;
    public float velocidadAgachado;


    public bool atacar;
    public bool avanzar;
    public float impulsoGolpe = 10f;

    void Start()
    {
        velocidadInicial = velocidaddemovimiento;
        velocidadAgachado = velocidaddemovimiento * 0.5f;
    }

    
    void FixedUpdate()
    {
        if(!atacar){
            transform.Rotate(0,x * Time.deltaTime * rotationSpeed, 0);

            transform.Translate(0, 0, y * Time.deltaTime * runSpeed);
        } 
        if(avanzar)
        {
            Rb.velocity = transform.forward * impulsoGolpe;   
        }
    }

    // Update is called once per frame
    void Update()
    {
    x = Input.GetAxis("Horizontal");
    y = Input.GetAxis("Vertical");

    
    animator.SetFloat("VectorX",x);
    animator.SetFloat("VectorY",y);

     if(Input.GetMouseButtonDown(0) && !atacar){
                    animator.SetTrigger("Golpear");
                    atacar = true;
    }

    if(!atacar){
        if(Input.GetKey("q")){
                animator.SetBool("Tecla",false);
                animator.Play("pelear");
            }
 
            if(Input.GetKey(KeyCode.LeftControl)){
                    animator.SetBool("Agachar",true);
                    velocidaddemovimiento = velocidadAgachado;
            }else{
                animator.SetBool("Agachar",false);
                    velocidaddemovimiento = velocidadInicial;
            }
        
            
    }
 
    isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);

    if(Input.GetKey("space") && isGrounded){
        animator.Play("jsaltar"); 
       
        Invoke("jump",1);
    }

    if(atacar)
    {
        atacar = false; 
    }

    if(x>0 || x<0 || y>0 || y<0){
                animator.SetBool("Tecla",true);
   }

    }

  public void jump(){
        Rb.AddForce(Vector3.up*jumpHeight,ForceMode.Impulse);
    }

    public void DejardeGolpear(){
        atacar = false;
        avanzar = false;
    }

    public void avanzarSolo(){
        avanzar = true;
    }

    public void dejodeAvanzar(){
        avanzar = false;
    }
}
