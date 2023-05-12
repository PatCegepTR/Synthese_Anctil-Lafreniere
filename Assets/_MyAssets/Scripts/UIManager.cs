using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Runtime.CompilerServices;

public class UIManager : MonoBehaviour  {

    [SerializeField] private TMP_Text _txtTemps = default;

    [SerializeField] private TextMeshProUGUI _txtScore = default;
    [SerializeField] private TextMeshProUGUI _txtGameOver = default;
    [SerializeField] private TextMeshProUGUI _txtRestart = default;
    [SerializeField] private TextMeshProUGUI _txtQuit = default;
    [SerializeField] private Image _barreVie = default;
    [SerializeField] private Sprite[] _couleurBarre = default;
    [SerializeField] private GameObject _pausePanel = default;
    [SerializeField] private GameObject _finPartie = default;

    private bool _pauseOn = false;
    private bool _gameOver = false;

    private int _score = default;
    // Start is called before the first frame update

    private void Start() {
        _score = 0;
        _txtGameOver.gameObject.SetActive(false);
        Time.timeScale = 1;
        //ChangeLivesDisplayImage(3);
        UpdateScore();
    }

    private void Update()
    {
        GestionRestartGame();

        GestionPause();

        GestionTemps();

    }

    private void GestionTemps()
    {
        if (!_gameOver)
        {
            float temps = Time.time;
            _txtTemps.text = "Temps : " + temps.ToString("f2");
        }
    }

    private void GestionRestartGame()
    {
        if (_txtRestart.gameObject.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (_txtRestart.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void GestionPause()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) && !_txtRestart.gameObject.activeSelf) && !_pauseOn)
        {
            _pausePanel.SetActive(true);
            Time.timeScale = 0;
            _pauseOn = true;
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) && !_txtRestart.gameObject.activeSelf) && _pauseOn)
        {
            EnleverPause();
        }
    }

    private void EnleverPause()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
        _pauseOn = false;
    }

    public void AjouterScore(int points) {
        _score += points;
        UpdateScore();
    }

    private void UpdateScore() {
        _txtScore.text = "Score : " + _score.ToString();
    }

    public int getScore()
    {
        return _score;
    }

    public void BarreDeVieLongueur(float pointsVie) {
        
        _barreVie.fillAmount = pointsVie / 100;
        //Debug.Log(pointsVie / 100);

        if (pointsVie >= 60)
        {
            _barreVie.sprite = _couleurBarre[0];
        }
        else if(pointsVie >= 35)
        {
            _barreVie.sprite = _couleurBarre[1];
        }
        else if (pointsVie > 15)
        {
            _barreVie.sprite = _couleurBarre[2];
        }
        else if (pointsVie <= 15)
        {
            _barreVie.sprite = _couleurBarre[3];
        }

        if (pointsVie <= 0) {
           GameOverSequence();
        }
    }

    private void GameOverSequence() {
        _txtGameOver.gameObject.SetActive(true);
        _txtRestart.gameObject.SetActive(true);
        _txtQuit.gameObject.SetActive(true);
        _gameOver = true;
        _finPartie.gameObject.SetActive(true);
        StartCoroutine(GameOverBlinkRoutine());
    }

    IEnumerator GameOverBlinkRoutine() {
        while (true) {
            _txtGameOver.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.7f);
            _txtGameOver.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.7f);
        }
    }

    public void ResumeGame() {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
        _pauseOn = false;
    }
}
