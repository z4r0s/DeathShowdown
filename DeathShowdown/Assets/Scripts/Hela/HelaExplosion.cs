using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelaExplosion : MonoBehaviour
{
    public ParticleSystem ps;
    public void Awake()
    {
        ps.Play(true);
        Destroy(this.gameObject, 5f);
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Unbreakable" || other.gameObject.tag != "Hela")
        {
            if (other.gameObject.tag == "Player" || other.gameObject.tag == "Anubis" || other.gameObject.tag == "Hades")
            {
                Destroy(other.gameObject);
                GameController.instance.points++;
                GameController.instance.helaPoints++;
            }
        }
        else if (other.gameObject.tag == "Unbreakable" || other.gameObject.tag == "Hela")
        {
            Destroy(this.gameObject);
        }
    }

}
