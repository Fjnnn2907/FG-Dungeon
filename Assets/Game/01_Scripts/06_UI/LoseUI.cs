using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoseUI : MonoBehaviour
{
    public void Hone()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Resumer()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
