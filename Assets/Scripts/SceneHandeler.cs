using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Handles the scene calls
/// </summary>
public class SceneHandeler : MonoBehaviour
{

    public static void GoToScene(int _index)
    {
        SceneManager.LoadScene(_index);
    }
    public void GoToScenePublic(int _index)
    {
        SceneManager.LoadScene(_index);
    }
    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ReloadScenePublic()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
