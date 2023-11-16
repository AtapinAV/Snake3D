using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _pause;

    private bool _isPaused = false;

    private void Update()
    {
        PlayPause();
    }

    private void PlayPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        _pause.SetActive(false);
        Time.timeScale = 1f;
        _isPaused = false;
    }

    private void Pause()
    {
        _pause.SetActive(true);
        Time.timeScale = 0f;
        _isPaused = true;
    }

    public void PlayLevel()
    {
        SceneManager.LoadScene("Level1");
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }

    }
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE_WIN && !UNITY_EDITOR
            Application.Quit();
#endif
    }
}
