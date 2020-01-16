using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int MainMenuSceneIndex;

    private void OnEnable() => _player.PlayerDied += OnPlayerDied;

    private void OnDisable() => _player.PlayerDied -= OnPlayerDied;

    private void OnPlayerDied()
    {
        SceneManager.LoadScene(MainMenuSceneIndex);
    }
}
