using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NextRound : MonoBehaviour
{
    public GameObject button;

    public void OnButtonClick(string level)
    {
        if (button != null)
        {
            SceneManager.LoadScene(level);
            Time.timeScale = 1;
        }
    }
}
