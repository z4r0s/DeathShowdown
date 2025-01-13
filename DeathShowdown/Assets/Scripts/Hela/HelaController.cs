using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HelaController : MonoBehaviour
{ 
    #region Variables
    PlayerInputActions playerControls;
    public GameObject anubisRangedPrefab;
    public GameObject anubisRangedPrefab2;
    public GameObject anubisRangedPrefab3;
    public Transform spawnAnubisRanged;
    public Transform spawnAnubisRanged2;
    public Transform spawnAnubisRanged3;
    public float speedAnubisRanged;
    private Animator _animator;

    public static HelaController instance;

    public bool isAttacking = false;
    public float rechargeTime = 2f;

    public float timer = 0.0f;
    public float attackCooldown = 2.0f;
    
    public Image fill_bar;
    public GameObject UI_SkillCooldown;
    public Color fill_bar_CharColour;
    
    #endregion

    public void Awake()
    {
        instance = this;
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

    public void HelaRanged()
    {
        if (Time.deltaTime == 0)
        {

        }
        else
        {   
            if (timer <= 0 && isAttacking == false)
            {
                isAttacking = true;
                _animator.SetTrigger("Attack");
                StartCoroutine(HelaRangedAttack());
                timer = attackCooldown;
            }
        }
        
    }

    private IEnumerator HelaRangedAttack()
    {
        var anubisRanged = Instantiate(anubisRangedPrefab, spawnAnubisRanged.position, spawnAnubisRanged.rotation);
        var anubisRanged2 = Instantiate(anubisRangedPrefab2, spawnAnubisRanged2.position, spawnAnubisRanged2.rotation);
        var anubisRanged3 = Instantiate(anubisRangedPrefab3, spawnAnubisRanged3.position, spawnAnubisRanged3.rotation);
        anubisRanged.GetComponent<Rigidbody>().velocity = spawnAnubisRanged.forward * speedAnubisRanged;
        anubisRanged2.GetComponent<Rigidbody>().velocity = spawnAnubisRanged2.forward * speedAnubisRanged;
        anubisRanged3.GetComponent<Rigidbody>().velocity = spawnAnubisRanged3.forward * speedAnubisRanged;
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

