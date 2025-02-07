using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserName : MonoBehaviour
{
    public TMP_InputField userNameInput; 
    public GameObject loadingScreen;    
    public Slider progressSlider;       
    public TMP_Text progressText;       
    private string characterName;

    public void ConfirmName()
    {
        characterName = userNameInput.text;

        if (string.IsNullOrEmpty(characterName))
        {
            characterName = "User Name";
        }

        PlayerPrefs.SetString("CharacterName", characterName);

        // Bắt đầu coroutine để load scene bất đồng bộ
        StartCoroutine(LoadSceneAsync("SampleScene"));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {

        if (loadingScreen != null)
        {
            loadingScreen.SetActive(true);
        }

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            if (progressSlider != null)
            {
                progressSlider.value = progress;
            }


            if (progressText != null)
            {
                progressText.text = $"Loading: {Mathf.RoundToInt(progress * 100)}%";
            }

            if (operation.progress >= 0.9f)
            {
                if (progressText != null)
                {
                    progressText.text = "Press any key to continue...";
                }

                if (Input.anyKeyDown)
                {
                    operation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
}
