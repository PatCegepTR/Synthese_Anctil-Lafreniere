using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScenes : MonoBehaviour
{
    [SerializeField] private GameObject _Instruction = default;
    public void ChangerScene()
    {
        int indexScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexScene + 1);
    }

    public void Quitter()
    {
        Application.Quit();
    }

    public void RetournerAuMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void ChargerInstruction()
    {
        Debug.Log(_Instruction);
        _Instruction.SetActive(true);
    }

    public void EnleverInstruction()
    {
        _Instruction.SetActive(false);
    }

    public void Recommencer()
    {
        SceneManager.LoadScene(1);
    }
}
