using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] [Range(0f, 1f)] private float _lowVolume;
    [SerializeField] [Range(0f, 1f)] private float _highVolume;

    private void Start()
    {
        Game.Instance.music = this;
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _highVolume;
    }

    public void SetToLowVolume()
    {
        _audioSource.volume = _lowVolume;
    }

    public void SetToHighVolume()
    {
        _audioSource.volume = _highVolume;
    }

    public void Stop()
    {
        _audioSource.Stop();
    }

    public void Play()
    {
        _audioSource.Play();
    }

    private void OnDestroy()
    {
        Game.Instance.music = null;
    }
}