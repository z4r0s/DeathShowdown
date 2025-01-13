using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetlePowerUp : MonoBehaviour
{
    public GameObject Death;
    public GameObject Hades;
    public GameObject Anubis;
    public GameObject Hela;

    public GameObject speacialKillEffect;

    public GameObject closestTarget;

    public float speed = 2.0f;

    public float lifeTime = 10.0f;

    void Start()
    {
        
        GameObject closestTarget = null;
        
        Death = GameObject.FindWithTag("Player");
        Hades = GameObject.FindWithTag("Hades");
        Anubis = GameObject.FindWithTag("Anubis");
        Hela = GameObject.FindWithTag("Hela");

        Destroy(this.gameObject, lifeTime);
    }

    void Update()
    {
        closestTarget = GetClosestTarget();
        if (closestTarget != null)
        {
            Vector3 direction = closestTarget.transform.position - this.transform.position;
            this.transform.position = Vector3.MoveTowards(transform.position, closestTarget.transform.position, speed * Time.deltaTime);
        }
    }

    GameObject GetClosestTarget()
    {
        
        float shortestDistance = Mathf.Infinity;  // Define a maior distância possível

        float deathDistance = 0f;
        float anubisDistance = 0f;
        float helaDistance = 0f;
        float hadesDistance = 0f;

        closestTarget = null;

        if(Death != null)
        {
            deathDistance = Vector3.Distance(this.transform.position, Death.transform.position);
            //Debug.Log(deathDistance);
        }
        if(Anubis != null)
        {
            anubisDistance = Vector3.Distance(this.transform.position, Anubis.transform.position);
            //Debug.Log(anubisDistance);
        }
        if(Hela != null)
        {
            helaDistance = Vector3.Distance(this.transform.position, Hela.transform.position);
            //Debug.Log(helaDistance);
        }
        if(Hades != null)
        {
            hadesDistance = Vector3.Distance(this.transform.position, Hades.transform.position);
            //Debug.Log(hadesDistance);
        }

        shortestDistance = 100;
        closestTarget = null;


        if (anubisDistance <= shortestDistance && BeetleSpawn.playerTag != "Anubis" && Anubis != null)
        {
            shortestDistance = anubisDistance;
            closestTarget = Anubis;
        }
        if (helaDistance <= shortestDistance && BeetleSpawn.playerTag != "Hela" && Hela != null)
        {
            shortestDistance = helaDistance;
            closestTarget = Hela;
        }
        if (hadesDistance <= shortestDistance && BeetleSpawn.playerTag != "Hades" && Hades != null)
        {
            shortestDistance = hadesDistance;
            closestTarget = Hades;
        }
        if (deathDistance <= shortestDistance && BeetleSpawn.playerTag != "Player" && Death != null)
        {
            shortestDistance = deathDistance;
            closestTarget = Death;
        }

        return closestTarget;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hela" || other.gameObject.tag == "Anubis" || other.gameObject.tag == "Hades" || other.gameObject.tag == "Player")
        { 
            if (other.gameObject.tag == "Hela")
            {
                Debug.Log("Pegou");
                
                if (BeetleSpawn.playerTag == "Hela")
                {
                    Debug.Log("Pegou");
                    GameController.instance.points++;
                    GameController.instance.helaPoints++;
                
                }
                if (BeetleSpawn.playerTag == "Anubis")
                {
                    Debug.Log("Pegou");
                    GameController.instance.points++;
                    GameController.instance.anubisPoints++;
                
                }
                if (BeetleSpawn.playerTag == "Hades")
                {
                    Debug.Log("Pegou");
                    GameController.instance.points++;
                    GameController.instance.hadesPoints++;
                
                }
                if (BeetleSpawn.playerTag == "Player")
                {
                    Debug.Log("Pegou");
                    GameController.instance.points++;
                    GameController.instance.deathPoints++;
                
                }
                
                
                Destroy(other.gameObject);
                
                
            }
            if (other.gameObject.tag == "Anubis")
            {
                Debug.Log("Pegou");
                
                if (BeetleSpawn.playerTag == "Hela")
                {
                    Debug.Log("Pegou");
                    GameController.instance.points++;
                    GameController.instance.helaPoints++;
                
                }
                if (BeetleSpawn.playerTag == "Anubis")
                {
                    Debug.Log("Pegou");
                    GameController.instance.points++;
                    GameController.instance.anubisPoints++;
                
                }
                if (BeetleSpawn.playerTag == "Hades")
                {
                    Debug.Log("Pegou");
                    GameController.instance.points++;
                    GameController.instance.hadesPoints++;
                
                }
                if (BeetleSpawn.playerTag == "Player")
                {
                    Debug.Log("Pegou");
                    GameController.instance.points++;
                    GameController.instance.deathPoints++;
                
                }
                
                
                Destroy(other.gameObject);
                
                
            }
            if (other.gameObject.tag == "Hades")
            {
                Debug.Log("Pegou");
                
                if (BeetleSpawn.playerTag == "Hela")
                {
                    Debug.Log("Pegou");
                    GameController.instance.points++;
                    GameController.instance.helaPoints++;
                
                }
                if (BeetleSpawn.playerTag == "Anubis")
                {
                    Debug.Log("Pegou");
                    GameController.instance.points++;
                    GameController.instance.anubisPoints++;
                
                }
                if (BeetleSpawn.playerTag == "Hades")
                {
                    Debug.Log("Pegou");
                    GameController.instance.points++;
                    GameController.instance.hadesPoints++;
                
                }
                if (BeetleSpawn.playerTag == "Player")
                {
                    Debug.Log("Pegou");
                    GameController.instance.points++;
                    GameController.instance.deathPoints++;
                
                }
                
                
                Destroy(other.gameObject);
                
                
            }
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("Pegou");
                
                if (BeetleSpawn.playerTag == "Hela")
                {
                    Debug.Log("Pegou");
                    GameController.instance.points++;
                    GameController.instance.helaPoints++;
                
                }
                if (BeetleSpawn.playerTag == "Anubis")
                {
                    Debug.Log("Pegou");
                    GameController.instance.points++;
                    GameController.instance.anubisPoints++;
                
                }
                if (BeetleSpawn.playerTag == "Hades")
                {
                    Debug.Log("Pegou");
                    GameController.instance.points++;
                    GameController.instance.hadesPoints++;
                
                }
                if (BeetleSpawn.playerTag == "Player")
                {
                    Debug.Log("Pegou");
                    GameController.instance.points++;
                    GameController.instance.deathPoints++;
                
                }
                
                
                Destroy(other.gameObject);
                
                
            }
            
            
            
            //Instantiate(speacialKillEffect, other.transform.position, other.transform.rotation);
            Destroy(this.gameObject);
        }
    }
    
}
