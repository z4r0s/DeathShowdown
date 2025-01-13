using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;

public class ChangeController : MonoBehaviour
{
    private GameObject Player;
    private int playerIndex;
    private InputDevice device;
    private InputDevice[] devices = new InputDevice[4];



    PlayerConfig playerConfig;

    public void Prefab(PlayerConfig pc)
    {
        playerConfig = pc;
        Player = pc.Player;
        playerIndex = pc.PlayerIndex;
        device = pc.Device;
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Anubis" || other.gameObject.tag == "Hades" || other.gameObject.tag == "Hela")
        {
            StartCoroutine(TrocarControles());
            this.gameObject.transform.position = new Vector3(0, 40, 0);
            Spawner.canSpawn = true;
        }

    }

    public IEnumerator TrocarControles()
    {
        var playerconfigs = PlayerConfigManager.Instance.GetConfigs().ToArray();
        for (int i = 0; i < playerconfigs.Length; i++)
        {
            GetComponent<ChangeController>().Prefab(playerconfigs[i]);
            GameObject PrefabPlayer = GameObject.Find(Player.name+"(Clone)");
            int a = i;
            if (PrefabPlayer != null)
            {
                if(PlayerInput.all.Count < playerconfigs.Length)
                {
                    a = a - (playerconfigs.Length - PlayerInput.all.Count);              
                    if (a < 0) a = 0;
                }
                if (device is Gamepad && Player.name + "(Clone)" == PrefabPlayer.name)
                {
                    int rand = Random.Range(1, 4);
                    Debug.Log(i + " Controle");
                    PlayerInput.all[a].SwitchCurrentControlScheme("ControllerB" + rand, device);

                }
                else if (device is Keyboard && Player.name + "(Clone)" == PrefabPlayer.name)
                {
                    int rand = Random.Range(1, 4);
                    Debug.Log(i + " Teclado");
                    PlayerInput.all[a].SwitchCurrentControlScheme("KeyboardB" + rand, device);
                }
            }


        }

        yield return new WaitForSeconds(10f);

        playerconfigs = PlayerConfigManager.Instance.GetConfigs().ToArray();
        for (int i = 0; i < playerconfigs.Length; i++)
        {
            GetComponent<ChangeController>().Prefab(playerconfigs[i]);
            GameObject PrefabPlayer = GameObject.Find(Player.name + "(Clone)");
            int a = i;
            if (PrefabPlayer != null)
            {
                if (PlayerInput.all.Count < playerconfigs.Length)
                {
                    a = a - (playerconfigs.Length - PlayerInput.all.Count);
                    if (a < 0) a = 0;
                }
                if (device is Gamepad && Player.name + "(Clone)" == PrefabPlayer.name)
                {
                    PlayerInput.all[a].SwitchCurrentControlScheme("Controller", device);

                }
                else if (device is Keyboard && Player.name + "(Clone)" == PrefabPlayer.name)
                {
                    PlayerInput.all[a].SwitchCurrentControlScheme("Keyboard", device);
                }
            }
        }
        Destroy(this.gameObject);
    }
}
