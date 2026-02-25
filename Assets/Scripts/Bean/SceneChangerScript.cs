using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerScript : MonoBehaviour
{
    public CanvasGroup fadeGroup;
    public float fadeDuration = 0.5f;

    private void Start()
    {
        if (fadeGroup != null)
        {
            fadeGroup.alpha = 1f;
            StartCoroutine(Fade(0f));
        }
    }

    public void LoadWithDelay(string sceneName)
    {
        StartCoroutine(LoadSceneAfterDelay(sceneName));
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName)
    {
        // fade uz melnu
        if (fadeGroup != null)
        {
            yield return StartCoroutine(Fade(1f));
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
        }

        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    private IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadeGroup.alpha;
        float time = 0;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            fadeGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            yield return null;
        }
        fadeGroup.alpha = targetAlpha;
    }

    public void QuitApplicationQuit()
    {
        Application.Quit();
    }
}