using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] protected Slider healthSlider;
    [SerializeField] TextMeshProUGUI textHealth;
    [SerializeField] protected Slider staminaSlider;
    [SerializeField] protected TextMeshProUGUI textName;
    private void Start()
    {
        healthSlider.maxValue = GameManager.instance.playerManager.player.maxHealth;
        healthSlider.value = healthSlider.maxValue;

        textHealth.text = $"{GameManager.instance.playerManager.player.maxHealth}/" +
            $"{GameManager.instance.playerManager.player.maxHealth}";

        textName.text = PlayerPrefs.GetString("CharacterName");

    }
    private void OnEnable()
    {
        Obsever.AddObsever("UpdateHealth", UpdateHealth);
    }

    private void OnDisable()
    {
        Obsever.RemoveObsever("UpdateHealth", UpdateHealth);
    }

    public void UpdateHealth()
    {
        healthSlider.value = GameManager.instance.playerManager.player.TakeHealth();

        textHealth.text = $"{GameManager.instance.playerManager.player.TakeHealth()}/" +
            $"{GameManager.instance.playerManager.player.maxHealth}";

        staminaSlider.value = GameManager.instance.playerManager.player.stamina;
        
    }

}
