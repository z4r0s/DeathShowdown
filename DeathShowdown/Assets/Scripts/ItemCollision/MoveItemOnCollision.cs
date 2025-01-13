using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItemOnCollision : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public float moveDistance = 0.3f;

    public float force = 800f;
    public float radius = 40f;
    
    public ScreenShake shake = null;
    
    void Start()
    {
        GameObject mainCameraObject = GameObject.FindWithTag("MainCamera");
        
        Debug.Log("SKULL SPAWNED");
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddExplosionForce(force, transform.position, radius);
        rb.AddForce(transform.forward * moveDistance);
        if (mainCameraObject != null)
        {
            shake = mainCameraObject.GetComponent<ScreenShake>();
            shake.DoShake();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Anubis") || other.gameObject.CompareTag("Hela") || other.gameObject.CompareTag("Hades"))
        {
            //Debug.Log("Colidiu");
            //StartCoroutine(MoveItem());
        }
    }
    private IEnumerator MoveItem()
    {
        Vector3 randomDirection = Random.onUnitSphere;
        randomDirection.y = 0; 
        randomDirection.Normalize();
        
        Vector3 originalPosition = transform.position;
        Vector3 targetPosition = originalPosition + randomDirection * moveDistance;
        
        float elapsedTime = 0;
        while (elapsedTime < moveSpeed)
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / moveSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}