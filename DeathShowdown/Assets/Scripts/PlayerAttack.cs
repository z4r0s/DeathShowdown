using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack instance;

    PlayerInputActions playerControls;
    public Transform spawnAttack;   
    public ParticleSystem ps;

    private Animator _animator;

    [SerializeField]
    private float DamageAfterTime;

    [SerializeField]
    private int Damage;

    [SerializeField]
    public GameObject _attackArea;
    public GameObject attackEffect;

    public bool isAttacking = false;
    public float rechargeTime;
    
    public float attackCooldown = 0.1f;
    public float timer = 0.0f;
    
    private void Awake()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        instance = this;
        _animator = GetComponentInChildren<Animator>();
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

    public void OnAttack()
    {
        if(Time.deltaTime == 0)
        {

        }else 
        {
            if (timer <= 0 && isAttacking == false)
            {
                Debug.Log("Attack!");
                ps.Play(true);
                isAttacking = true;
                //var attack = Instantiate(_attackArea, spawnAttack.position, spawnAttack.rotation);
                _animator.SetTrigger("Attack");
                //_animator.SetTrigger("CloseAttack");
                StartCoroutine(Hit());
                timer = attackCooldown;
            }
        }
    }
    
    private IEnumerator Hit()
    {
        var attack = Instantiate(_attackArea, spawnAttack.position, spawnAttack.rotation);
        yield return new WaitForSeconds(rechargeTime);
        isAttacking = false;
    }
}