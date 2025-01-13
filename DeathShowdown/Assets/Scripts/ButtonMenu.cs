using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonMenu : MonoBehaviour
{
    public Button button;
    public GameObject canvas;

    void Start()
    {
        button.Select();
    }


    public void OnButtonClick()
    {
        if (button != null)
        {
            SceneManager.LoadScene("MenuPrincipal");
            Destroy(canvas);
            GameController.instance.deathPoints = 0;
            GameController.instance.anubisPoints = 0;
            GameController.instance.helaPoints = 0;
            GameController.instance.hadesPoints = 0;
        }
    }
}
