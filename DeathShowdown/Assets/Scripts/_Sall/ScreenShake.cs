using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public bool startShake = false;
    public AnimationCurve shakeCurve;
    public  float shakeDuration = 0.5f;
    
    void Update()
    {
        if (startShake)
        {
            startShake = false;
            StartCoroutine(ShakeRoutine());
        }    
    }
    IEnumerator ShakeRoutine()
    {
        Vector3 originalPosition = transform.localPosition;
        float shakeTime = 0f;

        while (shakeTime < shakeDuration)
        {
            shakeTime += Time.deltaTime;
            float shakeStrength = shakeCurve.Evaluate(shakeTime / shakeDuration);
            transform.localPosition = originalPosition + Random.insideUnitSphere * shakeStrength;
            yield return null;
        }
        transform.localPosition = originalPosition;
    }
    public void DoShake()
    {
            startShake = true;
    }
}