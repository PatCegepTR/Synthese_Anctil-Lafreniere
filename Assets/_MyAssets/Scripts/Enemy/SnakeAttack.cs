using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAttack : MonoBehaviour
{
    [SerializeField] private float _vitesse = 7f;


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
}
