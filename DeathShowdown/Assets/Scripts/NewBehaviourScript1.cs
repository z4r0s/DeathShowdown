using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
     void Awake()
    {
        Destroy(this.gameObject, 0.05f);
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Unbreakable")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            if (other.gameObject.tag == "Player")
            {
                GameController.instance.points++;
            }
        }
    }
}
