using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AnubisController : MonoBehaviour
{ 
    #region Variables
    PlayerInputActions playerControls;
    public GameObject anubisRangedPrefab;
    public Transform spawnAnubisRanged;
    public float speedAnubisRanged;
    private Animator _animator;
    //public ParticleSystem ps;
    public Image fill_bar;
    public GameObject UI_SkillCooldown;
    public Color fill_bar_CharColour;
    public static AnubisController instance;

    public float timer = 0.0f;
    public float attackCooldown = 2.0f;
    public float rechargeTime = 2f;
    public bool isAttacking = false;
    
    #endregion

    public void Awake()
    {
        instance = this;
        //ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        _animator = GetComponentInChildren<Animator>();
        timer = 0;
    }

    public void Start()
    {
        ChangeCooldownColor();
    }
    public void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            UI_SkillCooldown.SetActive(true);
            fill_bar.fillAmount = timer / rechargeTime;
        }

        if(timer <= 0){
            isAttacking = false;
            UI_SkillCooldown.SetActive(isAttacking);
        }
    }

    public void AnubisRanged()
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
                StartCoroutine(AnubisRangedAttack());
                timer = attackCooldown;
            }
        }
        
    }

    private IEnumerator AnubisRangedAttack()
    {
        var anubisRanged = Instantiate(anubisRangedPrefab, spawnAnubisRanged.position, spawnAnubisRanged.rotation);
        anubisRanged.GetComponent<Rigidbody>().velocity = spawnAnubisRanged.forward * speedAnubisRanged;
        yield return new WaitForSeconds(rechargeTime);
        isAttacking = false; 
    }

    private void ChangeCooldownColor()
    {
        if (fill_bar != null)
        {   
            Color currentColor = fill_bar_CharColour;
            fill_bar.color = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Clamp01(0.5f));
            //.color = fill_bar_CharColour;
        }
    }
}

