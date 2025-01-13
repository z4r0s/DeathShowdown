using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerConfigManager : MonoBehaviour
{
    private List<PlayerConfig> playerConfigs;
    public static bool death = true;
    public static bool anubis = true;
    public static bool hades = true;
    public static bool hela = true;

    public static bool shield = true, beetle = true, hourglass = true, speed = true, thunder = true, goblet = true, fire = true,  bow = true;
    public static int PowerUpsActive = 8;
    public static int TempoPowerUp = 10;
    

    public GameObject SelectMaps;
    public GameObject Selecao;
    public PlayerInputManager playerInputManager;

    public Button Egito;

    public static int ffaMaxPoints = 5;

    [SerializeField]
    private int MaxPlayers = 4;

    public static PlayerConfigManager Instance { get; private set; }

    private void Awake()
    {
        death = true;
        anubis = true;
        hades = true;
        hela = true;

        PowerUpsActive = 8;
        ffaMaxPoints = 5;

        Debug.Log(death);
        if (Instance != null)
        {
            Debug.Log("Ta tentando instanciar de novo o Singleton");
        } else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfigs = new List<PlayerConfig>();
        }
    }

    public void ReadyPlayer(int index)
    {
        Debug.Log(index);
        playerConfigs[index].IsReady = true;
        if (playerConfigs.Count != 0 && playerConfigs.Count <= MaxPlayers && playerConfigs.Count > 1 &&  playerConfigs.All(p => p.IsReady == true))
        {
            for (int i = 0; i < playerConfigs.Count; i++)
            {
                GameObject.Find("Setup " + i).SetActive(false);
            }
            playerInputManager.enabled = false;
            SelectMaps.SetActive(true);
            Egito.Select();

        }
    }

    public void HandlePlayerJoin(PlayerInput pi)
    {
        Debug.Log(pi.playerIndex);
        if(!playerConfigs.Any(p => p.PlayerIndex == pi.playerIndex))
        {
            pi.transform.SetParent(transform);
            playerConfigs.Add(new PlayerConfig(pi));
        }
    }

    public void SetPlayerPrefab(int index, GameObject Prefab)
    {
        playerConfigs[index].Player = Prefab;
    }

    public List<PlayerConfig> GetConfigs()
    {
        return playerConfigs;
    }

}

public class PlayerConfig
{
    public PlayerConfig(PlayerInput pi)
    {
        PlayerIndex = pi.playerIndex;
        Input = pi;
        Device = pi.devices[0];
    }

    public PlayerInput Input { get; set; }
    public int PlayerIndex { get; set;}
    public bool IsReady { get; set; }
    public GameObject Player {  get; set; }
    public InputDevice Device { get; set; }
}