using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.Play("MenuPrincipal"); // Substitua "NomeDaAnimacao" pelo nome da sua animação
        }
    }
}