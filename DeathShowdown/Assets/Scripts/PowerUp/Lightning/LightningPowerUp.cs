using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningPowerUp : MonoBehaviour
{

    public GameObject speacialKillEffect;
    void Awake()
    {
        Destroy(this.gameObject, 1.85f);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Unbreakable")
        {
            //Destroy(this.gameObject);
            if (other.gameObject.tag == "Player" || other.gameObject.tag == "Anubis" || other.gameObject.tag == "Hades" || other.gameObject.tag == "Hela")
            {   
                Instantiate(speacialKillEffect, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);
            }
        }
    }
}
