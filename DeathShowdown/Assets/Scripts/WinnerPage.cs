using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WinnerPage : MonoBehaviour
{

    public GameObject anubis;
    public GameObject death;
    public GameObject hela;
    public GameObject hades;
    public string winner;

    public Animator animator;

    private string animName = "Idle";

    void Awake()
    {
        Debug.Log("Funcionou");
        Time.timeScale = 1;
        Debug.Log("Funcionou");
    }
    void Start()
    {
        Time.timeScale = 1;
        winner = GameController.instance.winner;
        Debug.Log(winner);

        if (winner == "anubis")
        {
            anubis.SetActive(true);
            animator = anubis.GetComponentInChildren<Animator>();
            if (animator != null)
            {
                //StartCoroutine(PlayAnimation(animName));
            }
        }
        if (winner == "hades")
        {
            hades.SetActive(true);
            animator = hades.GetComponentInChildren<Animator>();
            if (animator != null)
            {
                //StartCoroutine(PlayAnimation(animName));
            }
        }
        if (winner == "hela")
        {
            hela.SetActive(true);
            animator = hela.GetComponentInChildren<Animator>();
            if (animator != null)
            {
                //StartCoroutine(PlayAnimation(animName));
            }
        }
        if (winner == "death")
        {
            death.SetActive(true);
            animator = death.GetComponentInChildren<Animator>();
            if (animator != null)
            {
                //StartCoroutine(PlayAnimation(animName));
            }
        }
    }

    private IEnumerator PlayAnimation(string animName)
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        
        if (animator != null)
        {
            animator.SetTrigger(animName);
        }

        yield return wait;
    }

    public void OnButtonPress()
    {
        //animator.SetTrigger("Idle");
        //SceneManager.LoadScene(0);
    }
}
