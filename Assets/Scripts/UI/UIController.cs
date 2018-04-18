using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
	public GameObject gameScreen;
	public GameObject victoryScreen;

	// Use this for initialization
	void Start () {
		Events.RegisterEvent(Events.EventType.WIN, ShowVictoryScreen);
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
}
