using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAttack : MonoBehaviour
{

    [SerializeField] private GameObject _poisonHit = default;

    private float _vitesse = 6f;


    private Animator _anim;


    public void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _vitesse);
        if (transform.position.y > 60f)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "FireBall")
        {
            UIManager uIManager = FindObjectOfType<UIManager>();
            Destroy(collision.gameObject);
            Instantiate(_poisonHit, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }

        if (collision.tag == "ZoneEpee")
        {
            UIManager uIManager = FindObjectOfType<UIManager>();
  
            Destroy(collision.gameObject);
            Instantiate(_poisonHit, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
        if (collision.tag == "Player")
        {
            Player player = collision.transform.GetComponent<Player>();
            Instantiate(_poisonHit, transform.position, Quaternion.identity);
            player.Damage();

            Destroy(gameObject);
        }
    }
}
