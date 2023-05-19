using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fin : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtPointage = default;
    [SerializeField] private TMP_Text _txtMeilleurPointage = default;
    [SerializeField] private GameObject _newRecordMenu = default;
    [SerializeField] private TMP_InputField _leNom = default;

    private void Start()
    {
        _txtPointage.text = "Pointage : " + PlayerPrefs.GetInt("pointage", 0);

        if (PlayerPrefs.HasKey("meilleur"))
        {
            if (PlayerPrefs.GetInt("pointage") > PlayerPrefs.GetInt("meilleur"))
            {
                _newRecordMenu.SetActive(true);
                PlayerPrefs.SetInt("meilleur", PlayerPrefs.GetInt("pointage"));
            }
        }
        else
        {
            PlayerPrefs.SetInt("meilleur", PlayerPrefs.GetInt(_txtPointage.text));
        }

        _txtMeilleurPointage.text = "Record : " + PlayerPrefs.GetString("nomMeilleur", "Patrice") + " avec " + PlayerPrefs.GetInt("meilleur");


    }


    public void EnregistrerNom()
    {
        string _nom = _leNom.text;
        PlayerPrefs.SetInt("meilleur", PlayerPrefs.GetInt("pointage"));
        PlayerPrefs.SetString("nomMeilleur", _nom);
        _newRecordMenu.SetActive(false);
        _txtMeilleurPointage.text = "Record : " + PlayerPrefs.GetString("nomMeilleur", "Patrice") + " avec " + PlayerPrefs.GetInt("meilleur");
    }

}
