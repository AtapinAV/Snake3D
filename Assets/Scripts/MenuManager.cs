using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _pause;
    [SerializeField] private Text _appleText;
    [SerializeField] private Text _highAppleText;

    private int _score;
    private int _highScoree;

    private bool _isPaused = false;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        _highScoree = PlayerPrefs.GetInt("score");
        _highAppleText.text = _highScoree.ToString();
    }

    private void Update()
    {
        PlayPause();
        SaveApple();
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
    public void AddApple()
    {
        _score++;
        _appleText.text = _score.ToString();
    }
    private void SaveApple()
    {
        if (_score > _highScoree)
        {
            PlayerPrefs.SetInt("score", _score);
            PlayerPrefs.Save();
        }
    }
}
