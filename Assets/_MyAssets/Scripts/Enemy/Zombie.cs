using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private float _vitesse = 7f;
    [SerializeField] private GameObject _explosionPrefab = default;
    [SerializeField] private AudioClip _hitZombie = default;








    private void Awake()
    {

    }
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
            UIManager uIManager = FindObjectOfType<UIManager>();
            uIManager.AjouterScore(10);
            Destroy(collision.gameObject);
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }

        if (collision.tag == "ZoneEpee")
        {
            UIManager uIManager = FindObjectOfType<UIManager>();
            uIManager.AjouterScore(10);
            AudioSource.PlayClipAtPoint(_hitZombie, transform.position, 0.4f);
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
