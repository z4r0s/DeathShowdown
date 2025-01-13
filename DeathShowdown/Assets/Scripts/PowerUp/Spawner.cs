using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate;
    [SerializeField] private GameObject[] powerUps;
    [SerializeField] private bool SpawnEnable = true;
    public static bool canSpawn = false;
    public bool shieldSP = true, speedSP = true, thunderSP = true, gobletSP = true, fireSP = true, beetleSP = true, bowSP = true, hourglassSP = true;

    private void Awake()
    {
        powerUps = new GameObject[PlayerConfigManager.PowerUpsActive];
        for (int i = 0; i < powerUps.Length; i++) 
        { 
            if(PlayerConfigManager.bow == true && bowSP == true)
            {
                Debug.Log("entrou");
                powerUps[i] = GameObject.Find("ArtemisBow");
                Debug.Log(powerUps[i] + " achou");
                bowSP = false;
            }
            else if (PlayerConfigManager.beetle == true && beetleSP == true)
            {
                powerUps[i] = GameObject.Find("BeetleSpawner");
                beetleSP = false;
            }
            else if (PlayerConfigManager.goblet == true && gobletSP == true)
            {
                powerUps[i] = GameObject.Find("ControllChange");
                gobletSP = false;
            }
            else if(PlayerConfigManager.fire == true && fireSP == true)
            {
                powerUps[i] = GameObject.Find("FirePathPowerUp");
                fireSP = false;
            }
            else if (PlayerConfigManager.thunder == true && thunderSP == true)
            {
                powerUps[i] = GameObject.Find("LightningPowerUpSpawner");
                thunderSP = false;
            }
            else if (PlayerConfigManager.shield == true && shieldSP == true)
            {
                powerUps[i] = GameObject.Find("InstantiateShield");
                shieldSP = false;
            } 
            else if (PlayerConfigManager.hourglass == true && hourglassSP == true)
            {
                powerUps[i] = GameObject.Find("SlowMotionSpawner");
                hourglassSP = false;
            }
            else if (PlayerConfigManager.speed == true && speedSP == true)
            {
                powerUps[i] = GameObject.Find("speedPowerUp");
                speedSP = false;
            }
        }

        spawnRate = PlayerConfigManager.TempoPowerUp;
    }

    void Start()
    {
        StartCoroutine(PowerUpSpawner());
    }

    private void Update()
    {
        if (canSpawn == true && SpawnEnable == true)
        {
            StartCoroutine(PowerUpSpawner());
        }
    }

    private IEnumerator PowerUpSpawner()
    {
        canSpawn = false;
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        yield return wait;
        int rand = Random.Range(0, powerUps.Length);
        GameObject powerUpToSpawn = powerUps[rand];
        Instantiate(powerUpToSpawn, transform.position, Quaternion.identity);
        
    }
}
