using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static void SceneLoad(string nameOfScene)
    {
        SceneManager.LoadScene(nameOfScene);
    }
}
