using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubisExplosion : MonoBehaviour
{
    public ParticleSystem ps;
    public GameObject deathEffect;

    public GameObject skullHead;
    public GameObject skullBody;
    public GameObject skullHands;
    public GameObject skullHands2;
    

    public void Awake()
    {
        Destroy(this.gameObject, 1f);
        AudioManager.Instance.PlaySFX(3);
        ps.Play(true);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Unbreakable"|| other.gameObject.tag != "Anubis")
        {
            if (other.gameObject.tag == "Player" && GameController.instance.deathShielded != true || other.gameObject.tag == "Hela" && GameController.instance.helaShielded != true || other.gameObject.tag == "Hades" && GameController.instance.hadesShielded != true)
            {
                Instantiate(deathEffect, other.transform.position, other.transform.rotation);
                Instantiate(skullBody, other.transform.position, other.transform.rotation);
                Instantiate(skullHead, other.transform.position, other.transform.rotation);
                Instantiate(skullHands, other.transform.position, other.transform.rotation);
                Instantiate(skullHands2, other.transform.position, other.transform.rotation);

                Destroy(other.gameObject);
                //Destroy(this.gameObject);
                GameController.instance.points++;
                GameController.instance.anubisPoints++;
            }
        }

        if (other.gameObject.tag == "Unbreakable" || other.gameObject.tag == "Anubis")
        {
            Destroy(this.gameObject);
        }


        if (other.gameObject.tag == "Player" && GameController.instance.deathShielded == true)
        {
            GameController.instance.deathShielded = false;
            if (other.gameObject.transform.GetChild(10).gameObject.activeSelf)
            {
                other.gameObject.transform.GetChild(10).gameObject.SetActive(false);
            }
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Hela" && GameController.instance.helaShielded == true)
        {
            GameController.instance.helaShielded = false;
            if (other.gameObject.transform.GetChild(10).gameObject.activeSelf)
            {
                other.gameObject.transform.GetChild(10).gameObject.SetActive(false);
            }
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Hades" && GameController.instance.hadesShielded == true)
        {
            GameController.instance.hadesShielded = false;
            if (other.gameObject.transform.GetChild(10).gameObject.activeSelf)
            {
                other.gameObject.transform.GetChild(10).gameObject.SetActive(false);
            }
            Destroy(this.gameObject);
        }
    }
}