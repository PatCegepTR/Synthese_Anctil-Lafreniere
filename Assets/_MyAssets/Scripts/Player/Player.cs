using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

public class Player : MonoBehaviour
{
    [SerializeField] private float _vitesse = 10.0f;
    [SerializeField] private float _forceSaut = 5.0f;
    [SerializeField] private AnimationClip _idleLeft = default;
    [SerializeField] private AnimationClip _idleRight = default;


    private Animator _anim;
    private float _viesJoueur = 100;

    //test pour changer motion
    

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        MouvementsJoueur();
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
        }
        else if (horizInput > 0f)
        {
            _anim.SetBool("TurnRight", true);
            _anim.SetBool("TurnLeft", false);
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
            //SpawnManager _spawnManager = FindObjectOfType<SpawnManager>();  Fait la même chose
            //_spawnManager.FinJeu();
            //Destroy(gameObject);
        } 
    }

   

    
}
