using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotionPowerUp : MonoBehaviour
{
    public float slowMotionFactor = 0.5f;  
    public float slowMotionDuration = 5f;  

    private bool isSlowMotionActive = false;
    private float originalTimeScale;

    void Start()
    {
        originalTimeScale = Time.timeScale;
        if (!isSlowMotionActive)
        {
            StartCoroutine(ActivateSlowMotion());
        }
    }

    IEnumerator ActivateSlowMotion()
    {
        isSlowMotionActive = true;
        Time.timeScale = slowMotionFactor; 
        Time.fixedDeltaTime = Time.timeScale * 0.02f;  
        yield return new WaitForSecondsRealtime(slowMotionDuration);  

        Time.timeScale = originalTimeScale;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;  
        isSlowMotionActive = false;
        Spawner.canSpawn = true;
        Destroy(this.gameObject);
    }
}
