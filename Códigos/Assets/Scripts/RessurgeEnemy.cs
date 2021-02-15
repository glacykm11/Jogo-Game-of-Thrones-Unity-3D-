using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessurgeEnemy : MonoBehaviour
{
    public GameObject enemy;
   
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            enemy.SetActive(true);
           // this.gameObject.SetActive(false);
        }
    }
}