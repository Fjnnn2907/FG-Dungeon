using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CointUI : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI cointText;
    [SerializeField] protected TextMeshProUGUI diamondText;
    private void OnEnable()
    {
        Obsever.AddObsever("UpdateCoint", UpdateCoint);
        UpdateCoint();
    }
    private void OnDisable()
    {
        Obsever.RemoveObsever("UpdateCoint", UpdateCoint);
    }
    protected void UpdateCoint()
    {
        cointText.text = GameManager.instance.cointManager.TakeCoint().ToString();
        diamondText.text = GameManager.instance.cointManager.TakeDiamond().ToString();
    }
}
