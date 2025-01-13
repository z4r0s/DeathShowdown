using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Interfaces;
using UnityEngine.UI;

public class HadesRanged : MonoBehaviour
{
    //public ParticleSystem ps;

    public static HadesRanged instance;
    PlayerInputActions playerControls;
    public GameObject hadesRangedPrefab;
    public Transform spawnHadesRanged;
    public float speedHadesRanged;  
    private Animator _animator;

    [SerializeField]
    public bool isAttacking = false;
    public Image fill_bar;
    public GameObject UI_SkillCooldown;
    public Color fill_bar_CharColour;


    public float attackCooldown = 2.0f;
    public float timer = 0.0f;
    public float waitOnAttack = 2.0f;


    private void Awake()
    {
        //ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        instance = this;
        _animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        ChangeCooldownColor();
    }

    public void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            UI_SkillCooldown.SetActive(true);
            fill_bar.fillAmount = timer / attackCooldown;
        }

        if(timer <= 0){
            isAttacking = false;
            UI_SkillCooldown.SetActive(isAttacking);
        }
    }

    public void OnAttack()
    {
        if (Time.deltaTime == 0)
        {

        }
        else
        {
            if (timer <= 0 && isAttacking == false)
            {
                //ps.Play(true);
                isAttacking = true;
                _animator.SetTrigger("Attack");
                StartCoroutine(Hit()); 
                timer = attackCooldown;
            }
        }
    }

    private IEnumerator Hit()
    {
        //AudioManager.Instance.PlaySFX(2);           
        var hadesRanged = Instantiate(hadesRangedPrefab, spawnHadesRanged.position, spawnHadesRanged.rotation);
        hadesRanged.GetComponent<Rigidbody>().velocity = spawnHadesRanged.forward * speedHadesRanged;
        //yield return new WaitForSeconds(waitOnAttack);    
        //_animator.SetTrigger("CloseAttack");
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
        
    }
    private void ChangeCooldownColor()
    {
        if (fill_bar != null)
        {   
            Color currentColor = fill_bar_CharColour;
            fill_bar.color = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Clamp01(0.5f));
        }
    }
}
