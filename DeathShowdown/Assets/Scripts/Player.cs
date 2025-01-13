using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    

    public void Start()
    {
        instance = this;
    }
    void Update()
    {
        
    }
    
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Parede1")
        {
            Debug.Log("Encostou P1");
            if (other.gameObject.tag == "Parede2")
            {
                Debug.Log("Encostou 2");
                Destroy(this.gameObject);
            }
        }
    }

    
}
