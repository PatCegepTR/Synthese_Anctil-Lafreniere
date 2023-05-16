using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private float _vitesse = 3f;
    [SerializeField] private GameObject _explosionPrefab = default;


    private int _vie = 3;





    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _vitesse);
        TeleportationZombie();
    }

    private void TeleportationZombie()
    {
        if (transform.position.x < -41f)
        {
            float randomX = Random.Range(-0.56f, -2.12f);
            transform.position = new Vector3(40f, randomX, 0f);
        }
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
                if (_vie <= 1)
                {
                    UIManager uIManager = FindObjectOfType<UIManager>();
                    uIManager.AjouterScore(10);
                    Destroy(collision.gameObject);
                    Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
                    Destroy(gameObject);

                }
                else
                {
                    Destroy(collision.gameObject);
                    _vie--;
                }
            }
                
            if (collision.tag == "ZoneEpee")
            {
                if (_vie <= 1)
                {
                    UIManager uIManager = FindObjectOfType<UIManager>();
                    uIManager.AjouterScore(10);
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                }
                else
                {
                    Destroy(collision.gameObject);
                    _vie--;
                }

            }

            if (collision.tag == "Player")
            {
                if (_vie <= 1)
                {
                    Player player = collision.transform.GetComponent<Player>();
                    player.Damage();
                    Destroy(gameObject);

                }
                else
                {
                    Player player = collision.transform.GetComponent<Player>();
                    player.Damage();
                    _vie--;
                }
            }
        
        
    }



      
    
}
