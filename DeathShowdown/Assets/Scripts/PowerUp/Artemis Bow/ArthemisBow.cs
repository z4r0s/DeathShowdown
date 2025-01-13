using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArthemisBow : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioManager.Instance.PlaySFX(5);
            DeathRanged.instance.attackCooldown = 1.0f;
            Destroy(this.gameObject);
            Spawner.canSpawn = true;
        }
        else if (other.gameObject.tag == "Hades")
        {
            AudioManager.Instance.PlaySFX(5);
            HadesRanged.instance.attackCooldown = 1.0f;
            Destroy(this.gameObject);
            Spawner.canSpawn = true;
        }
        else if (other.gameObject.tag == "Anubis")
        {
            AudioManager.Instance.PlaySFX(5);
            AnubisController.instance.attackCooldown = 1.0f;
            Destroy(this.gameObject);
            Spawner.canSpawn = true;
        }
        else if (other.gameObject.tag == "Hela")
        {
            AudioManager.Instance.PlaySFX(5);
            HelaController.instance.attackCooldown = 1.0f;
            Destroy(this.gameObject);
            Spawner.canSpawn = true;
        }
    }

}
