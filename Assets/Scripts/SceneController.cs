using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
        yield return new WaitForSeconds(3);
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

    public void LoadSaved()
    {
        string path = Application.persistentDataPath + "/dreamland.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            string sceneName = formatter.Deserialize(stream) as string;
            stream.Close();
            SceneLoad(sceneName);
        }
    }
}
