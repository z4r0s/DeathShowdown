using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotionSpawner : MonoBehaviour
{
    public GameObject slowMotion;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Anubis" || other.gameObject.tag == "Hades" || other.gameObject.tag == "Hela")
        {
            AudioManager.Instance.PlaySFX(5);
            Instantiate(slowMotion);
            Destroy(this.gameObject);
        }
    }
}
