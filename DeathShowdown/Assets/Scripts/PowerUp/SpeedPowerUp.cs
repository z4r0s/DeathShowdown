using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioManager.Instance.PlaySFX(5);
            DeathMovement.instance.speed = DeathMovement.instance.speed + 0.5f;
            Destroy(this.gameObject);
            Spawner.canSpawn = true;
        } else if(other.gameObject.tag == "Anubis")
        {
            AudioManager.Instance.PlaySFX(5);
            AnubisMovement.instance.speed = AnubisMovement.instance.speed + 0.5f;
            Destroy(this.gameObject);
            Spawner.canSpawn = true;

        } else if(other.gameObject.tag == "Hela" )
        {
            AudioManager.Instance.PlaySFX(5);
            HelaMovement.instance.speed = HelaMovement.instance.speed + 0.5f;
            Destroy(this.gameObject);
            Spawner.canSpawn = true;
            
        } else if(other.gameObject.tag == "Hades")
        {
            AudioManager.Instance.PlaySFX(5);
            HadesMovement.instance.speed = HadesMovement.instance.speed + 0.5f;
            Destroy(this.gameObject);
            Spawner.canSpawn = true;
            
        }
    }

}
