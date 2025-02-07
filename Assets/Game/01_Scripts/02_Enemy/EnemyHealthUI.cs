using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] protected Slider healthSlider;
    [SerializeField] protected TextMeshProUGUI textLevel;
    [SerializeField] protected TextMeshProUGUI textHealth;

    protected Enemy enemy => gameObject.GetComponentInParent<Enemy>();

    private void OnEnable()
    {
        if (enemy != null)
            enemy.onFliped += FlipUI;

        Obsever.AddObsever("UpdateHealth", UpdateHealth);

        gameObject.SetActive(true);
        
        if(textLevel != null)
            textLevel.text = enemy.Level().ToString();
     
        textHealth.text = $"{enemy.maxHealth}/{enemy.maxHealth}";

        healthSlider.maxValue = enemy.maxHealth;
        healthSlider.value = healthSlider.maxValue;
    }

    private void OnDisable()
    {
        if(enemy != null)
            enemy.onFliped -= FlipUI;
        Obsever.RemoveObsever("UpdateHealth", UpdateHealth);
    }

    public void UpdateHealth()
    {
        healthSlider.value = enemy.TakeHealth();
        if(textLevel != null)
            textHealth.text = $"{enemy.TakeHealth()}/{enemy.maxHealth}";

        if(enemy.TakeHealth() <= 0)
            gameObject.SetActive(false);
    }

    public void FlipUI()
    {
        healthSlider.transform.Rotate(0, 180, 0);

    }
}
