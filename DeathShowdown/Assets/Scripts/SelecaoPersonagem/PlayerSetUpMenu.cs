using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSetUpMenu : MonoBehaviour
{
    private int PlayerIndex;

    [SerializeField]
    private TextMeshProUGUI title;
    [SerializeField]
    private TextMeshProUGUI DeathSelected;
    [SerializeField]
    private GameObject Press;
    [SerializeField]
    private GameObject readyPanel;
    [SerializeField]
    private GameObject menuPanel;
    public static bool ativo = true;
    public static int tempoativo = 5;

    public Button readyButton;
    [SerializeField]
    private Button DeathButton;
    public static PlayerSetUpMenu instance;

    private GameObject Prefab;

    private float ignoreInputTime = 1.5f;
    private bool inputEnable;

    public void SetPlayerIndex(int pi) 
    { 
        PlayerIndex = pi; 
        title.SetText("Player " + (pi + 1).ToString());
        ignoreInputTime = Time.time + ignoreInputTime;
    }

    private void Start()
    {
        Press = GameObject.Find("Text_press");
    }
    private void Awake()
    {
        inputEnable = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time > ignoreInputTime)
        {
            inputEnable = true;
        }
        if (readyPanel.gameObject.activeSelf && ativo == true && tempoativo > 0)
        {
            readyButton.Select();
            ativo = false;
            tempoativo--;
        }
    }

    public void SetObj(GameObject prefab)
    {
        
        if (prefab.name == "AnusbisTeste" && PlayerConfigManager.anubis == true)
        {
            DeathSelected.SetText("Anubis");
            if (!inputEnable) { return; }
            PlayerConfigManager.Instance.SetPlayerPrefab(PlayerIndex, prefab);
            readyPanel.SetActive(true);
            readyButton.Select();
            menuPanel.SetActive(false);
            PlayerConfigManager.anubis = false;
            Prefab = prefab;
        } else if (prefab.name == "PlayerE" && PlayerConfigManager.death == true)
        {
            DeathSelected.SetText("Reaper");
            if (!inputEnable) { return; }
            PlayerConfigManager.Instance.SetPlayerPrefab(PlayerIndex, prefab);
            readyPanel.SetActive(true);
            readyButton.Select();
            menuPanel.SetActive(false);
            PlayerConfigManager.death = false;
            Prefab = prefab;
        } else if (prefab.name == "Hades" && PlayerConfigManager.hades == true)
        {
            DeathSelected.SetText("Hades");
            if (!inputEnable) { return; }
            PlayerConfigManager.Instance.SetPlayerPrefab(PlayerIndex, prefab);
            readyPanel.SetActive(true);
            readyButton.Select();
            menuPanel.SetActive(false);
            PlayerConfigManager.hades = false;
            Prefab = prefab;
        } else if (prefab.name == "Hela" && PlayerConfigManager.hela == true)
        {
            DeathSelected.SetText("Hela");
            if (!inputEnable) { return; }
            PlayerConfigManager.Instance.SetPlayerPrefab(PlayerIndex, prefab);
            readyPanel.SetActive(true);
            readyButton.Select();
            menuPanel.SetActive(false);
            PlayerConfigManager.hela = false;
            Prefab = prefab;
        }
    }

    public void ReadyPlayer()
    {
        if(!inputEnable) { return; }

        PlayerConfigManager.Instance.ReadyPlayer(PlayerIndex);
        readyButton.gameObject.SetActive(false);
        Press.SetActive(false);
    }

    public void Voltar()
    {
        if (!inputEnable) { return; }
        if(Prefab.name == "AnusbisTeste")
        {
            PlayerConfigManager.anubis = true;
        } else if(Prefab.name == "PlayerE")
        {
            PlayerConfigManager.death = true;
        } else if(Prefab.name == "Hades")
        {
            PlayerConfigManager.hades = true;
        } else if (Prefab.name == "Hela")
        {
            PlayerConfigManager.hela = true;
        }
        DeathButton.Select();
    }

}
