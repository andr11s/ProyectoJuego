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

    void Start()
    {
        velocidadInicial = velocidaddemovimiento;
        velocidadAgachado = velocidaddemovimiento * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
    x = Input.GetAxis("Horizontal");
    y = Input.GetAxis("Vertical");

    transform.Rotate(0,x * Time.deltaTime * rotationSpeed, 0);

    transform.Translate(0, 0, y * Time.deltaTime * runSpeed);
    
    animator.SetFloat("VectorX",x);
    animator.SetFloat("VectorY",y);

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
 
    if(x>0 || x<0 || y>0 || y<0){
        animator.SetBool("Tecla",true);
    }

    isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);

    if(Input.GetKey("space") && isGrounded){
        animator.Play("jsaltar"); 
        Invoke("jump",1);
    }


    }

  public void jump(){
        Rb.AddForce(Vector3.up*jumpHeight,ForceMode.Impulse);
    }

    
}
