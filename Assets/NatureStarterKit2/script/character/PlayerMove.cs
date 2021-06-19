using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
    x = Input.GetAxis("Horizontal");
    y = Input.GetAxis("Vertical");

    transform.Rotate(0,x * Time.deltaTime * rotationSpeed, 0);

    transform.Translate(0, 0, y * Time.deltaTime * runSpeed);
    
    animator.SetFloat("VectorX", x);
    animator.SetFloat("VectorY", y);

    if(Input.GetKey("q")){
        animator.SetBool("Tecla",false);
        animator.Play("modopelea");
    }

    if(x>0 || x<0 || y>0 || y<0){
        animator.SetBool("Tecla",true);
    }

    isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);

    if(Input.GetKey("space") && isGrounded){
        animator.Play("saltar"); 
        Invoke("jump",1);
    }

    }

    public void jump(){
        Rb.AddForce(Vector3.up*jumpHeight,ForceMode.Impulse);
    }
}
