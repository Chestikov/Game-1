using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int GameSceneIndex;

    public void OnPlayButtonClick() => SceneManager.LoadScene(GameSceneIndex);

    public void OnQuitButtonClick() => Application.Quit();
}
