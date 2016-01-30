using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using BitStrap;

public class TutorialGameManager : Singleton<TutorialGameManager> {

	public AudioClip TutorialSong;
	GameObject MusicSource;

	// Use this for initialization
	void Start () {

		//TODO: do a proper fading here!

		//////////////////////////////////////////////////////////////////////////////////////////
		//Change the main song
		MusicSource = GameObject.FindGameObjectWithTag("Music");
		AudioSource audioSource = MusicSource.GetComponent<AudioSource> ();

		if(audioSource.isPlaying){
			audioSource.Stop();
		}

		audioSource.clip = TutorialSong;
		audioSource.Play();
		//////////////////////////////////////////////////////////////////////////////////////////

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
