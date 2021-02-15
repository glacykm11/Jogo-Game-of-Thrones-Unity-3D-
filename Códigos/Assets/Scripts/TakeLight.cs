using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeLight : MonoBehaviour
{
    public GameObject torch;
   
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            torch.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
