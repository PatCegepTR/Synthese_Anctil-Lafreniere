using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private float _vitesse = 7f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _vitesse);
        if (transform.position.x < -72f)
        {
            float randomX = Random.Range(-0.56f, -2.12f);
            transform.position = new Vector3(72f, randomX, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.tag == "Laser")
        {
            UIManager uIManager = FindObjectOfType<UIManager>();
            uIManager.AjouterScore(_point);
            Destroy(collision.gameObject);
            DestructionEnnemi();

        }
        */

        if (collision.tag == "Player")
        {
            Player player = collision.transform.GetComponent<Player>();
            //Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            //player.Dommage();
            Destroy(gameObject);
        }
    }
}
