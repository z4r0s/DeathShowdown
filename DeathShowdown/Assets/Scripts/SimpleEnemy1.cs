using Interfaces;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour, IDamageable 
{
    public void Damage(int damageAmount)
    {
        Debug.Log($"HIT! -{damageAmount}");
    }  
}
