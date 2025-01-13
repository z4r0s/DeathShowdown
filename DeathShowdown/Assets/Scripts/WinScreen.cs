using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WinScreen : MonoBehaviour
{
    public GameObject button;
    public GameObject canvas;
    public GameObject Controller;

    public void OnButtonClick()
    {
        if (button != null)
        {
            SceneManager.LoadScene("Winner");
            Destroy(canvas);
            Destroy(Controller);
            GameController.instance.deathPoints = 0;
            GameController.instance.anubisPoints = 0;
            GameController.instance.helaPoints = 0;
            GameController.instance.hadesPoints = 0;
        }
    }
}
