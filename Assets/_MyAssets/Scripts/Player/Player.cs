using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

public class Player : MonoBehaviour
{
    [SerializeField] private float _vitesse = 10.0f;
    [SerializeField] private float _forceSaut = 5.0f;

    [SerializeField] private float _cadenceTir = 0.5f;
    [SerializeField] private GameObject _fireBallPrefab = default;

    private Animator _anim;
    private float _viesJoueur = 100;
    private float _canFire = -1f;
    private float direction = 0;

    //test pour changer motion


    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        MouvementsJoueur();
        Tir();
    }

    private void Tir()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _cadenceTir;
            //AudioSource.PlayClipAtPoint(_sonLaser, Camera.main.transform.position, 0.5f);
            float angleFireBall = Mathf.Atan2(0f, direction) * Mathf.Rad2Deg;
            Instantiate(_fireBallPrefab, transform.position + new Vector3(2.25f, 0f, 0f), Quaternion.Euler(0, 0, angleFireBall) );

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
            direction = 0f;
        }
        else if (horizInput > 0f)
        {
            _anim.SetBool("TurnRight", true);
            _anim.SetBool("TurnLeft", false);
            _anim.SetBool("StaticRight", true);
            direction = 180f;
        }
        else
        {
            _anim.SetBool("TurnLeft", false);
            _anim.SetBool("TurnRight", false);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            //changer idleleft � right
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            //changer idleright � left
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("bozoooooo");
            //GetComponent<Rigidbody2D>().velocity = new Vector2(0,500);
        }


    }



    // M�thodes publiques

    public void Damage()
    {

        _viesJoueur = _viesJoueur - 10; 
        //--_viesJoueur;
        UIManager _uiManager = FindObjectOfType<UIManager>();
        
        _uiManager.BarreDeVieLongueur(_viesJoueur);
        
        if(_viesJoueur <= 0)
        {
            //SpawnManager _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
            //SpawnManager _spawnManager = FindObjectOfType<SpawnManager>();  Fait la m�me chose
            //_spawnManager.FinJeu();
            //Destroy(gameObject);
        } 
    }

   

    
}
