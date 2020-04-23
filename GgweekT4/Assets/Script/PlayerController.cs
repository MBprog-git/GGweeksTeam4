using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;


    bool Avant;
    bool Reculer;
    bool Droite;
    bool Gauche;
 


   public  float speed;

    public bool CanMove = true;
  
    public bool _Grounded;
    float Gravity;
    float SpeedFall;
    float SpeedFallMax;

    public bool IsJumping;
    float SpeedJump;
    float SpeedJumpMin;
     float TimeJump;
      public  float Timer;
    public bool CanJump;

    public Transform Respawn;
     

    // Start is called before the first frame update
    void Start()
    {
        speed = GameManager.instance.speed/2;
        Gravity = GameManager.instance.Gravity;
        SpeedFallMax = GameManager.instance.FallSpeedMax;
   SpeedJump= GameManager.instance.SpeedJump;
   TimeJump=GameManager.instance.TimeJump ;
        SpeedJumpMin = GameManager.instance.SpeedJumpMin;

            rb = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        //Move Velocity
        if (CanMove)
        {
            if (Avant)
            {
                transform.position += transform.forward * Time.deltaTime * speed;

            }
            if (Reculer)
            {
                transform.position -= transform.forward * Time.deltaTime * speed;

            }
            if (Droite)
            {
                transform.position += transform.right * Time.deltaTime * speed;

            }
            if (Gauche)
            {

                transform.position -= transform.right * Time.deltaTime * speed;
            }

            if (IsJumping)
            {
                rb.velocity = new Vector3(rb.velocity.x, SpeedJump * Time.deltaTime, rb.velocity.z);
                _Grounded = false;
            }



            Gravitation(Time.fixedDeltaTime);

        }
    }

    // Update is called once per frame
    void Update()
    {
        //Inputs Move


       

            if (Input.GetKey(KeyCode.Z))
            {
                Avant = true;
            }
            else
            {
                Avant = false;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                Gauche = true;
            }
            else
            {
                Gauche = false;
            }
            if (Input.GetKey(KeyCode.S))
            {
                Reculer = true;
            }
            else
            {
                Reculer = false;
            }
            if (Input.GetKey(KeyCode.D))
            {
                Droite = true;
            }
            else
            {
                Droite = false;
            }

        if (Input.GetKey(KeyCode.Space) && Timer > 0 && CanJump)
        {
            IsJumping = true;
            Timer -= Time.fixedDeltaTime;


        }
        else
        {
            
            IsJumping = false;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Timer = 0;
            IsJumping = false;
        }


    }

    private void Gravitation(float DeltaTime)
    {
        if (_Grounded)
        {
            SpeedFall = 0;
        }
        else if (IsJumping)
        {
            SpeedJump -= Gravity * DeltaTime;
            if (SpeedJump < SpeedJumpMin)
            {
                SpeedJump = SpeedJumpMin;
            }
        }
        else{
            SpeedFall -= Gravity * DeltaTime;
            if (SpeedFall < -SpeedFallMax)
            {
                SpeedFall = -SpeedFallMax;
            
            }
            rb.velocity = new Vector3(rb.velocity.x, SpeedFall, rb.velocity.z);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Respawn")
        {
            transform.position = Respawn.transform.position;
        }
        if(collision.gameObject.tag == "Ground")
        {
            Timer = TimeJump;
            SpeedFall = 0;
           _Grounded = true;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _Grounded = false;
            
        }
        
    }


}

      

