using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScenes : MonoBehaviour
{
    
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


}
