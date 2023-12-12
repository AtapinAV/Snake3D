using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private int _score;
    public int Score {  get { return _score; } }
    private int _highScoree;
    public int HighScoree { get { return _highScoree; } }

    [SerializeField] private GameObject _pause;
    [SerializeField] private Text _appleText;
    [SerializeField] private Text _highAppleText;
    [SerializeField] private AudioSource _clip;

    private bool _isPaused;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        _isPaused = true;
        _clip.enabled = false;
        Time.timeScale = 0f;
        _score = 0;
        _highScoree = PlayerPrefs.GetInt("score");
        _highAppleText.text = _highScoree.ToString();
    }

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
        _clip.enabled = true;
        _isPaused = false;
    }

    private void Pause()
    {
        _pause.SetActive(true);
        Time.timeScale = 0f;
        _clip.enabled = false;
        _isPaused = true;
    }
    public void AddApple()
    {
        _score++;
        _appleText.text = _score.ToString();
    }
}
