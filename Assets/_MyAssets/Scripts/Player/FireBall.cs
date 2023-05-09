using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float _vitesse = 14f;

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _vitesse);
        if (transform.position.y > 60f)
        {
            Destroy(gameObject);
        }
    }
}
