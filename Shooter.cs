using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _shootForce;
    [SerializeField] private float _rechargeTime;

    private Transform _target;
    private Coroutine _shoot;
    private bool _isShooting = true;

    private void Start()
    {
        _shoot = StartCoroutine(Shoot());
    }

    private void OnDestroy()
    {
        if (_shoot != null)
            StopCoroutine(_shoot);
    }

    private IEnumerator Shoot()
    {
        var waitForSeconds = new WaitForSeconds(_rechargeTime);

        while (_isShooting)
        {
            Vector3 _bulletMoveDirection = (_target.position - transform.position).normalized;
            Bullet bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.transform.up = _bulletMoveDirection;
            bulletRigidbody.velocity = _bulletMoveDirection * _shootForce;
            yield return waitForSeconds;
        }
    }
}