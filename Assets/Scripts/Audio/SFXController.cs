using UnityEngine;

// Controlador de efeitos sonoros locais, usado por personagens ou objetos
[RequireComponent(typeof(AudioSource))]
public class SFXController : MonoBehaviour
{
    [Header("Action Clips")]
    [SerializeField] private AudioClip[] _clips; // Lista de sons (passos, ataques, etc.)

    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>(); // Obtém o AudioSource no mesmo GameObject
    }

    // Toca um som pelo índice na lista
    public void Play(int index)
    {
        if (index >= 0 && index < _clips.Length && _clips[index] != null)
        {
            _source.PlayOneShot(_clips[index]);
        }
    }

    // Toca um som procurando pelo nome do clip (útil para Animation Events)
    public void PlayByName(string clipName)
    {
        foreach (var clip in _clips)
        {
            if (clip != null && clip.name == clipName)
            {
                _source.PlayOneShot(clip);
                return;
            }
        }

        Debug.LogWarning($"[SFXController] Clip '{clipName}' não encontrado em {gameObject.name}");
    }

    // Toca um som personalizado diretamente (sem estar na lista)
    public void PlayCustom(AudioClip clip)
    {
        if (clip != null)
            _source.PlayOneShot(clip);
    }

    // Usado para eventos de animação (Animation Events)
    public void PlayAnimationSFX(string soundName)
    {
        PlayByName(soundName);
    }
}