using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement2 : MonoBehaviour
{
    [Header("Movement Settings:")]
    public float speedRun;
    public float speedSprint;
    public float rotateSpeed;

    [Header("Animation Settings:")]
    public Animator anim;

    float speed;
    Rigidbody rb;

    float xRaw;
    float zRaw;

    float x;
    float z;

    bool tps = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = speedRun;
    }

    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            Camera.main.transform.gameObject.GetComponent<Camera>().fieldOfView = Mathf.Lerp(Camera.main.transform.gameObject.GetComponent<Camera>().fieldOfView, 40f, .1f);
        }
        else
        {
            Camera.main.transform.gameObject.GetComponent<Camera>().fieldOfView = Mathf.Lerp(Camera.main.transform.gameObject.GetComponent<Camera>().fieldOfView, 50f, .1f);
        }
    }

    private void FixedUpdate()
    {
        xRaw = Input.GetAxisRaw("Horizontal");
        zRaw = Input.GetAxisRaw("Vertical");

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        if (!Input.GetMouseButton(1))
        {
            tps = false;
            anim.SetBool("Tps", false);
        }
        else
        {
            tps = true;
            anim.SetBool("Tps", true);
            speed = 4.5f;
        }

        if (tps)
        {
            anim.SetFloat("tpsDirectionsY", z);
            anim.SetFloat("tpsDirectionsX", x);

            if (zRaw == 1)
            {
                rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * transform.forward);               
            }
            if (zRaw == -1)
            {
                rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * -transform.forward);
            }
            if (xRaw == 1)
            {
                rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * transform.right);
            }
            if (xRaw == -1)
            {
                rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * -transform.right);
            }

            float camY = Camera.main.transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, camY + transform.rotation.y, 0), Time.deltaTime * 5);
        }
        else
        {
            Movimentation();
            Animation();
            Rotation();
        }
    }

    void Movimentation()
    {
        if (xRaw != 0 || zRaw!= 0)
        {
            rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * transform.forward);

            if (Input.GetKey(KeyCode.LeftShift))
                speed = speedSprint;
            else
                speed = speedRun;
        }
    }

    void Rotation()
    {
        float camY = Camera.main.transform.rotation.eulerAngles.y;

        if (zRaw == 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, camY, 0), Time.deltaTime * 5);
        }
        if (zRaw == -1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, camY - 180, 0), Time.deltaTime * 5);
        }
        if (xRaw == 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, camY + 90, 0), Time.deltaTime * 5);
        }
        if (xRaw == -1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, camY - 90, 0), Time.deltaTime * 5);
        }
    }

    void Animation()
    {
        if (!xRaw.Equals(0) || !zRaw.Equals(0))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("sprint", true);
            }
            else
            {
                anim.SetBool("sprint", false);
                anim.SetBool("Run", true);
            }
        }
        else
        {
            anim.SetBool("Run", false);
            anim.SetBool("sprint", false);
        }
    }
}
