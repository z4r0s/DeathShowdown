using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldInstantiate : MonoBehaviour
{
    public GameObject shieldPowerUp;

    void Awake()
    {
        GameController.instance.ChangeDeathBool(false);
        GameController.instance.ChangeAnubisBool(false);
        GameController.instance.ChangeHadesBool(false);
        GameController.instance.ChangeHelaBool(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Anubis" || other.gameObject.tag == "Hades" || other.gameObject.tag == "Hela")
        {
            AudioManager.Instance.PlaySFX(5);

            other.gameObject.transform.GetChild(10).gameObject.SetActive(true);


            if (other.gameObject.tag == "Player")
            {
                GameController.instance.ChangeDeathBool(true);
            }
            if (other.gameObject.tag == "Anubis")
            {
                GameController.instance.ChangeAnubisBool(true);
            }
            if (other.gameObject.tag == "Hades")
            {
                GameController.instance.ChangeHadesBool(true);
            }
            if (other.gameObject.tag == "Hela")
            {
                GameController.instance.ChangeHelaBool(true);
            }

            Destroy(this.gameObject);
            Spawner.canSpawn = true;
        }
    }
}
