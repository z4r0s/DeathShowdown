using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirePathCollect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        AudioManager.Instance.PlaySFX(5);
        FirePath.Player = other.gameObject;
        other.gameObject.transform.GetChild(7).gameObject.SetActive(true);
        Destroy(this.gameObject);
        Spawner.canSpawn = true;
    }
}
