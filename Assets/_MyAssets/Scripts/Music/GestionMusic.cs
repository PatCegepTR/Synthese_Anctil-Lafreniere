using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionMusic : MonoBehaviour
{

    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = FindObjectOfType<MusicFond>().GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("Muted") == 0)
        {
            _audioSource.Stop();
        }
    }

    public void MusicOnOff()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            _audioSource.Play();
            PlayerPrefs.SetInt("Muted", 1);
            PlayerPrefs.Save();
        }
        else
        {
            _audioSource.Pause();
            PlayerPrefs.SetInt("Muted", 0);
            PlayerPrefs.Save();
        }
    }
}
