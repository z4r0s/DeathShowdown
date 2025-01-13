using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubisRanged : MonoBehaviour
{
    public GameObject bigExplosion;

    void Awake()
    {
        AudioManager.Instance.PlaySFX(7);
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Anubis")
        {
            Debug.Log("Collided Small");
            BigExplosion();
            Destroy(this.gameObject);
        }
    }

    public void BigExplosion()
    {
        Instantiate(bigExplosion, this.transform.position, this.transform.rotation);

    }
}
