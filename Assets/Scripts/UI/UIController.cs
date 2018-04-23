using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
	public GameObject gameScreen;
	public GameObject victoryScreen;

	// Use this for initialization
	void Start () {
		Events.RegisterEvent(Events.EventType.LEVEL_VICTORY, ShowVictoryScreen);
		Events.RegisterEvent(Events.EventType.LEVEL_START, ShowGameScreen);
	}

	void ShowGameScreen()
	{
		gameScreen.SetActive(true);
		victoryScreen.SetActive(false);
	}

	void ShowVictoryScreen()
	{
		gameScreen.SetActive(false);
		victoryScreen.SetActive(true);
	}

	public void GoToMenu()
	{
		SceneManager.LoadScene("Menu");
	}

	public void Retry()
	{
		Events.TriggerEvent(Events.EventType.LEVEL_START);
	}

	public void NextLevel()
	{
		if (Progress.NextLevel())
		{
			Events.TriggerEvent(Events.EventType.LEVEL_START);
			return;
		}
		
		Events.TriggerEvent(Events.EventType.GAME_COMPLETED);
	}
}
