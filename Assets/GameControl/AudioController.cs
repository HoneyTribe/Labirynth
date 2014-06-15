using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioController : MonoBehaviour {

	public static AudioController instance;

	public Dictionary<string, AudioClip> map = new Dictionary<string, AudioClip>();
	public AudioClip[] clips;

	public AudioSource normalAudioSource;
	public AudioSource loopAudioSource;

	void Start()
	{
		AudioSource[] audioSources = gameObject.GetComponents<AudioSource> ();
		normalAudioSource = audioSources [0];
		loopAudioSource = audioSources [1];
		loopAudioSource.loop = true;

		foreach (AudioClip clip in clips)
		{
			map.Add (clip.name, clip);
		}
		instance = this;
	}

	public void Play(string name)
	{
		normalAudioSource.PlayOneShot (map [name]);
	}

	public void PlayInLoop(string name)
	{
		loopAudioSource.clip = map [name];
		loopAudioSource.Play ();
	}

	public void StopPlayingInLoop()
	{
		loopAudioSource.Stop ();
		loopAudioSource.clip = null;
	}
}
