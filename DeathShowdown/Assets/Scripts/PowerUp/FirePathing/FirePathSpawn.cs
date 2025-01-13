using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePathSpawn : MonoBehaviour
{
    public GameObject path;
    public GameObject Spawnpath;
    public int Timer = 20;
    public bool isEnable = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer > 0 && isEnable == true)
        {
            StartCoroutine(SpawnPath());
        } else if(Timer <= 0)
        {
            Spawnpath.SetActive(false);
            Timer = 20;
        }
    }

    public IEnumerator SpawnPath()
    {
        isEnable = false;
        Instantiate(path, Spawnpath.transform.position, Spawnpath.transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Timer--;
        isEnable = true;
    }
}
