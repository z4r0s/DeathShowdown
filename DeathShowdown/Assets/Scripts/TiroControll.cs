using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroControll : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(this.gameObject, 0.5f);
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        
                if (other.gameObject.tag != "Unbreakable")
                {
                    Destroy(other.gameObject);
                    Destroy(this.gameObject);
                    if (other.gameObject.tag == "Player" || other.gameObject.tag == "Anubis")
                    {
                        GameController.instance.points++;
                    }
                }
     
    }
}
