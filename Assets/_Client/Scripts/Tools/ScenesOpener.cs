using UnityEngine.SceneManagement;

public class ScenesOpener : PersistentSingleton<ScenesOpener>
{
    public void Initialize()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        print($"Open scene: {scene.name} in {mode} mode");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(Consts.MENU_SCENE_NAME);
    }
}