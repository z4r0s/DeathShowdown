using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class ParedeAnimate : MonoBehaviour
{
    public SplineAnimate parede1;
    public SplineAnimate parede2;
    public SplineAnimate parede3;
    public SplineAnimate parede4;
    public SplineAnimate botao1;
    public SplineAnimate botao2;
    public SplineAnimate botao3;
    public SplineAnimate botao4;
    public SplineContainer splineContainer;
    public SplineContainer splineContainer2;
    public SplineContainer splineContainer3;
    public SplineContainer splineContainer4;
    public SplineContainer splineContainer5;
    public SplineContainer splineContainer6;
    public SplineContainer splineContainer7;
    public SplineContainer splineContainer8;
    public SplineContainer splineContainerBotao1Ir;
    public SplineContainer splineContainerBotao1Voltar;
    public SplineContainer splineContainerBotao2Ir;
    public SplineContainer splineContainerBotao2Voltar;
    public SplineContainer splineContainerBotao3Ir;
    public SplineContainer splineContainerBotao3Voltar;
    public SplineContainer splineContainerBotao4Ir;
    public SplineContainer splineContainerBotao4Voltar;
    public GameObject colliderMorte;
    public GameObject colliderMorte2;

    private void Start()
    {
        colliderMorte.SetActive(false);
        colliderMorte2.SetActive(false);
        GameController.IsOpen1 = false;
        GameController.IsOpen2 = false;
        GameController.AllOpen = true;
        GameController.PressEnable = true;
}

    private void Abrir1()
    {
        GameController.PressEnable = false;
        colliderMorte.SetActive(false);
        colliderMorte2.SetActive(false);
        parede1.Container = splineContainer;
        parede2.Container = splineContainer2;
        parede1.Restart(true);
        parede2.Restart(true);
        GameController.IsOpen1 = true;
        parede1.Play();
        parede2.Play();
        StartCoroutine(EsperaEssaPoha());
    } 
    private void Abrir2()
    {
        GameController.PressEnable = false;
        colliderMorte.SetActive(false);
        colliderMorte2.SetActive(false);
        parede3.Container = splineContainer5;
        parede4.Container = splineContainer6;
        parede3.Restart(true);
        parede4.Restart(true);
        GameController.IsOpen2 = true;
        parede3.Play();
        parede4.Play();
        StartCoroutine(EsperaEssaPoha2());
    }

    private void Fechar1()
    {
        GameController.PressEnable = false;
        colliderMorte.SetActive(false);
        colliderMorte2.SetActive(false);
        parede1.Container = splineContainer3;
        parede2.Container = splineContainer4;
        parede1.Restart(true);
        parede2.Restart(true);
        GameController.IsOpen1 = false;
        parede1.Play();
        parede2.Play();
        StartCoroutine(CoolDownPress());
    }
    private void Fechar2()
    {
        GameController.PressEnable = false;
        colliderMorte.SetActive(false);
        colliderMorte2.SetActive(false);
        parede3.Container = splineContainer7;
        parede4.Container = splineContainer8;
        parede3.Restart(true);
        parede4.Restart(true);
        GameController.IsOpen2 = false;
        parede3.Play();
        parede4.Play();
        StartCoroutine(CoolDownPress());
    }

    public void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.name == "botão (1)") 
        {
            if (GameController.PressEnable == true)
            {
                botao1.Container = splineContainerBotao1Ir;
                botao1.Restart(true);
                botao1.Play();
                StartCoroutine(CoolDownPress1());
                ControleParedes(other);
                botao1.Container = splineContainerBotao1Voltar;
                botao1.Restart(true);
                botao1.Play();

            }
        } else if (this.gameObject.name == "botão (2)")
        {
            if (GameController.PressEnable == true)
            {
                botao2.Container = splineContainerBotao2Ir;
                botao2.Restart(true);
                botao2.Play();
                StartCoroutine(CoolDownPress1());
                ControleParedes(other);
                botao2.Container = splineContainerBotao2Voltar;
                botao2.Restart(true);
                botao2.Play();

            }
        } else if (this.gameObject.name == "botão (3)")
        {
            if (GameController.PressEnable == true)
            {
                botao3.Container = splineContainerBotao3Ir;
                botao3.Restart(true);
                botao3.Play();
                StartCoroutine(CoolDownPress1());
                ControleParedes(other);
                botao3.Container = splineContainerBotao3Voltar;
                botao3.Restart(true);
                botao3.Play();

            }
        } else if (this.gameObject.name == "botão (4)")
        {
            if (GameController.PressEnable == true)
            {
                botao4.Container = splineContainerBotao4Ir;
                botao4.Restart(true);
                botao4.Play();
                StartCoroutine(CoolDownPress1());
                ControleParedes(other);
                botao4.Container = splineContainerBotao4Voltar;
                botao4.Restart(true);
                botao4.Play();

            }
        }
 
    }

    public void ControleParedes(Collider other)
    {
        ParedeKill.Player = other.gameObject;
        if (other.gameObject.tag == "Player" && GameController.AllOpen == true || other.gameObject.CompareTag("Anubis") && GameController.AllOpen == true || other.gameObject.CompareTag("Death") && GameController.AllOpen == true || other.gameObject.CompareTag("Hades") && GameController.AllOpen == true || other.gameObject.CompareTag("Hela") && GameController.AllOpen == true)
        {
            if (GameController.PressEnable == true)
            {
                GameController.PressEnable = false;
                Abrir1();
                GameController.AllOpen = false;
                Debug.Log("a1");
            }
        }
        else if (other.gameObject.tag == "Player" && GameController.IsOpen1 == false && GameController.AllOpen == false && GameController.IsOpen2 == true || other.gameObject.CompareTag("Anubis") && GameController.IsOpen1 == false && GameController.AllOpen == false && GameController.IsOpen2 == true || other.gameObject.CompareTag("Death") && GameController.IsOpen1 == false && GameController.AllOpen == false && GameController.IsOpen2 == true || other.gameObject.CompareTag("Hades") && GameController.IsOpen1 == false && GameController.AllOpen == false && GameController.IsOpen2 == true || other.gameObject.CompareTag("Hela") && GameController.IsOpen1 == false && GameController.AllOpen == false && GameController.IsOpen2 == true)
        {
            if (GameController.PressEnable == true)
            {
                GameController.PressEnable = false;
                Fechar2();
                GameController.AllOpen = true;
                Debug.Log("a2");
            }

        }
        else if (other.gameObject.tag == "Player" && GameController.IsOpen1 == false && GameController.AllOpen == false && GameController.IsOpen2 == false || other.gameObject.CompareTag("Anubis") && GameController.IsOpen1 == false && GameController.AllOpen == false && GameController.IsOpen2 == false || other.gameObject.CompareTag("Death") && GameController.IsOpen1 == false && GameController.AllOpen == false && GameController.IsOpen2 == false || other.gameObject.CompareTag("Hades") && GameController.IsOpen1 == false && GameController.AllOpen == false && GameController.IsOpen2 == false || other.gameObject.CompareTag("Hela") && GameController.IsOpen1 == false && GameController.AllOpen == false && GameController.IsOpen2 == false)
        {
            if (GameController.PressEnable == true)
            {

                Abrir2();
                GameController.AllOpen = false;
                Debug.Log("a3");
            }
        }
        else if (other.gameObject.tag == "Player" && GameController.IsOpen1 == true && GameController.AllOpen == false && GameController.IsOpen2 == false || other.gameObject.CompareTag("Anubis") && GameController.IsOpen1 == true && GameController.AllOpen == false && GameController.IsOpen2 == false || other.gameObject.CompareTag("Death") && GameController.IsOpen1 == true && GameController.AllOpen == false && GameController.IsOpen2 == false || other.gameObject.CompareTag("Hades") && GameController.IsOpen1 == true && GameController.AllOpen == false && GameController.IsOpen2 == false || other.gameObject.CompareTag("Hela") && GameController.IsOpen1 == true && GameController.AllOpen == false && GameController.IsOpen2 == false)
        {
            if (GameController.PressEnable == true)
            {
                GameController.PressEnable = false;
                Fechar1();
                GameController.AllOpen = false;
                Debug.Log("a4");
            }
        }
    }

    public IEnumerator EsperaEssaPoha()
    {
        yield return new WaitForSeconds(1f);
        colliderMorte.SetActive(true);
        GameController.PressEnable = true;
    }
    public IEnumerator EsperaEssaPoha2()
    {
        yield return new WaitForSeconds(1f);
        colliderMorte2.SetActive(true);
        GameController.PressEnable = true;
    }

    public IEnumerator CoolDownPress()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Acabou o CD");
        GameController.PressEnable = true;
    }
    public IEnumerator CoolDownPress1()
    {
        yield return new WaitForSeconds(1f);
    }
}