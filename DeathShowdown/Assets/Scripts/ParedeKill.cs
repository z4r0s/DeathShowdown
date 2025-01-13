using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedeKill : MonoBehaviour
{
    public static GameObject Player;
    public  GameObject hit_attack;
    public GameController gc;
    private void Start()
    {
        gc = GameController.instance;
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("colidiu");
        Instantiate(hit_attack, other.transform.position, other.transform.rotation);
        AudioManager.Instance.PlaySFX(6);
        if (Player.gameObject.tag == "Player")
        {
            if (other.gameObject.tag == "Anubis" || other.gameObject.tag == "Hades" || other.gameObject.tag == "Hela")
            {
                Destroy(other.gameObject);
                gc.deathPoints++;
            }
            else if (other.gameObject.tag == "Player")
            {
                Destroy(other.gameObject);
                gc.deathPoints--;
                if (gc.deathPoints <= 0)
                {
                    gc.deathPoints = 0;
                }
            }
        }
        else if (Player.gameObject.tag == "Anubis")
        {
            if (other.gameObject.tag == "Player" || other.gameObject.tag == "Hades" || other.gameObject.tag == "Hela")
            {
                Destroy(other.gameObject);
                gc.anubisPoints++;
            }
            else if (other.gameObject.tag == "Anubis")
            {
                Destroy(other.gameObject);
                gc.anubisPoints--;
                if (gc.anubisPoints <= 0)
                {
                    gc.anubisPoints = 0;
                }
            }
        }
        else if (Player.gameObject.tag == "Hades")
        {
            if (other.gameObject.tag == "Player" || other.gameObject.tag == "Anubis" || other.gameObject.tag == "Hela")
            {
                Destroy(other.gameObject);
                gc.hadesPoints++;
            }
            else if (other.gameObject.tag == "Hades")
            {
                Destroy(other.gameObject);
                gc.hadesPoints--;
                if (gc.hadesPoints <= 0)
                {
                    gc.hadesPoints = 0;
                }
            }
        }
        else if (Player.gameObject.tag == "Hela")
        {
            if (other.gameObject.tag == "Player" || other.gameObject.tag == "Anubis" || other.gameObject.tag == "Hades")
            {
                Destroy(other.gameObject);
                gc.helaPoints++;
            }
            else if (other.gameObject.tag == "Hela")
            {
                Destroy(other.gameObject);
                gc.helaPoints--;
                if (gc.helaPoints <= 0)
                {
                    gc.helaPoints = 0;
                }
            }
        }
    }
}