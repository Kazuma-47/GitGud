using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using Newtonsoft.Json.Bson;
public class LevelLoader : MonoBehaviour
{

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadSceneByIndex(int sceneIndex) => SceneManager.LoadScene(sceneIndex);

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
