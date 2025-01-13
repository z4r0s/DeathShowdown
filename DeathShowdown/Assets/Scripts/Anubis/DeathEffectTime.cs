using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffectTime : MonoBehaviour
{
    void Awake(){
        Destroy(this.gameObject, 5f);
    }
}
