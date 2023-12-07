using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 bulletMoveDirection, float shootForce)
    {
        _rigidbody.transform.up = bulletMoveDirection;
        _rigidbody.velocity = bulletMoveDirection * shootForce;
    }
}