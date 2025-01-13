using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [Header("Configurações")]
    [SerializeField] private string groundTag = "Ground"; // Tag do objeto ground
    [SerializeField] private float groundCheckDuration = 1.5f; // Tempo de tolerância fora do ground
    [SerializeField] private Vector3 pushForce = new Vector3(0, -500, 0); // Força de empurrão para baixo
    [SerializeField] private GameObject vfxPrefab; // Prefab do VFX a ser instanciado
    [SerializeField] private GameObject vfxPrefabFalling; // Prefab do VFX a ser instanciado
    [SerializeField] private AudioClip soundEffect; // Efeito sonoro a ser tocado
    [SerializeField] private AudioSource audioSource; // Fonte de áudio para tocar o som
    [SerializeField] private float audioStartTime = 6f; // Tempo inicial do áudio (em segundos)

    [SerializeField]private bool isOnGround = false; // Indica se o personagem está no ground
    private float timeOffGround = 0f; // Tempo que o personagem ficou fora do ground
    private Rigidbody rb; // Referência ao Rigidbody do personagem

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("O personagem precisa de um Rigidbody!");
        }

        if (audioSource == null)
        {
            Debug.LogError("Nenhuma AudioSource foi atribuída ao script!");
        }
    }

    void Update()
    {
        // Se o personagem não está no ground, começa a contar o tempo fora
        if (!isOnGround)
        {
            timeOffGround += Time.deltaTime;

            // Se o tempo fora do ground exceder o limite, aplica a força para baixo
            if (timeOffGround >= groundCheckDuration)
            {
                InstantiateVFX(); // Instancia o VFX no local atual
                ApplyPushForce();
                timeOffGround = 0f; // Reseta o contador
            }
        }
        else
        {
            // Reseta o contador se está no ground
            timeOffGround = 0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se o objeto colidido tem a tag "Ground"
        if (collision.gameObject.CompareTag(groundTag))
        {
            isOnGround = true;
            timeOffGround = 0f; // Reseta o contador quando voltar para o ground
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Verifica se o objeto deixado tem a tag "Ground"
        if (collision.gameObject.CompareTag(groundTag))
        {
            isOnGround = false;
        }
    }

    private void ApplyPushForce()
    {
        if (rb != null)
        {
            // Aplica uma força para baixo
            rb.AddForce(pushForce, ForceMode.Impulse);
            Debug.Log("Personagem foi empurrado para baixo!");
        }
    }

    private void InstantiateVFX()
    {
        if (vfxPrefab != null)
        {
            // Instancia o prefab no local atual do personagem
            Instantiate(vfxPrefab, transform.position, Quaternion.identity);
            Instantiate(vfxPrefabFalling, transform.position, Quaternion.identity);
            Debug.Log("VFX instanciado na posição do personagem.");
        }
        else
        {
            Debug.LogWarning("Prefab do VFX não está configurado!");
        }

        PlaySoundEffect(); // Toca o som ao mesmo tempo que o VFX é instanciado
    }

    private void PlaySoundEffect()
    {
        if (audioSource != null && soundEffect != null)
        {
            // Define o clipe de áudio e o ponto inicial (6 segundos no exemplo)
            audioSource.clip = soundEffect;
            audioSource.time = audioStartTime;
            audioSource.Play();

            Debug.Log($"Efeito sonoro tocado a partir de {audioStartTime} segundos.");
        }
        else
        {
            Debug.LogWarning("AudioSource ou SoundEffect não configurado!");
        }
    }
}