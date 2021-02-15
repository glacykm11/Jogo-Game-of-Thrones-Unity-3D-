using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    public Rigidbody rb;
    Vector3 movement;
    public float moveSpeed = 5f;
    public Animator anim;
  
    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float zAxis = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(xAxis , 0 ,zAxis) * moveSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);

        if(xAxis != 0 || zAxis != 0)
        {
            anim.SetBool("Run",true);  
        }else{
            anim.SetBool("Run",false);  
        }

        if (xAxis==1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,90,0), Time.deltaTime*5);
        }
        if (xAxis== -1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,-90,0), Time.deltaTime*5);        
        }
        if (zAxis == 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0,0), Time.deltaTime*5);
        }
        if (xAxis == -1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,-180,0), Time.deltaTime*5);
        }
    }
}
