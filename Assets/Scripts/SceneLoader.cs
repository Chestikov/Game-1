using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int MainMenuSceneIndex;

    private void OnEnable() => _player.PlayerDied += () => SceneManager.LoadScene(MainMenuSceneIndex);
}
