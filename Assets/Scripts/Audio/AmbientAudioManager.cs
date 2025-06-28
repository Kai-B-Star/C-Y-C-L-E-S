using UnityEngine;

// Gerencia sons de fundo como vento, chuva ou ambiente da cena
public class AmbientAudioManager : MonoBehaviour
{
    public static AmbientAudioManager Instance;

    [SerializeField] private AudioSource _ambientSource; // Fonte de som ambiente

    private void Awake()
    {
        // Implementação Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persiste entre cenas
        }
        else
        {
            Destroy(gameObject); // Garante que só há um
        }
    }

    // Toca um som ambiente contínuo
    public void PlayAmbient(AudioClip clip, float volume = 0.5f, bool loop = true)
    {
        if (clip == null) return;

        _ambientSource.clip = clip;
        _ambientSource.volume = volume;
        _ambientSource.loop = loop;
        _ambientSource.Play();
    }

    // Para o som ambiente atual
    public void StopAmbient() => _ambientSource.Stop();

    // Altera o volume do ambiente
    public void ChangeVolume(float volume) => _ambientSource.volume = volume;
}
