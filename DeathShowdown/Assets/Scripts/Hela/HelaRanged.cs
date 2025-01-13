using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelaRanged : MonoBehaviour
{
    public GameObject skullHead;
    public GameObject skullBody;
    public GameObject skullHands;
    public GameObject skullHands2;

    public GameObject deathEffect;

    void Awake()
    {
        Destroy(this.gameObject, 2f);
        AudioManager.Instance.PlaySFX(4);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Unbreakable"|| other.gameObject.tag != "Hela" )
        {
            if (other.gameObject.tag == "Player" && GameController.instance.deathShielded != true || other.gameObject.tag == "Anubis" && GameController.instance.anubisShielded != true || other.gameObject.tag == "Hades" && GameController.instance.hadesShielded != true )
            {
                Instantiate(deathEffect, other.transform.position, other.transform.rotation);
                Instantiate(skullBody, other.transform.position, other.transform.rotation);
                Instantiate(skullHead, other.transform.position, other.transform.rotation);
                Instantiate(skullHands, other.transform.position, other.transform.rotation);
                Instantiate(skullHands2, other.transform.position, other.transform.rotation);
                
                Destroy(other.gameObject);
                GameController.instance.points++;
                GameController.instance.helaPoints++;
                Destroy(this.gameObject);
            }
        }

        if (other.gameObject.tag == "Unbreakable")
        {
            Destroy(this.gameObject);
        }
        


        if (other.gameObject.tag == "Anubis" && GameController.instance.anubisShielded == true)
        {
            GameController.instance.ChangeAnubisBool(false);
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Player" && GameController.instance.deathShielded == true)
        {
            GameController.instance.ChangeDeathBool(false);
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Hades" && GameController.instance.hadesShielded == true)
        {
            GameController.instance.ChangeHadesBool(false);
            Destroy(this.gameObject);
        }
    }
}