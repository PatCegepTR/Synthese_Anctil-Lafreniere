using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFond : MonoBehaviour
{
    private void Awake()
    {
        int nbMusiquedeFond = FindObjectsOfType<MusicFond>().Length;
        if (nbMusiquedeFond > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
