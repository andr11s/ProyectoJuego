using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoEnemigo : MonoBehaviour
{   
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;

    public GameObject target;
    public bool atacando;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Jjugador");
        
    }

    // Update is called once per frame
    void Update()
    {
        Comportamiento();
    }

    public void Comportamiento(){

        if(Vector3.Distance(transform.position,target.transform.position) > 5){
             ani.SetBool("run",false);
             cronometro += 1 * Time.deltaTime;
            if(cronometro >= 4){
                rutina = Random.Range(0,2);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0: 
                    ani.SetBool("Correr",false);
                    break;
                case 1: 
                    grado = Random.Range(0,360);
                    angulo = Quaternion.Euler(0,grado,0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation,angulo,0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    break; 
            }
        }else{
        if(Vector3.Distance(transform.position,target.transform.position) > 1 && !atacando){
             var lookPos  = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,rotation,2);
            ani.SetBool("Correr",false);

            ani.SetBool("run",true);
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);

            ani.SetBool("atacar",false);
        }
        else{
            ani.SetBool("Correr",false); 
            ani.SetBool("run",false);

             ani.SetBool("atacar",true);
             atacando = true; 
        }
            Invoke("finalanimacion",1);
       
            
           
        } 
    }

      public void finalanimacion(){
            ani.SetBool("atacar",false);
             atacando = false;
      }
    

}
