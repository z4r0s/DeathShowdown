using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidKill : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Anubis") || other.gameObject.CompareTag("Death") || other.gameObject.CompareTag("Hades") || other.gameObject.CompareTag("Hela"))
        {
            Destroy(other.gameObject);
        }
    }
}
