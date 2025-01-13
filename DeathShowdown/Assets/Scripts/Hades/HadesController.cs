using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HadesController : MonoBehaviour
{ 
    #region Variables
    PlayerInputActions playerControls;
    public GameObject hadesRangedPrefab;
    public Transform spawnHadesRanged;
    public float speedHadesRanged;
    private Animator _animator;
    

    public bool isAttacking = false;
    public float rechargeTime = 2f;

    public float timer = 0.0f;
    public float attackCooldown = 2.0f;
    
    #endregion

    public void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        timer = 0;
    }

    public void Start()
    {
    
    }
    public void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0){
            isAttacking = false;
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
                StartCoroutine(HadesRangedAttack());
                timer = attackCooldown;
            }
        }
        
    }

    private IEnumerator HadesRangedAttack()
    {
        var hadesRanged = Instantiate(hadesRangedPrefab, spawnHadesRanged.position, spawnHadesRanged.rotation);
        hadesRanged.GetComponent<Rigidbody>().velocity = spawnHadesRanged.forward * speedHadesRanged;
        yield return new WaitForSeconds(rechargeTime);
        isAttacking = false; 
    }
}