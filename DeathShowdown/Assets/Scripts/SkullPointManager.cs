using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SkullPointManager : MonoBehaviour
{
    public GameObject[] skullImageDeath;
    public GameObject[] skullImageAnubis;
    public GameObject[] skullImageHades;
    public GameObject[] skullImageHela;

    public int maxMatchPoints;
    
    public Sprite fullSkull;
    public Sprite halfSkull;

    public GameObject imageDeath;
    public GameObject imageAnubis;
    public GameObject imageHades;
    public GameObject imageHela;
    
    
    public GameObject SkullImageDeathFather;
    public GameObject SkullImageAnubisFather;
    public GameObject SkullImageHadesFather;
    public GameObject SkullImageHelaFather;
    
    

    void Awake()
    {
        maxMatchPoints = PlayerConfigManager.ffaMaxPoints;
    }

    private void Start()
    {
        skullImageDeath = new GameObject[maxMatchPoints];
        skullImageAnubis = new GameObject[maxMatchPoints];
        skullImageHela = new GameObject[maxMatchPoints];
        skullImageHades = new GameObject[maxMatchPoints];

        for (int j = 0; j < maxMatchPoints; j++)
        {
            Instantiate(imageDeath,SkullImageDeathFather.transform);
            GameObject.Find(imageDeath.name + "(Clone)").name = imageDeath.name + j;
            
            Instantiate(imageAnubis,SkullImageAnubisFather.transform);
            GameObject.Find(imageAnubis.name + "(Clone)").name = imageAnubis.name + j;
            
            Instantiate(imageHades,SkullImageHadesFather.transform);
            GameObject.Find(imageHades.name + "(Clone)").name = imageHades.name + j;
            
            Instantiate(imageHela,SkullImageHelaFather.transform);
            GameObject.Find(imageHela.name + "(Clone)").name = imageHela.name + j;
        }
        
        for (int i = 0; i < maxMatchPoints; i++)
        {
            skullImageDeath[i] = GameObject.Find($"{imageDeath.name}" + i);
            skullImageAnubis[i] = GameObject.Find($"{imageAnubis.name}" + i);
            skullImageHela[i] = GameObject.Find($"{imageHela.name}" + i);
            skullImageHades[i] = GameObject.Find($"{imageHades.name}" + i);
            
        }
    }

    void Update()
    {
        UpdateSkullImages(skullImageDeath, GameController.instance.deathPoints);
        UpdateSkullImages(skullImageAnubis, GameController.instance.anubisPoints);
        UpdateSkullImages(skullImageHades, GameController.instance.hadesPoints);
        UpdateSkullImages(skullImageHela, GameController.instance.helaPoints);
        
    }

    void UpdateSkullImages(GameObject[] skullImages, int deathPoints)
    {
        foreach (GameObject img in skullImages)
        {
            img.gameObject.GetComponent<Image>().sprite = halfSkull;
        }
        foreach (GameObject img in skullImages)
        {
            img.gameObject.GetComponent<Image>().sprite = halfSkull;
        }
        foreach (GameObject img in skullImages)
        {
            img.gameObject.GetComponent<Image>().sprite = halfSkull;
        }
        foreach (GameObject img in skullImages)
        {
            img.gameObject.GetComponent<Image>().sprite = halfSkull;
        }
        
        

        for (int i = 0; i < deathPoints; i++)
        {
            skullImages[i].gameObject.GetComponent<Image>().sprite = fullSkull;
        }
    }
}
