using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet))
        {
            _health -= bullet.Damage;
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
        collision.gameObject.SetActive(false);
    }
}
