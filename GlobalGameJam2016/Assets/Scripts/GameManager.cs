using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using BitStrap;
using System.Collections;


public class GameManager : Singleton<GameManager> {

	public enum GameMode
	{
		Tutorial = 0,
		MainGame
	}

	//////////////////////////////////////////////
	public AudioClip tutorialSong;
	public Text FlowerCallback;
	//////////////////////////////////////////////

	//////////////////////////////////////////////
	GameMode myGameMode = GameMode.Tutorial;
	GameObject musicSource;
	//////////////////////////////////////////////

	int flowerCount = 0;

	// Use this for initialization
	void Start () {
		
		//TODO: do a proper fading here!

		//////////////////////////////////////////////////////////////////////////////////////////
		//Change the main song
		musicSource = GameObject.FindGameObjectWithTag("Music");
		if (musicSource) {
			AudioSource audioSource = musicSource.GetComponent<AudioSource> ();
			if (audioSource.isPlaying) {
				audioSource.Stop ();
			}

			audioSource.clip = tutorialSong;
			audioSource.Play ();			
		}
		//////////////////////////////////////////////////////////////////////////////////////////

		

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddFlowerCount(){
		flowerCount++;
		FlowerCallback.text = flowerCount.ToString ();
	}


}
