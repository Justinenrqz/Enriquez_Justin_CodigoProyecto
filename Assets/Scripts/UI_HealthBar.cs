using UnityEngine;
using UnityEngine.UI;

public class UI_HealthBar : MonoBehaviour
{
	[Header("Componente Visual")]
	[SerializeField] private Image lifeFiller;

	
	public void UpdateHealthBar(float currentHealth, float maxHealth)
	{
		// Forzamos que el valor no baje de 0 ni suba de 1
		float targetFill = currentHealth / maxHealth;
		lifeFiller.fillAmount = Mathf.Clamp01(targetFill);
	}
}