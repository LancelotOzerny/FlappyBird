using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    [SerializeField] private float _volume = 1.0f;
    [SerializeField] private bool _playOnStart = true;
    [SerializeField] private float _fadeDuration = 1.5f;

    private bool _isFading = false;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = 0.0f;
        _audio.mute = true;
    }

    private void Start()
    {
        if (_playOnStart) Play();
    }

    public void Play()
    {
        if (_isFading) return;

        StopAllCoroutines();

        _audio.mute = false;

        if (!_audio.isPlaying)
        {
            _audio.Play();
            StartCoroutine(FadeIn(_fadeDuration));
        }
        else if (_audio.volume < _volume)
        {
            StartCoroutine(FadeIn(_fadeDuration));
        }
    }

    public void Pause()
    {
        if (_isFading) return;

        StopAllCoroutines();
        StartCoroutine(FadeOut(_fadeDuration));
    }

    private IEnumerator FadeIn(float duration)
    {
        _isFading = true;
        float elapsedTime = 0f;
        float startVolume = _audio.volume;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            _audio.volume = Mathf.Lerp(startVolume, _volume, elapsedTime / duration);
            yield return null;
        }

        _audio.volume = _volume;
        _isFading = false;
    }

    private IEnumerator FadeOut(float duration)
    {
        _isFading = true;
        float elapsedTime = 0f;
        float startVolume = _audio.volume;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            _audio.volume = Mathf.Lerp(startVolume, 0, elapsedTime / duration);
            yield return null;
        }

        _audio.volume = 0;
        _audio.Pause();
        _audio.mute = true;
        _isFading = false;
    }
}
