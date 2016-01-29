

public class GameEventManager {

	public delegate void GameEvent();

	public static event GameEvent GameTutorialStart, GameTutorialEnd, GameStart, GameOver, GamePause, GameResume, GameEnd;

	public static void TriggerGameTutorialStart(){
		if (GameTutorialStart != null) {
			GameTutorialStart ();
		}
	}

	public static void TriggerGameTutorialEnd(){
		if (GameTutorialEnd != null) {
			GameTutorialEnd ();
		}
	}

	public static void TriggerGameStart(){
		if (GameStart != null) {
			GameStart ();
		}
	}

	public static void TriggerGameOver(){
		if (GameOver != null) {
			GameOver ();
		}
	}

	public static void TriggerGamePause(){
		if (GamePause != null) {
			GamePause ();
		}
	}

	public static void TriggerGameResume(){
		if (GameResume != null) {
			GameResume ();
		}
	}

	public static void TriggerGameEnd(){
		if (GameEnd != null) {
			GameEnd ();
		}
	}

}
