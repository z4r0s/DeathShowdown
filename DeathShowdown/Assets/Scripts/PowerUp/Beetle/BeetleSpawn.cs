using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleSpawn : MonoBehaviour
{
    public GameObject Beetle;
    public GameObject beetleSpawnPlace;
    public static string playerTag;

    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Anubis" || other.gameObject.tag == "Hades" || other.gameObject.tag == "Hela")
        {
            playerTag = other.gameObject.tag;
            Instantiate(Beetle, beetleSpawnPlace.transform.position, beetleSpawnPlace.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
