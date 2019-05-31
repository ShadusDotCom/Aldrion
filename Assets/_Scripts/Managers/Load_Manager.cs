using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load_Manager : MonoBehaviour
{
    /// <summary>
    /// Loads a designated scene (by name) asynchronously and displays the progress
    /// on a loading bar.
    /// </summary>

    // Modified Slider to be used as progress bar    
    public Slider sldProgressBar;
    // Story defined Image for loading screens
    public Image imgSplashScreen;


    // Starts the Coroutine
    public void LoadSceneByName(string sceneName, Sprite splashScreen)
    {
        StartCoroutine(LoadAsynchronously(sceneName));
        imgSplashScreen.sprite = splashScreen;
    }

    // Coroutine to report back progress of the load
    IEnumerator LoadAsynchronously(string sceneName)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);

        while (!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / .9f);
            sldProgressBar.value = progress;

            yield return null;
        }
    }
}
