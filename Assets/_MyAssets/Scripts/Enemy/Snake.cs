using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private float _vitesse = 3f;
    [SerializeField] private GameObject _explosionPrefab = default;
    [SerializeField] private GameObject _poisonAttackPrefab = default;

    private GameObject _explosion;
    private UIManager _uiManager;
    private float _fireRate;
    private float _canFire;


    private void Start()
    {
        _uiManager = FindObjectOfType<UIManager>().GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _vitesse);
        TeleportationSerpent();
        TirPoison();
    }

    private void TirPoison()
    {
        if (_uiManager.getScore() > 0)
        {
            if (Time.time > _canFire)
            {
                _fireRate = Random.Range(4f, 7f);
                _canFire = Time.time + _fireRate;
                Instantiate(_poisonAttackPrefab, transform.position + new Vector3(0.618f, 0.16f, 0f), Quaternion.identity);
            }
        }
    }

    private void TeleportationSerpent()
    {
        if (transform.position.x > 41f)
        {
            float randomX = Random.Range(-0.56f, -2.12f);
            transform.position = new Vector3(-40f, randomX, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "FireBall")
        {
            UIManager uIManager = FindObjectOfType<UIManager>();
            uIManager.AjouterScore(20);
            Destroy(collision.gameObject);
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }

        if (collision.tag == "ZoneEpee")
        {
            UIManager uIManager = FindObjectOfType<UIManager>();
            uIManager.AjouterScore(20);
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
        if (collision.tag == "Player")
        {
            Player player = collision.transform.GetComponent<Player>();
            player.Damage();

        }
    }


      
    
}
