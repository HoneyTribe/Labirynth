using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioController : MonoBehaviour {

	public static AudioController instance;

	public Dictionary<string, AudioClip> map = new Dictionary<string, AudioClip>();
	public AudioClip[] clips;

	void Start()
	{
		foreach (AudioClip clip in clips)
		{
			map.Add (clip.name, clip);
		}
		instance = this;
	}

	public void Play(string name)
	{
		AudioSource.PlayClipAtPoint (map [name], transform.position);
	}
}
