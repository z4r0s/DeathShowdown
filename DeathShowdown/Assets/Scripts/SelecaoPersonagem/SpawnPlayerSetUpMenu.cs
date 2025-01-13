using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class SpawnPlayerSetUpMenu : MonoBehaviour
{
    public GameObject playerSetUpMenuPrefab;
    public PlayerInput input;
    public PlayerConfigManager manager;


    private void Awake()
    {
        var rootMenu = GameObject.Find("Selecionar Personagem");
        if (rootMenu != null) 
        { 
            var menu = Instantiate(playerSetUpMenuPrefab, rootMenu.transform);
            input.uiInputModule = menu.GetComponentInChildren<InputSystemUIInputModule>();
            menu.GetComponent<PlayerSetUpMenu>().SetPlayerIndex(input.playerIndex);
            menu.name = "Setup " + input.playerIndex;
        }
    }
}
