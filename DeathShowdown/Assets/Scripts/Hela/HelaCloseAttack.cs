using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelaCloseAttack : MonoBehaviour
{
    public GameObject skullHead;
    public GameObject skullBody;
    public GameObject skullHands;
    public GameObject skullHands2;

    public GameObject deathEffect;
    
    void Awake()
    {
        AudioManager.Instance.PlaySFX(0);
        Destroy(this.gameObject, 0.05f);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Unbreakable"|| other.gameObject.tag != "Hela")
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
            }
        }
        if (other.gameObject.tag == "Unbreakable"|| other.gameObject.tag == "Hela") 
        {
            Destroy(this.gameObject);
        }


        if (other.gameObject.tag == "Anubis" && GameController.instance.anubisShielded == true)
        {
            GameController.instance.ChangeAnubisBool(false);
            if (other.gameObject.transform.GetChild(10).gameObject.activeSelf)
            {
                other.gameObject.transform.GetChild(10).gameObject.SetActive(false);
            }
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Player" && GameController.instance.deathShielded == true)
        {
            GameController.instance.ChangeDeathBool(false);
            if (other.gameObject.transform.GetChild(10).gameObject.activeSelf)
            {
                other.gameObject.transform.GetChild(10).gameObject.SetActive(false);
            }
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Hades" && GameController.instance.hadesShielded == true)
        {
            GameController.instance.ChangeHadesBool(false);
            if (other.gameObject.transform.GetChild(10).gameObject.activeSelf)
            {
                other.gameObject.transform.GetChild(10).gameObject.SetActive(false);
            }
            Destroy(this.gameObject);
        }
    }
}
