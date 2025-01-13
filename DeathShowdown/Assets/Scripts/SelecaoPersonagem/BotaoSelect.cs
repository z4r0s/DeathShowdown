using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class BotaoSelect : MonoBehaviour
{
    public Button button;
    private int playerIndex;
    private InputDevice device;
    PlayerSetUpMenu menu;

    PlayerConfig playerConfig;

    void Awake()
    {
        button = menu.readyButton;
    }

    public void Prefab(PlayerConfig pc)
    {
        playerConfig = pc;
        playerIndex = pc.PlayerIndex;
        device = pc.Device;
    }
    // Start is called before the first frame update
    void Start()
    {
        menu = PlayerSetUpMenu.instance;
        var playerconfigs = PlayerConfigManager.Instance.GetConfigs().ToArray();
        for (int i = 0; i < playerconfigs.Length; i++)
        {
            //bug.Log(device);
            GetComponent<BotaoSelect>().Prefab(playerconfigs[i]);
            string name = "Setup " + i;
            Debug.Log(name);
            button = menu.readyButton;
            //if (device is Gamepad)
            //{
            //    button = GameObject.Find("/"+name+"/Ready/Confirm").GetComponent<Button>();
            //    button.Select();
            //}
            //else if (device is Keyboard)
            //{
            //    button = GameObject.Find("/" + name + "/Ready/Confirm").GetComponent<Button>();
            //    button.Select();
            //}


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        var playerconfigs = PlayerConfigManager.Instance.GetConfigs().ToArray();
        for (int i = 0; i < playerconfigs.Length; i++)
        {
            //bug.Log(device);
            GetComponent<BotaoSelect>().Prefab(playerconfigs[i]);
            string name = "Setup " + i;
            Debug.Log(name);
            button = GameObject.Find("/" + name + "/Ready/Confirm").GetComponent<Button>();
            //if (device is Gamepad)
            //{
            //    button = GameObject.Find("/"+name+"/Ready/Confirm").GetComponent<Button>();
            //    button.Select();
            //}
            //else if (device is Keyboard)
            //{
            //    button = GameObject.Find("/" + name + "/Ready/Confirm").GetComponent<Button>();
            //    button.Select();
            //}


        }
    }
}
