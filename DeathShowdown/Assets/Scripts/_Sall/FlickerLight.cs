using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    [Tooltip("External light to flicker; you can leave this null if you attach script to a light")]
    public new Light light;
    [Tooltip("Minimum random light intensity")]
    public float minIntensity = 0f;
    [Tooltip("Maximum random light intensity")]
    public float maxIntensity = 1f;
    [Tooltip("How much to smooth out the randomness; lower values = sparks, higher = lantern")]
    [Range(1, 50)]
    public int smoothing = 5;

    Queue<float> smoothQueue;
    float lastSum = 0;

    // Reset the smoothQueue and lastSum variables
    public void Reset()
    {
        smoothQueue.Clear();
        lastSum = 0;
    }

    void Start()
    {
        // Initialize the smoothQueue with specified capacity
        smoothQueue = new Queue<float>(smoothing);

        if (light == null)
        {
            // If no external light is provided, get the Light component attached to this script's GameObject
            light = GetComponent<Light>();
        }
    }

    void Update()
    {
        if (light == null)
            return;

        // Keep the smoothQueue size within the specified smoothing range by removing the oldest value if necessary
        while (smoothQueue.Count >= smoothing)
        {
            lastSum -= smoothQueue.Dequeue();
        }

        // Generate a new random intensity value
        float newVal = Random.Range(minIntensity, maxIntensity);

        // Add the new value to the smoothQueue and update the lastSum
        smoothQueue.Enqueue(newVal);
        lastSum += newVal;

        // Calculate the average intensity and assign it to the light component
        light.intensity = lastSum / (float)smoothQueue.Count;
    }
}