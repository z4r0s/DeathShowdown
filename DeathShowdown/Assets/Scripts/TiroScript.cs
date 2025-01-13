using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TiroScript : MonoBehaviour
{
    PlayerInputActions playerControls;
    public GameObject tiroPrefab;
    public Transform spawnTiro;
    public float SpeedTiro;
    public float cooldownTiro = 2.0f;
    public float timer = 0.0f;
    private Animator _animator;

    public void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    
    public void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void Tiro()
    {
        if (timer <= 0)
        {
            _animator.SetTrigger("Ranged");
            var tiro = Instantiate(tiroPrefab, spawnTiro.position, spawnTiro.rotation);
            tiro.GetComponent<Rigidbody>().velocity = spawnTiro.forward * SpeedTiro;
            timer = cooldownTiro;
        }
    }
    
}
