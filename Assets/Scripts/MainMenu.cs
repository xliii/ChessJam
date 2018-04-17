#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public void Play()
	{
		Debug.Log("PLAY!");
	}

	public void Quit()
	{
#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
}
