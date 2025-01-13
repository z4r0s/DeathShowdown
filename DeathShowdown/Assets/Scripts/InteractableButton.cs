using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableButton : MonoBehaviour
{

    public bool isInRange = false;
    public UnityEvent interactAction;


    void Start()
    {
    
    }

    void Update()
    {

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Anubis" || other.gameObject.tag == "Death" || other.gameObject.tag == "Hela" || other.gameObject.tag == "Hades" || other.gameObject.tag == "Player")
        {
            isInRange = true;
            Debug.Log ("In range");
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "Anubis" || other.gameObject.tag == "Death" || other.gameObject.tag == "Hela" || other.gameObject.tag == "Hades" || other.gameObject.tag == "Player")
        {
            isInRange = false;
            Debug.Log ("Out of range");
        }
    }

    public void MoveWalls()
    {
        if (isInRange)
        {
            interactAction.Invoke();
        }
    }
}
