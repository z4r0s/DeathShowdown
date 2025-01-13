using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class CanvasControll : MonoBehaviour
{
    public GameObject PainelPause;
    bool ativado = false;

    public void Update()
    {
        if (ativado == false && Keyboard.current[Key.Escape].wasPressedThisFrame || ativado == false && Gamepad.current[GamepadButton.Start].wasPressedThisFrame)
        {
            Time.timeScale = 0;
            PainelPause.SetActive(true);
            ativado = true;
            if (PainelPause.activeSelf)
            {
                Time.timeScale = 0;
            }
        }else if(ativado == true && Keyboard.current[Key.Escape].wasPressedThisFrame || ativado == true && Gamepad.current[GamepadButton.Start].wasPressedThisFrame)
        {
            Time.timeScale = 1;
            PainelPause.SetActive(false);
            ativado = false; 
        }
        
       
    }


}
