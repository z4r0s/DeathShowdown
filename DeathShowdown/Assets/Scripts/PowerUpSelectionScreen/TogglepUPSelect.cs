using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglepUPSelect : MonoBehaviour
{


    public void PowerUp(bool toggle)
    {
        if (this.gameObject.name == "Toggle Shield")
        {
            PlayerConfigManager.shield = toggle;
            if (PlayerConfigManager.shield == false) 
            {
                PlayerConfigManager.PowerUpsActive--;
                Debug.Log(PlayerConfigManager.PowerUpsActive);
            }
            else
            {
                PlayerConfigManager.PowerUpsActive++;
                Debug.Log(PlayerConfigManager.PowerUpsActive);
            }
            
        }
        else if (this.gameObject.name == "Toggle Speed")
        {
            PlayerConfigManager.speed = toggle;
            if (PlayerConfigManager.speed == false)
            {
                PlayerConfigManager.PowerUpsActive--;
                Debug.Log(PlayerConfigManager.PowerUpsActive);
            }
            else
            {
                PlayerConfigManager.PowerUpsActive++;
                Debug.Log(PlayerConfigManager.PowerUpsActive);
            }
        }
        else if (this.gameObject.name == "Toggle Thunder")
        {
            PlayerConfigManager.thunder = toggle;
            if (PlayerConfigManager.thunder == false)
            {
                PlayerConfigManager.PowerUpsActive--;
                Debug.Log(PlayerConfigManager.PowerUpsActive);
            }
            else
            {
                PlayerConfigManager.PowerUpsActive++;
                Debug.Log(PlayerConfigManager.PowerUpsActive);
            }
        }
        else if (this.gameObject.name == "Toggle Goblet")
        {
            PlayerConfigManager.goblet = toggle;
            if (PlayerConfigManager.goblet == false)
            {
                PlayerConfigManager.PowerUpsActive--;
                Debug.Log(PlayerConfigManager.PowerUpsActive);
            }
            else
            {
                PlayerConfigManager.PowerUpsActive++;
                Debug.Log(PlayerConfigManager.PowerUpsActive);
            }
        } 
        else if (this.gameObject.name == "Toggle Fire")
        {
            PlayerConfigManager.fire = toggle;
            if (PlayerConfigManager.fire == false)
            {
                PlayerConfigManager.PowerUpsActive--;
                Debug.Log(PlayerConfigManager.PowerUpsActive);
            }
            else
            {
                PlayerConfigManager.PowerUpsActive++;
                Debug.Log(PlayerConfigManager.PowerUpsActive);
            }
        } 
        else if (this.gameObject.name == "Toggle Beetle")
        {
            PlayerConfigManager.beetle = toggle;
            if (PlayerConfigManager.beetle == false)
            {
                PlayerConfigManager.PowerUpsActive--;
                Debug.Log(PlayerConfigManager.PowerUpsActive);
            }
            else
            {
                PlayerConfigManager.PowerUpsActive++;
                Debug.Log(PlayerConfigManager.PowerUpsActive);
            }
        } 
        else if (this.gameObject.name == "Toggle Bow")
        {
            PlayerConfigManager.bow = toggle;
            if (PlayerConfigManager.bow == false)
            {
                PlayerConfigManager.PowerUpsActive--;
                Debug.Log(PlayerConfigManager.PowerUpsActive);
            }
            else
            {
                PlayerConfigManager.PowerUpsActive++;
                Debug.Log(PlayerConfigManager.PowerUpsActive);
            }
        } 
        else if (this.gameObject.name == "Toggle Hourglass")
        {
            PlayerConfigManager.hourglass = toggle;
            if (PlayerConfigManager.hourglass == false)
            {
                PlayerConfigManager.PowerUpsActive--;
                Debug.Log(PlayerConfigManager.PowerUpsActive);
            }
            else
            {
                PlayerConfigManager.PowerUpsActive++;
                Debug.Log(PlayerConfigManager.PowerUpsActive);
            }
        }

    }
}
