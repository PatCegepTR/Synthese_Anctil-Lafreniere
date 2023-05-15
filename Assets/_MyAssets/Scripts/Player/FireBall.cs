using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float _vitesse = 14f;


    private Animator _anim;


    public void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _vitesse);
        if (transform.position.y > 60f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            _anim.SetBool("hit", true);
            _vitesse = 0f;
        }
    }
}
