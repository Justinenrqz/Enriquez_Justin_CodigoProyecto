using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
	public static UI instance;

	[SerializeField] private GameObject gameOverUI;
	[Space]
	[SerializeField] private TextMeshProUGUI timerText;
	[SerializeField] private TextMeshProUGUI killCountText;

	private int killCount;
	private float elapsedTime;   // Nueva variable para medir el tiempo del nivel
	private bool isGameOver = false; // Nueva variable para controlar si el tiempo debe detenerse

	private void Awake()
	{
		instance = this;
		Time.timeScale = 1;
		elapsedTime = 0f; // Nos aseguramos de que empiece en 0 al cargar la escena
	}

	private void Update()
	{
		// Solo sumamos tiempo y actualizamos el texto si el juego NO ha terminado
		if (!isGameOver)
		{
			elapsedTime += Time.deltaTime; // Suma el tiempo real que pasa entre frames
			timerText.text = elapsedTime.ToString("F2") + "s";
		}
	}

	public void EnableGameOverUI()
	{
		isGameOver = true;   // Al activarse, el Update dejará de sumar tiempo
		Time.timeScale = .5f; // El juego se ralentiza, pero el cronometro no continúa
		gameOverUI.SetActive(true);
	}

	public void RestartLevel()
	{
		int sceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(sceneIndex);
	}

	public void addKillCount()
	{
		killCount++;
		killCountText.text = killCount.ToString();
	}
}