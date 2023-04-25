using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _vitesse = 10.0f;
    [SerializeField] private float _cadenceTir = 0.3f;
    [SerializeField] private int _viesJoueur = 3;
    [SerializeField] private GameObject _laserPrefab = default;
    [SerializeField] private GameObject _tripleLasersPrefab = default;

    private float _canFire = -1f;
    private float _cadenceInitiale;
    private GameObject _shield;
    private bool _isTripleActive = false;

    private void Start()
    {
        _cadenceInitiale = _cadenceTir;  
        _shield = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        MouvementsJoueur();
        TirLaser();
    }

    private void TirLaser()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > _canFire)
        {
            if(!_isTripleActive) 
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0f, 0.85f, 0f), Quaternion.identity); //Quaternion est pour la rotation, le .identity c'est pour garder la même rotation
            }
            else 
            {
                Instantiate(_tripleLasersPrefab, transform.position + new Vector3(0f, 0.85f, 0f), Quaternion.identity); //Quaternion est pour la rotation, le .identity c'est pour garder la même rotation
            }
            _canFire = Time.time + _cadenceTir;
        }
    }

    private void MouvementsJoueur()
    {
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizInput, vertInput, 0f);
        transform.Translate(direction * Time.deltaTime * _vitesse);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4f, 3f), 0f);
        if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0f);
        }
        else if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0f);
        }
    }



    // Méthodes publiques

    public void Damage()
    {

        if(!_shield.activeSelf)
        {
            --_viesJoueur;
            UIManager _uiManager = FindObjectOfType<UIManager>();
            _uiManager.ChangeLivesDisplayImage(_viesJoueur);
        }
        else
        {
            _shield.SetActive(false);
        }

        

        if(_viesJoueur < 1)
        {
            SpawnManager _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
            //SpawnManager _spawnManager = FindObjectOfType<SpawnManager>();  Fait la même chose
            _spawnManager.FinJeu();
            Destroy(gameObject);
        } 
    }

    public void SpeedPowerUp()
    {
        _cadenceTir = _cadenceInitiale / 4;
        StartCoroutine(SpeedCoroutine());

    }

    IEnumerator SpeedCoroutine() 
    {
        yield return new WaitForSeconds(5f);
        _cadenceTir = _cadenceInitiale;
    }

    public void ShieldPowerUp()
    {
        _shield.SetActive(true);
    }

    public void PowerTripleShot()
    {
        _isTripleActive = true;
        StartCoroutine(TripleShotCoroutine());
    }

    IEnumerator TripleShotCoroutine()
    {
        yield return new WaitForSeconds(5f);
        _isTripleActive = false;
    }
}
