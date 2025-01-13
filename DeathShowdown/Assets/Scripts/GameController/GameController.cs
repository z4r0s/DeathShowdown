using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject anubis;
    public GameObject death;
    public GameObject hela;
    public GameObject hades;

    int spawnedPlayers = 0;
    int anubisCount = 1;
    int deathCount = 1;
    int helaCount = 1;
    int hadesCount = 1;

    public static bool IsOpen1 = false;
    public static bool IsOpen2 = false;
    public static bool AllOpen = true;

    public static bool AnubisParar = false;
    public static bool HadesParar = false;
    public static bool HelaParar = false;
    public static bool ReaperParar = false;

    public static bool PressEnable = true;

    public int anubisPoints = 0;
    public int deathPoints = 0;
    public int helaPoints = 0;
    public int hadesPoints = 0;



    public TMP_Text anubisPointsTxt;
    public TMP_Text deathPointsTxt;
    public TMP_Text helaPointsTxt;
    public TMP_Text hadesPointsTxt;


    public GameObject FFAPanel;
    public GameObject AnubisPoints;
    public GameObject backToMenuButton;
    public GameObject nextRoundButton;

    bool Funcao = false;

    int ffaMaxPoints;

    public static GameController instance;
    public TMP_Text text;
    public int points = 0;


    public bool helaShielded = false;
    public bool hadesShielded = false;
    public bool deathShielded = false;
    public bool anubisShielded = false;

    public string winner;


    void Awake()
    {
        Time.timeScale = 1;
        
        DontDestroyOnLoad(gameObject);
        if (!instance) { instance = this; }
        else { Destroy(gameObject); }
        FFAPanel = GameObject.Find("FFA Panel");
        AnubisPoints = GameObject.Find("AnubisPoints");
        anubisPointsTxt = AnubisPoints.GetComponent<TMP_Text>();
        FFAPanel.SetActive(false);
        ffaMaxPoints = PlayerConfigManager.ffaMaxPoints;
    }
    private void Start()
    {

        Time.timeScale = 1;
        Funcao = false;

    }

    void Update()
    {
        anubis = GameObject.FindWithTag("Anubis");
        death = GameObject.FindWithTag("Player");
        hela = GameObject.FindWithTag("Hela");
        hades = GameObject.FindWithTag("Hades");

        if (anubis != null)
        {
            anubisCount = 1;
        }
        else 
        {
            anubisCount = 0;
        }
        
        if (death != null)
        {
            deathCount = 1;
        }
        else 
        {
            deathCount = 0;
        }

        if (hela != null)
        {
            helaCount = 1;
        }
        else 
        {
            helaCount = 0;
        }
        
        if (hades != null)
        {
            hadesCount = 1;
        }
        else 
        {
            hadesCount = 0;
        }

        spawnedPlayers = deathCount + anubisCount + helaCount + hadesCount;

        if (spawnedPlayers <= 1 )
        {
            if(FFAPanel.activeSelf != true && Funcao == false)
            {
                Funcao = true;
                StartCoroutine(FimRound()); 
            }
           
        }
        else 
        {
            FFAPanel.SetActive(false);
            Funcao = false;

        }


        if (FFAPanel.activeSelf)
        {
            if (anubisPoints >= ffaMaxPoints || deathPoints >= ffaMaxPoints || helaPoints >= ffaMaxPoints || hadesPoints >= ffaMaxPoints)
            {
                // finalizar o jogo (botao de menu principal)
                backToMenuButton.SetActive(true);
                nextRoundButton.SetActive(false);
            }
            else 
            {
                // Recomecar round (botao de pronto e recomecar round)
                nextRoundButton.SetActive(true);
                backToMenuButton.SetActive(false);
            }
        }


        anubisPointsTxt.text = "Points: " + anubisPoints.ToString() + "/" + ffaMaxPoints;
        deathPointsTxt.text = "Points: " + deathPoints.ToString() + "/" + ffaMaxPoints;
        helaPointsTxt.text = "Points: " + helaPoints.ToString() + "/" + ffaMaxPoints;
        hadesPointsTxt.text = "Points: " + hadesPoints.ToString() + "/" + ffaMaxPoints;
        
        if (points >= 15)
        {
            SceneManager.LoadScene(nameof(winner));
        }
    
        //enable collider again
        /*
        if (!GameObject.FindWithTag("ShieldPowerUp"))
        {
            Shield.instance.p_Collider.enabled = Shield.instance.p_Collider.enabled;
        }
        */

        IEnumerator FimRound()
        {
            Debug.Log("startou");
            yield return new WaitForSeconds(2);
            FFAPanel.SetActive(true);
            Time.timeScale = 0;
        }

        if (anubisPoints >= ffaMaxPoints)
        {
            winner = "anubis";
        }
        if (deathPoints >= ffaMaxPoints)
        {
            winner = "death";
        }
        if (helaPoints >= ffaMaxPoints)
        {
            winner = "hela";
        }
        if (hadesPoints >= ffaMaxPoints)
        {
            winner = "hades";
        }

    }

    public void ChangeDeathBool(bool alg)
    {
        deathShielded = alg;
        //StartCoroutine(ShieldCountdown());
    }

    public void ChangeAnubisBool(bool alg)
    {
        anubisShielded = alg;
        //StartCoroutine(ShieldCountdown());
    }

    public void ChangeHelaBool(bool alg)
    {
        helaShielded = alg;
        //StartCoroutine(ShieldCountdown());
    }

    public void ChangeHadesBool(bool alg)
    {
        hadesShielded = alg;
        //StartCoroutine(ShieldCountdown());
    }


    IEnumerator ShieldCountdown()
    {
        if (deathShielded == true)
        {
            deathShielded = false;
        }
        if (anubisShielded == true)
        {
            anubisShielded = false;
        }
        if (helaShielded == true)
        {
            helaShielded = false;
        }
        if (hadesShielded == true)
        {
            hadesShielded = false;
        }

        yield return new WaitForSeconds(30);
    }
}