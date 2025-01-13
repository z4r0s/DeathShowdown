using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Initializer : MonoBehaviour
{
    [SerializeField]
    private Transform[] Spawns;
    private GameObject Player;
    private int playerIndex;
    private InputDevice device;


    PlayerConfig playerConfig;

    public void Prefab(PlayerConfig pc)
    {
        playerConfig = pc;
        Player = pc.Player;
        playerIndex = pc.PlayerIndex;
        device = pc.Device;
    }

    private void Start()
    {
        var playerconfigs = PlayerConfigManager.Instance.GetConfigs().ToArray();
        for (int i = 0; i < playerconfigs.Length; i++)
        {
            Debug.Log(device);
            GetComponent<Initializer>().Prefab(playerconfigs[i]);
            if(device is Gamepad) 
            { 
                var player = PlayerInput.Instantiate(Player,playerIndex, controlScheme: "Controller",pairWithDevice: device);
                player.transform.position = Spawns[i].transform.position;
                player.transform.rotation = Spawns[i].transform.rotation;
            } else if(device is Keyboard) 
            {
                var player = PlayerInput.Instantiate(Player, playerIndex, controlScheme: "Keyboard", pairWithDevice: device);
                player.transform.position = Spawns[i].transform.position;
                player.transform.rotation = Spawns[i].transform.rotation;
            }
            
            
        }
    }
}
