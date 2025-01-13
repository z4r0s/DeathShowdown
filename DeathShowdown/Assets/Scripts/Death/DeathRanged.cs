using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DeathRanged : MonoBehaviour
{
    [SerializeField] private GameObject attackGameObject; // GameObject que possui o Animator
    private Animator attackAnimator;
    
    [Header("Configurações de Animação")]
    [SerializeField] private string attackTriggerName = "Attack"; // Nome do Trigger na animação
    
    public ParticleSystem ps;

    public static DeathRanged instance;
    PlayerInputActions playerControls;
    public Transform spawnAttack;   
    private Animator _animator;

    [SerializeField]
    public GameObject _attackArea;

    public bool isAttacking = false;
    public float rechargeTime;
    
    public Image fill_bar;
    public GameObject UI_SkillCooldown;
    public Color fill_bar_CharColour;

    public float attackCooldown = 2.0f;
    public float timer = 0.0f;
    public float waitOnAttack = 2.0f;

    private void Awake()
    {
        ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        instance = this;
        _animator = GetComponentInChildren<Animator>();
        
        // garante q o GameObject e o Animator estejam configurados corretamente
        if (attackGameObject != null)
        {
            attackAnimator = attackGameObject.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("Attack GameObject não foi atribuído!");
        }

        // (Opcional) Desativa o GameObject de ataque no início
        if (attackGameObject != null)
        {
            attackGameObject.SetActive(false);
        }
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
                ps.Play(true);
                isAttacking = true;
                _animator.SetTrigger("Attack");
                StartCoroutine(Hit()); 
                timer = attackCooldown;
                
                if (attackGameObject != null && attackAnimator != null)
                {
                    // Ativar o GameObject (se necessário)
                    attackGameObject.SetActive(true);

                    // Disparar a animação de ataque
                    attackAnimator.SetTrigger(attackTriggerName);

                    // (Opcional) Desativar o GameObject após a animação terminar
                    StartCoroutine(DisableAttackGameObjectAfterAnimation());
                }
                else
                {
                    Debug.LogWarning("GameObject ou Animator não configurados!");
                }
            }
        }
    }
    
    private IEnumerator Hit()
    {  
        Debug.Log("Attack!");
        var attack = Instantiate(_attackArea, spawnAttack.position, spawnAttack.rotation);
        AudioManager.Instance.PlaySFX(2);
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
            //.color = fill_bar_CharColour;
        }
    }
    
    private System.Collections.IEnumerator DisableAttackGameObjectAfterAnimation()
    {
        // Aguarda o tempo de duração da animação (pega a duração do Animator)
        yield return new WaitForSeconds(attackAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Desativa o GameObject
        attackGameObject.SetActive(false);
    }
}