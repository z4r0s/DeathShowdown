using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableWalls : MonoBehaviour
{


    //precisa fazer com que no final da animacao, rodar o DestroyDisable(), para que os players parem de morrer ao colidir com a parede
    public bool canDestroy = false;

    public void Animate()
    {

    }

    public void DestroyEnable()
    {
        canDestroy = true;
    }
    public void DestroyDisable()
    {
        canDestroy = false;
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (canDestroy)
        {
            if (other.gameObject.tag != "Unbreakable")
            {
                Destroy(other.gameObject);
            }
        }
        
    }
}
