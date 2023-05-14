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
    [SerializeField] private Image _barreVie = default;
    [SerializeField] private Sprite[] _couleurBarre = default;
    [SerializeField] private GameObject _pausePanel = default;
    [SerializeField] private int _scoreLvlUp = 50;

    private bool _pauseOn = false;
    private bool _gameOver = false;
    private SpawnManager _spawnManager;

    private int _score = default;
    // Start is called before the first frame update

    private void Start() {
        _spawnManager = FindObjectOfType<SpawnManager>();
        _score = 0;
        Time.timeScale = 1;
        UpdateScore();
    }

    private void Update()
    {
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


    private void GestionPause()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)) && !_pauseOn)
        {
            _pausePanel.SetActive(true);
            Time.timeScale = 0;
            _pauseOn = true;
        }
        else if ((Input.GetKeyDown(KeyCode.Escape)) && _pauseOn)
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
        
        if(_score >= _scoreLvlUp ) 
        {
            _spawnManager.LvlHarder();
            _scoreLvlUp = _scoreLvlUp * 4;
        }
        if(_score >= 50)
        {
            _spawnManager.setBoss();
        }
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

    }

    public void ResumeGame() {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
        _pauseOn = false;
    }
}
