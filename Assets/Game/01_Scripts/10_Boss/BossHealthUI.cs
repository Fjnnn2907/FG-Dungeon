using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthUI : MonoBehaviour
{
    [SerializeField] protected Slider healthSlider;
    [SerializeField] protected TextMeshProUGUI textHealth;

    protected Boss enemy => gameObject.GetComponentInParent<Boss>();

    private void OnEnable()
    {


        Obsever.AddObsever("UpdateHealth", UpdateHealth);

        gameObject.SetActive(true);

        textHealth.text = $"{enemy.maxHealth}/{enemy.maxHealth}";

        healthSlider.maxValue = enemy.maxHealth;
        healthSlider.value = healthSlider.maxValue;
    }

    private void OnDisable()
    {
        Obsever.RemoveObsever("UpdateHealth", UpdateHealth);
    }

    public void UpdateHealth()
    {
        healthSlider.value = enemy.TakeHealth();
        textHealth.text = $"{enemy.TakeHealth()}/{enemy.maxHealth}";

        if (enemy.TakeHealth() <= 0)
            gameObject.SetActive(false);
    }

}
