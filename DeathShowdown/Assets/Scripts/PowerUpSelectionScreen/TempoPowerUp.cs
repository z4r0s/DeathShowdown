using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoPowerUp : MonoBehaviour
{
    public void SetTempo(int tempo)
    {
        if (tempo == 0)
        {
            PlayerConfigManager.TempoPowerUp = 5;
        }
        if (tempo == 1)
        {
            PlayerConfigManager.TempoPowerUp = 10;
        }
        if (tempo == 2)
        {
            PlayerConfigManager.TempoPowerUp = 15;
        }
        if (tempo == 3)
        {
            PlayerConfigManager.TempoPowerUp = 20;
        }

        
    }
}
