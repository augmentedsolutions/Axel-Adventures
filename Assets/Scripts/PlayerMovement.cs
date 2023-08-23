using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animation anim;

    private Rigidbody myBody;
    public float speed = 1f;
    private FixedJoystick joystick;

    void Awake()
    {
        
        anim = GetComponent<Animation>();
        myBody = GetComponent<Rigidbody>();
        joystick = GameObject.FindWithTag("Joystick").GetComponent<FixedJoystick>();
    }

  
    void Update()
    {
        
        myBody.velocity = new Vector3(joystick.Horizontal * speed,
                                        joystick.Vertical * speed,
                                     myBody.velocity.z);
        if(joystick.Horizontal != 0f || joystick.Vertical != 0)
        {
         
            anim.Play("Walk");

            transform.Translate(0, 0, Time.deltaTime * speed);
            transform.rotation = Quaternion.LookRotation(myBody.velocity,Vector3.back);

          


        }
        else
        {
            anim.Play("Idle");
        }

    }
 
}
