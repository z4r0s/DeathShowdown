using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class StopMove : MonoBehaviour
{
    public static int id;
    
   
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.name = id.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        Movement.parar = true;
        Debug.Log(this.gameObject.name);
        SpawnSlow.Habilitar(this.gameObject.name);
        Destroy(this.gameObject);
        if (collision.gameObject.tag == "Anubis")
        {
            GameController.AnubisParar = true;
            SpawnSlow.Habilitar(this.gameObject.name);
            Destroy(this.gameObject);
        } 
        else if(collision.gameObject.tag == "Hades")
        {
            GameController.HadesParar = true;
            SpawnSlow.Habilitar(this.gameObject.name);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Hela")
        {
            GameController.HelaParar = true;
            SpawnSlow.Habilitar(this.gameObject.name);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            GameController.ReaperParar = true;
            SpawnSlow.Habilitar(this.gameObject.name);
            Destroy(this.gameObject);
        }

    }
}
