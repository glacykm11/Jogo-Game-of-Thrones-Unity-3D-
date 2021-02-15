using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject winWindow;
    

    void OnTriggerEnter (Collider col)
    {
        winWindow.SetActive(true); // ativando janela
        Time.timeScale = 0;
    }

   
}
