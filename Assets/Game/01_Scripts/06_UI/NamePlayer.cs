using TMPro;
using UnityEngine;
public class NamePlayer : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textName;

    private void Start()
    {
        textName.text = PlayerPrefs.GetString("CharacterName");
    }
}
