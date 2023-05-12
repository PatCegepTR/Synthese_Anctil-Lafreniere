using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupEpee : MonoBehaviour
{
    private Player _player;
    void Start()
    {
        _player = FindObjectOfType<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (_player._despawnEpee <= Time.time)
        {
            Destroy(gameObject);
        }
    }
}
