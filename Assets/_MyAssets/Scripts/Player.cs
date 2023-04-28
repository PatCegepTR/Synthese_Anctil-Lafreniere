using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private float _vitesse = 10.0f;
    //[SerializeField] private float _cadenceTir = 0.3f;
    [SerializeField] private int _viesJoueur = 3;
    //[SerializeField] private GameObject _laserPrefab = default;
    //[SerializeField] private GameObject _tripleLasersPrefab = default;

    //private float _canFire = -1f;
    //private float _cadenceInitiale;


    private void Start()
    {
        //_cadenceInitiale = _cadenceTir;  
    }

    void Update()
    {
        MouvementsJoueur();
        //TirLaser();
    }

    //private void TirLaser()
    //{
        //if (Input.GetKey(KeyCode.Space) && Time.time > _canFire)
        //{
        //    if(!_isTripleActive) 
        //    {
        //        Instantiate(_laserPrefab, transform.position + new Vector3(0f, 0.85f, 0f), Quaternion.identity); //Quaternion est pour la rotation, le .identity c'est pour garder la même rotation
        //    }
        //    else 
        //    {
        //        Instantiate(_tripleLasersPrefab, transform.position + new Vector3(0f, 0.85f, 0f), Quaternion.identity); //Quaternion est pour la rotation, le .identity c'est pour garder la même rotation
        //    }
        //    _canFire = Time.time + _cadenceTir;
        //}
    //}

    private void MouvementsJoueur()
    {
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        //Mouvements personnage
        Vector3 direction = new Vector3(horizInput, vertInput, 0f);
        transform.Translate(direction * Time.deltaTime * _vitesse);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.75f, 8.75f), Mathf.Clamp(transform.position.y, -2.20f, -0.20f), 0f);

        //Orientation personnage
        if (Input.GetKeyDown(KeyCode.D))
        {
            
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {

        }
    }



    // Méthodes publiques

    public void Damage()
    {

        //if(!_shield.activeSelf)
        //{
        //    --_viesJoueur;
        //    UIManager _uiManager = FindObjectOfType<UIManager>();
        //    _uiManager.ChangeLivesDisplayImage(_viesJoueur);
        //}
        //else
        //{
        //    _shield.SetActive(false);
        //}

        

        //if(_viesJoueur < 1)
        //{
        //    SpawnManager _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        //    //SpawnManager _spawnManager = FindObjectOfType<SpawnManager>();  Fait la même chose
        //    _spawnManager.FinJeu();
        //    Destroy(gameObject);
        //} 
    }

   

    
}
