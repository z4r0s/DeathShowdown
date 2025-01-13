using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShhieldPowerUp : MonoBehaviour
{
    public float timer = 0f;
    public float fullTime = 30f;

    void OnEnable()
    {
        
        StartCoroutine(Countdown());
    }

    public IEnumerator Countdown()
    {
        timer = fullTime;
        yield return true;
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            
        }
    }

}
