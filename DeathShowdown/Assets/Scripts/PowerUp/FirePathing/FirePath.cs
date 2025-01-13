using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePath : MonoBehaviour
{
    public static GameObject Player;
    public GameObject speacialKillEffect;
    public GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Tempo());
        gc = GameController.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Player.gameObject.tag == "Player")
        {
            if (other.gameObject.tag == "Anubis" || other.gameObject.tag == "Hades" || other.gameObject.tag == "Hela")
            {
                Destroy(other.gameObject);
                gc.deathPoints++;
                Instantiate(speacialKillEffect, other.transform.position, other.transform.rotation);
            }
        } else if(Player.gameObject.tag == "Anubis")
        {
            if (other.gameObject.tag == "Player" || other.gameObject.tag == "Hades" || other.gameObject.tag == "Hela")
            {
                Destroy(other.gameObject);
                gc.anubisPoints++;
                Instantiate(speacialKillEffect, other.transform.position, other.transform.rotation);
            }
        } else if(Player.gameObject.tag == "Hades")
        {
            if (other.gameObject.tag == "Player" || other.gameObject.tag == "Anubis" || other.gameObject.tag == "Hela")
            {
                Destroy(other.gameObject);
                gc.hadesPoints++;
                Instantiate(speacialKillEffect, other.transform.position, other.transform.rotation);
            }
        }else if(Player.gameObject.tag == "Hela")
        {
            if (other.gameObject.tag == "Player" || other.gameObject.tag == "Anubis" || other.gameObject.tag == "Hades")
            {
                Destroy(other.gameObject);
                gc.helaPoints++;
                Instantiate(speacialKillEffect, other.transform.position, other.transform.rotation);
            }
        }
        
    }

    public IEnumerator Tempo()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
