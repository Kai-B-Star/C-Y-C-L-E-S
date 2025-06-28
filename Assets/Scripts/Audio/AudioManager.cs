using UnityEngine;

// Gerenciador global para sons gerais como botões, itens, música
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Fontes de Áudio")]
    [SerializeField] private AudioSource _sfxSource;   // Fonte de efeitos sonoros globais
    [SerializeField] private AudioSource _musicSource; // Fonte para música

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persiste entre cenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Toca um efeito sonoro global (ex: som de botão, pegar item)
    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        if (clip != null)
            _sfxSource.PlayOneShot(clip, volume);
    }

    // Toca uma música de fundo
    public void PlayMusic(AudioClip music, float volume = 0.5f, bool loop = true)
    {
        if (music == null) return;

        _musicSource.clip = music;
        _musicSource.volume = volume;
        _musicSource.loop = loop;
        _musicSource.Play();
    }

    // Para a música atual
    public void StopMusic() => _musicSource.Stop();
}