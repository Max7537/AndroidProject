using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awp : Weapon
{
    public override void Shoot(Vector3 direction)
    {
        if (_isShoot)
        {
            if (_amountOfbullets > 0)
            {
                Bullet bullet = GetBullet();
                bullet.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
                bullet.init(_bulletSpeed, _damage);
                _elapsedTime = 0;
                _isShoot = false;
                _amountOfbullets--;
                _amountOfAllBullets--;
                if (_amountOfbullets < 1)
                {
                    Recharge();
                }
                //ShootAction();
            }
        }
    }

    public override void CheckShootButtonPress(Vector3 direction)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot(direction);
        }
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _shootDelay)
        {
            _isShoot = true;
        }
    }
}
