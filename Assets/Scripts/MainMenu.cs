using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int GameSceneIndex;

    public void PlayGame() => SceneManager.LoadScene(GameSceneIndex);

    public void QuitGame() => Application.Quit();
}
