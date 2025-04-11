using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesOpener
{
    public void Initialize()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        MonoBehaviour.print($"Open scene: {scene.name} in {mode} mode");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(Consts.MENU_SCENE_NAME);
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
}