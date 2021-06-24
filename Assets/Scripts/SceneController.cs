using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private GameObject loadingScreen;
    void Start()
    {
        loadingScreen = transform.Find("Loading").gameObject;
        loadingScreen.SetActive(false);
    }
    public void SceneLoad(string name)
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadAsynchronously(name));
    }
    IEnumerator LoadAsynchronously(string name)
    {
        yield return new WaitForSeconds(4);
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);

        while (!operation.isDone)
        {
            yield return null;
        }
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
        #else
		        Application.Quit();
        #endif
    }
}
