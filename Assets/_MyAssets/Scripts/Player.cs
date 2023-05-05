using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private float _vitesse = 10.0f;
    //[SerializeField] private float _cadenceTir = 0.3f;
    
    [SerializeField] private Image _barreVie = default;
    //[SerializeField] private GameObject _laserPrefab = default;
    //[SerializeField] private GameObject _tripleLasersPrefab = default;

    //private float _canFire = -1f;
    //private float _cadenceInitiale;
    private Animator _anim;
    private float _viesJoueur = 100;
    private void Start()
    {
        //_cadenceInitiale = _cadenceTir;  
        _anim = GetComponent<Animator>();
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
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -60f, 60f), -1.57f, 0f);

        //Orientation personnage
        if (horizInput == 0f)
        {
            _anim.SetBool("Run", false);
        }
        else
        {
            _anim.SetBool("Run", true);
        }

    }



    // Méthodes publiques

    public void Damage()
    {

        _viesJoueur = _viesJoueur - 10; 
        //--_viesJoueur;
        UIManager _uiManager = FindObjectOfType<UIManager>();
        
        _uiManager.BarreDeVieLongueur(_viesJoueur);
        
        if(_viesJoueur <= 0)
        {
            //SpawnManager _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
            //SpawnManager _spawnManager = FindObjectOfType<SpawnManager>();  Fait la même chose
            //_spawnManager.FinJeu();
            //Destroy(gameObject);
        } 
    }

   

    
}
