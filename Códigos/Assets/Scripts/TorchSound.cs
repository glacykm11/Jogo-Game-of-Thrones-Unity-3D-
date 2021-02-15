using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchSound : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Renderer>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            Destroy(gameObject, 3);
        }
    }
}
