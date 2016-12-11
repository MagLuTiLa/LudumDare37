using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSoundController : MonoBehaviour
{
    public string FlyingSoundClipPath = "Sounds/Fly";

    public float Volume;
    public float FadeOutTime;

    public bool IsPlaying { get { return _audio.isPlaying; } }

    private AudioSource _audio;
    private AudioClip[] _flyingSoundClips;
    private int _curClipIndex;
	// Use this for initialization
	void Start ()
	{
	    _audio = GetComponent<AudioSource>();
	    _flyingSoundClips = Resources.LoadAll<AudioClip>(FlyingSoundClipPath);
	}

    /// <summary>
    /// Starts playing the flying sound if it isn't already.
    /// </summary>
    public void Play()
    {
        if (IsPlaying) return; 

        AudioClip clip = ChooseClip();
        _audio.clip = clip;
        _audio.volume = Volume;
        _audio.loop = true;
        _audio.Play();
    }

    /// <summary>
    /// Fades out the flyin sound.
    /// </summary>
    /// <param name="time">duration of the fade</param>
    public void FadeOut(float time = -1)
    {
        if (time >= 0)
            FadeOutTime = time;

        StartCoroutine(FadeOut());
    }

    /// <summary>
    /// Chooses a random clip.
    /// </summary>
    /// <returns> random clip. </returns>
    private AudioClip ChooseClip()
    {
        if (_curClipIndex >= _flyingSoundClips.Length)
            _curClipIndex = 0;

        AudioClip clip = _flyingSoundClips[_curClipIndex];
        _curClipIndex++;

        return clip;
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0;
        float maxVolume = _audio.volume;

        while (elapsedTime < FadeOutTime)
        {
            elapsedTime += Time.deltaTime;
            float percentage = elapsedTime/FadeOutTime;
            _audio.volume = Mathf.Lerp(maxVolume, 0, percentage);
            yield return null;
        }

        _audio.Stop();
    }
}
