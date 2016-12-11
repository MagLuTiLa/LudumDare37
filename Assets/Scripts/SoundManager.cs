using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Looks up and plays sounds in the library.
/// </summary>
public class SoundManager : MonoBehaviour
{
	public AudioClip[] playList;
	public static float musicVolume = 0.4f;
	
	static bool loopMusic = false;
	static Dictionary<string, AudioClip> soundEffects;
	static Dictionary<string, AudioClip> music;
	
	void Awake()
	{
		// Pre-load sound effects
		soundEffects = new Dictionary<string, AudioClip>();
		foreach (AudioClip a in Resources.LoadAll<AudioClip>("_Sounds/_SFX"))
		{
			soundEffects.Add(a.name, a);
		}
		
		// Pre-load music
		music = new Dictionary<string, AudioClip>();
		foreach (AudioClip a in Resources.LoadAll<AudioClip>("_Sounds/_Music"))
		{
			music.Add(a.name, a);
		}
	}
	
	void Update()
	{
		
	}
	
    /// <summary>
    /// Play a sound clip.
    /// </summary>
    /// <param name="clip">Soundclip we would like to play.</param>
    /// <param name="pitch">The pitch the soundclip should have.</param>
    /// <param name="volume">The volume the soundclip should have.</param>
    /// <param name="loop">Whether the sounclip should loop.</param>
    /// <returns></returns>
	private static AudioSource PlayClipInstance(AudioClip clip, float pitch = 1.0f, float volume = 1.0f, bool loop = false)
	{
        if (clip == null)
            return null;

		var tempGO = new GameObject("TempAudio"); // Create the temporary audio object.
		var audioSource = tempGO.AddComponent<AudioSource>(); // Add an audio source to the object.
		audioSource.clip = clip; // Define the clip.

        audioSource.Play(); // Start the sound.
		// Set audioSource properties.
		audioSource.pitch = pitch;
		audioSource.volume = musicVolume;
		audioSource.loop = loop;
		
        if(!loop)
		    Destroy(tempGO, clip.length); // Destroy object after clip duration

		return audioSource; // return the AudioSource reference
	}
	
    /// <summary>
    /// Coroutine to loop through our music list.
    /// </summary>
    /// <returns></returns>
	IEnumerator LoopMusic()
	{
		int previousSongIndex = -1;
		
		while (loopMusic)
		{
            // Pick a random song from the music list.
			int randomSongIndex = UnityEngine.Random.Range(0, playList.Length);
			while (playList.Length > 1 && randomSongIndex == previousSongIndex)
				randomSongIndex = UnityEngine.Random.Range(0, playList.Length);
			
            // Play the randomly picked song
			AudioClip randomSong = playList[randomSongIndex];
			PlayClipInstance(randomSong, 1, musicVolume, false);
            // Wait until the song is over before picking another song.
			yield return new WaitForSeconds(randomSong.length);
			
			yield return null;
		}
	}

    /// <summary>
    /// Play a sound from our sound library.
    /// </summary>
    /// <param name="name">Name of the sound in our Sounds folder.</param>
    /// <param name="pitch">Pitch the sound should be played at.</param>
    /// <param name="volume">Volume of the sound played.</param>
    /// <param name="loop">Whether the sound should loop.</param>
    public static void PlaySound(string name, float pitch = 1.0f, float volume = 1.0f, bool loop = false)
    {
        AudioClip clip = FindSound(name);
        if (clip == null)
            new Exception("Could not find sound of name: " + name);

        PlayClipInstance(clip, pitch, volume, loop);
    }

    /// <summary>
    /// Find and return a sound in our sound library.
    /// </summary>
    /// <param name="name">Name of the sound we're looking for in our Sounds folder.</param>
    /// <returns>The audioclip we found under the given name.</returns>
    public static AudioClip FindSound(string name)
    {
        AudioClip result = null;
        soundEffects.TryGetValue(name, out result);
        if (result == null)
            music.TryGetValue(name, out result);
        return result;
    }
}
