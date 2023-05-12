using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

public class Player : MonoBehaviour
{
    [SerializeField] private float _vitesse = 10.0f;
    [SerializeField] private float _cadenceTir = 10f;
    [SerializeField] private float _cadenceDeFrappe = 1f;
    [SerializeField] private GameObject _fireBallPrefab = default;
    [SerializeField] private GameObject _zoneEpeeDroite = default;
    [SerializeField] private GameObject _zoneEpeeGauche = default;

    private Animator _anim;
    private float _viesJoueur = 100;
    private float _canFire = 10f;
    private float _canHit = -1f;
    private float _direction = 0;
    private float _posXFireB = 2.25f;
    public float _despawnEpee = 0f;
    //test pour changer motion


    private void Start()
    {
        _anim = GetComponent<Animator>();
        _anim.SetBool("StaticLeft", true);
    }

    void Update()
    {
        MouvementsJoueur();
        Tir();
        CoupEpee();
    }

    private void Tir()
    {
        if (Input.GetKey(KeyCode.E) && Time.time > _canFire)
        {
            _canFire = Time.time + _cadenceTir;
            //AudioSource.PlayClipAtPoint(_sonLaser, Camera.main.transform.position, 0.5f);
            
            Instantiate(_fireBallPrefab, transform.position + new Vector3( _posXFireB , 0f, 0f), Quaternion.Euler(0, 0, _direction));


        }
    }

    private void CoupEpee()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canHit)
        {
            _canHit = Time.time + _cadenceDeFrappe;
            _anim.SetBool("Attack", true);

            if(_anim.GetBool("StaticRight") == true)
            {
                Instantiate(_zoneEpeeDroite, transform.position + new Vector3(2f, 0f, 0f), Quaternion.identity);
                _despawnEpee = Time.time + 0.5f;
            }
            else
            {
                Instantiate(_zoneEpeeGauche, transform.position + new Vector3(-2f, 0f, 0f), Quaternion.identity);
                _despawnEpee = Time.time + 0.5f;
            }

        }
        else
        {
            _anim.SetBool("Attack", false);
        }
    }

    private void MouvementsJoueur()
    {
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");


        //Mouvements personnage
        Vector3 direction = new Vector3(horizInput, vertInput, 0f);
        transform.Translate(direction * Time.deltaTime * _vitesse);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -34f, 34f), -1.34f, 0f);

        //Orientation personnage avec animations
        if (horizInput < 0f)
        {
            _anim.SetBool("TurnLeft", true);
            _anim.SetBool("TurnRight", false);
            _anim.SetBool("StaticRight", false);
            _anim.SetBool("StaticLeft", true);
            _direction = 0;
            _posXFireB = -2.25f;
        }
        else if (horizInput > 0f)
        {
            _anim.SetBool("TurnRight", true);
            _anim.SetBool("TurnLeft", false);
            _anim.SetBool("StaticRight", true);
            _anim.SetBool("StaticLeft", false);
            _direction = 180;
            _posXFireB = 2.06f;
        }
        else
        {
            _anim.SetBool("TurnLeft", false);
            _anim.SetBool("TurnRight", false);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            //changer idleleft à right
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            //changer idleright à left
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("bozoooooo");
            //GetComponent<Rigidbody2D>().velocity = new Vector2(0,500);
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
            SpawnManager _spawnManager = FindObjectOfType<SpawnManager>();

            _spawnManager.FinPartie();
            Destroy(gameObject);
        } 
    }

   

    
}
