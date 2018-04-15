using UnityEngine;

public class UIController : MonoBehaviour
{
	public GameObject victoryScreen;

	// Use this for initialization
	void Start () {
		Events.RegisterEvent(Events.EventType.WIN, ShowVictoryScreen);
	}

	void ShowVictoryScreen()
	{
		victoryScreen.SetActive(true);
	}
}
