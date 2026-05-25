using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void GoToScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	public void QuitApp()
	{
		// 1. Esto lo que hara es cerrar el juego en la versión final compilada (.exe, web, etc.)
		Application.Quit();
		Debug.Log("Application has quit.");

		// 2. Esto cerrará el modo juego si el tribunal abre el juego en el editor de Unity
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
	}
}