using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruct : MonoBehaviour
{
    public GameObject destroyVersion;
    public GameObject icewall;

    void OnMouseDown()
    { 
        Instantiate(destroyVersion, transform.position, transform.rotation);
        Destroy(gameObject, 1);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            icewall.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
    
    
}
