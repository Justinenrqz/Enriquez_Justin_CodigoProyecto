using UnityEngine;
using UnityEngine.UI;

public class SimpleVolume : MonoBehaviour
{
	[SerializeField] private Slider volumeSlider;

	void Start()
	{
		// Al empezar, ponemos el slider en el volumen actual que tenga el juego
		volumeSlider.value = AudioListener.volume;

		// Actualiza el volumen cuando el usuario arrastra el slider
		volumeSlider.onValueChanged.AddListener(CambiarVolumen);
	}

	public void CambiarVolumen(float valor)
	{
		// Modifica el volumen global de Unity directamente (va de 0 a 1)
		AudioListener.volume = valor;
	}
}