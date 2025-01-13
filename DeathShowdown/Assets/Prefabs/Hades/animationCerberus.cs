using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationCerberus : MonoBehaviour
{
    private Animator _animator;
    public string nomeAnimator;
    void Start()
    {
        
    }

    // Update is called once per frame
   public void Awake()
    {
        //ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        _animator = GetComponentInChildren<Animator>();    
        _animator.SetTrigger(nomeAnimator);
    }
}
