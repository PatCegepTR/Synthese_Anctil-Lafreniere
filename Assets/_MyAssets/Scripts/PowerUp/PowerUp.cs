using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private int _powerUpID = default;
    //[SerializeField] private AudioClip _powerUpSound = default;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        if (transform.position.y <= -2.0f)
        {
            _speed = 0f;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            Destroy(this.gameObject);
            //AudioSource.PlayClipAtPoint(_powerUpSound, Camera.main.transform.position, 0.6f);
            if (player != null)
            {
                switch (_powerUpID)
                {
                    case 0:
                        player.ShieldPu();
                        break;
                    case 1:
                        player.HealPowerUp();
                        break;
                    case 2:
                        //player.ShieldPowerUp();
                        break;
                }
            }
        }
    }
}
