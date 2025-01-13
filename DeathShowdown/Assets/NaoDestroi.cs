using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaoDestroi : MonoBehaviour
{
    public static NaoDestroi instance;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (!instance) { instance = this; }
        else { Destroy(gameObject); }
    }
}
