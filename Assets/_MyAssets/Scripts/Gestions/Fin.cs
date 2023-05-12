using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fin : MonoBehaviour
{/*
    [SerializeField] private TextMeshProUGUI _txtpointageJoueur = default;
    [SerializeField] private TextMeshProUGUI _txtmeilleurpointage = default;
    // Start is called before the first frame update

    private int _score = 0;
    private void Start()
    {

        ScoreFin();
    }

    public void ScoreFin()
    {
        UIManager _ui = FindObjectOfType<UIManager>();
        _score = _ui.getScore();
        _txtmeilleurpointage.gameObject.SetActive(true);
        _txtpointageJoueur.gameObject.SetActive(true);

        _txtpointageJoueur.text = "Pointage : " + PlayerPrefs.GetInt("pointage", _score);
        if (PlayerPrefs.HasKey("meilleur"))
        {
            if (PlayerPrefs.GetInt("pointage") > PlayerPrefs.GetInt("meilleur"))
            {
                PlayerPrefs.SetInt("meilleur", PlayerPrefs.GetInt("pointage"));
            }
        }
        else
        {
            PlayerPrefs.SetInt("meilleur", PlayerPrefs.GetInt("pointage"));
        }
        PlayerPrefs.Save();
        _txtmeilleurpointage.text = "Meilleur pointage : " + PlayerPrefs.GetInt("meilleur");
    }*/
}
