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

	public enum DeathType
	{
		Lava = 0,
		NightWatcher
	}

	//////////////////////////////////////////////
	public AudioClip tutorialSong;
	public Text FlowerCallback;
	public Image GameOverImage;
	//////////////////////////////////////////////

	public Sprite lavaDeathSprite;
	public Sprite nightwatcherDeathSprite;
	DeathType deathType;

	//////////////////////////////////////////////
	GameMode myGameMode = GameMode.Tutorial;
	GameObject musicSource;
	//////////////////////////////////////////////

	int flowerCount = 0;
	bool hasTutorialStarted = false;
	bool hasGameStarted = false;

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
		if(myGameMode == GameMode.MainGame && !hasGameStarted && Input.anyKeyDown){
			GameEventManager.TriggerGameStart ();
			hasGameStarted = true;
			GameOverImage.enabled = false;
			Camera.main.gameObject.transform.FindChild ("ShadeObj").GetComponent<SpriteRenderer> ().color = new Color(0f,0f,0f,0f);
			LeiImageManager.Instance.ShowLei ();
		}
	}

	public void AddFlowerCount(){
		flowerCount++;
		//FlowerCallback.text = flowerCount.ToString ();
		LeiImageManager.Instance.AddFlowers();
	}

	public int GetFlowerCount(){
		return flowerCount;
	}

	public void EndTutorial (){
		myGameMode = GameMode.MainGame;
		//ChangeMusic?
		Application.LoadLevel(Application.loadedLevel + 1);

		GameEventManager.TriggerGamePause ();
	}

	public void PrepareRestart(){
		hasGameStarted = false;
		GameOverImage.enabled = true;
		LeiImageManager.Instance.HideLei ();
		Camera.main.gameObject.transform.FindChild ("ShadeObj").GetComponent<SpriteRenderer> ().color = new Color(0f,0f,0f,1f);
		LeiImageManager.Instance.ResetFlowers();
		flowerCount = 1;
	}

	public void HideUI(){
		LeiImageManager.Instance.HideLei ();
	}

	public void ShowUI(){
		LeiImageManager.Instance.ShowLei ();
	}

	public void SetGameOverScreen(DeathType deathtype){
		switch(deathtype){
		case DeathType.NightWatcher:
			GameOverImage.sprite = nightwatcherDeathSprite;
			break;
		case DeathType.Lava:
			GameOverImage.sprite = lavaDeathSprite;
			break;
			
		}

		this.deathType = deathtype;
	}


}
