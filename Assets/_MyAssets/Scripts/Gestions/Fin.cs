using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fin : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtPointage = default;
    [SerializeField] private TMP_Text _txtMeilleurPointage = default;
    //[SerializeField] private Button _button = default;
    [SerializeField] private GameObject _saisieNom = default;

    void Start()
    {
        _txtPointage.text = "Pointage : " + PlayerPrefs.GetInt("pointage", 0);

        if (PlayerPrefs.HasKey("meilleur"))
        {
            if (PlayerPrefs.GetInt("pointage") > PlayerPrefs.GetInt("meilleur"))
            {
                _saisieNom.SetActive(true);
                PlayerPrefs.SetInt("meilleur", PlayerPrefs.GetInt("pointage"));
            }
        }
        else
        {
            PlayerPrefs.SetInt("meilleur", PlayerPrefs.GetInt(_txtPointage.text));
        }

        _txtMeilleurPointage.text = "Meilleur Pointage : " + PlayerPrefs.GetInt("meilleur");


    }
}
