using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSpawner : MonoBehaviour
{
    public float spawnRate = 1f;
    public float warningTime = 2f;
    public GameObject lightningDestroyObj;
    public GameObject lightningWarningObj;
    [SerializeField] public GameObject[] lightningSpawnPlaces;
    private string userHolder;


    void Start()
    {
        for (int i = 0; i <= lightningSpawnPlaces.Length - 1; i++)
        {
            lightningSpawnPlaces[i] = GameObject.Find("LightningSpawner (" + i + ")");
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Anubis" || other.gameObject.tag == "Hades" || other.gameObject.tag == "Hela")
        {
            AudioManager.Instance.PlaySFX(5);
            userHolder = other.gameObject.tag;
            StartCoroutine(SpawnLightnings());
            this.gameObject.transform.position = new Vector3(0, 40, 0);
            Spawner.canSpawn = true;
        }
    }

    private IEnumerator SpawnLightnings()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        WaitForSeconds hold = new WaitForSeconds(warningTime);

        for (int maxSpawns = 0; maxSpawns <= 6; maxSpawns ++)
        {
            int rand = Random.Range(0, lightningSpawnPlaces.Length - 1);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-5, 5), 1, Random.Range(-5, 5));

            Instantiate(lightningWarningObj, lightningSpawnPlaces[rand].transform.position, Quaternion.identity);

            yield return hold;

            //Instantiate(lightningDestroyObj, randomSpawnPosition, Quaternion.identity);
            Instantiate(lightningDestroyObj, lightningSpawnPlaces[rand].transform.position, Quaternion.identity);
            yield return wait;
        }
        Destroy(this.gameObject);
        Spawner.canSpawn = true;
    }
}
