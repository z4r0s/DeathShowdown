using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlow : MonoBehaviour
{
    public GameObject[] spawn;
    public GameObject slow;
    bool canSpawn = true;
    public static bool[] SpawnerOn = new bool[15];
    public static SpawnSlow instance;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < 15; i++)
        {
            SpawnerOn[i] = true;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn == true)
        {
            StartCoroutine(SlowSpawn());
        }
    }

    public IEnumerator SlowSpawn()
    {
        canSpawn = false;
        int rand = Random.Range(0, spawn.Length - 1);
        if(SpawnerOn[rand] == true)
        {
            Instantiate(slow, spawn[rand].transform.position, Quaternion.identity);
            StopMove.id = rand;
            SpawnerOn[rand] = false;
        } 
        yield return new WaitForSeconds(5f);
        canSpawn = true;
    }

    public static void Habilitar(string name)
    {
        for (int i = 0; i < 15; i++) {
            if (i.ToString() == name)
            {
                SpawnerOn[i] = true ;
            } 
        }
    }
}
