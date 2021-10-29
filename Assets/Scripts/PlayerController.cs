using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Life = 100;
    public float Speed;
    public Animator anim;

    float InputX;
    float InputZ;
    Vector3 Direction;
    public Camera MainCamera;

    void Awake()
    {
        transform.tag = "Player"; 
    }

    void Update()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");
        Direction = new Vector3(InputX, 0, InputZ);
        if(InputX != 0 || InputZ != 0)
        {
            var camrot = MainCamera.transform.rotation;
            camrot.x = 0;
            camrot.z = 0;
            transform.Translate(0,0,Speed * Time.deltaTime);
            anim.SetBool("Run", true);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Direction) *camrot, 5 * Time.deltaTime);
        }
        if(InputX == 0 && InputZ == 0)
        {
            anim.SetBool("Run", false);
        }
        if(Life <= 0)
        {
            Life = 0;
            Death();
        }
    }
    void Death()
    {
        anim.SetBool("Death", true);
    }

}
