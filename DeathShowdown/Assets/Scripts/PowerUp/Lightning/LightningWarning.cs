using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningWarning : MonoBehaviour
{
    void Awake()
    {
        Destroy(this.gameObject, 2f);  
    }
}
