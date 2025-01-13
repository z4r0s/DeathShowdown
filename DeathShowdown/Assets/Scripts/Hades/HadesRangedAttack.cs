using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HadesRangedAttack : MonoBehaviour
{
    public GameObject skullHead;
    public GameObject skullBody;
    public GameObject skullHands;
    public GameObject skullHands2;

    public GameObject deathEffect;

    void Awake()
    {
        Destroy(this.gameObject, 2f);
        AudioManager.Instance.PlaySFX(8);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Unbreakable" || other.gameObject.tag != "Hades")
        {
            if (other.gameObject.tag == "Player" && GameController.instance.deathShielded != true || other.gameObject.tag == "Anubis" && GameController.instance.anubisShielded != true || other.gameObject.tag == "Hela" && GameController.instance.helaShielded != true)
            {
                Instantiate(deathEffect, other.transform.position, other.transform.rotation);
                Instantiate(skullBody, other.transform.position, other.transform.rotation);
                Instantiate(skullHead, other.transform.position, other.transform.rotation);
                Instantiate(skullHands, other.transform.position, other.transform.rotation);
                Instantiate(skullHands2, other.transform.position, other.transform.rotation);
                
                Destroy(other.gameObject);
                GameController.instance.points++;
                GameController.instance.hadesPoints++;
                Destroy(this.gameObject);
            }
        }

        if (other.gameObject.tag == "Unbreakable" || other.gameObject.tag == "Hades")
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
        if (other.gameObject.tag == "Hela" && GameController.instance.helaShielded == true)
        {
            GameController.instance.ChangeHelaBool(false);
            if (other.gameObject.transform.GetChild(10).gameObject.activeSelf)
            {
                other.gameObject.transform.GetChild(10).gameObject.SetActive(false);
            }
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Player" && GameController.instance.hadesShielded == true)
        {
            GameController.instance.ChangeDeathBool(false);
            if (other.gameObject.transform.GetChild(10).gameObject.activeSelf)
            {
                other.gameObject.transform.GetChild(10).gameObject.SetActive(false);
            }
            Destroy(this.gameObject);
        }
    }
}