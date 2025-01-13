using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class AttackArea: MonoBehaviour
{
    public List<IDamageable> Damageables { get; } = new();

    void Awake()
    {
        Destroy(this.gameObject, 0.1f);
    }

    public void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if(damageable != null)
        {
            Damageables.Add(damageable);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if (damageable != null && Damageables.Contains(damageable))
        {
            Damageables.Remove(damageable);
        }
    }
    private void OnCollisionEnter(Collision other) 
    {
        Destroy(other.gameObject);
    }
}