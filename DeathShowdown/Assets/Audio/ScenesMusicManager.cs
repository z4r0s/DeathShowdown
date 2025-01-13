using UnityEngine;

public class SceneMusicManager : MonoBehaviour
{
    public int musicIndex;
    public bool loop = true;  // Adicione esta linha para definir se a música deve ser repetida

    private void Start()
    {
        AudioManager.Instance.PlayMusic(musicIndex, loop);
    }
}
