using UnityEngine;

public class Shotgun : Weapon
{
    private float _minYdirection = -0.12f;
    private float _maxYdirection = 0.12f;

    public override void Shoot(Transform shootPoint)
    {
        Bullet topBullet = Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        topBullet.SetDirectionY(_maxYdirection);
        Bullet middleBullet = Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        Bullet bottomBullet = Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        bottomBullet.SetDirectionY(_minYdirection);
    }
}