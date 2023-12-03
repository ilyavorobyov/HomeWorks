using System;

namespace GroupingFields
{
    public class Player
    {
        private string _name;
        private int _age;
        private float _speed;
        private float _movementDirectionX;
        private float _movementDirectionY;

        private void Move()
        {
            //Do move
        }
    }

    public class Weapon
    {
        private int _damage;
        private float _rechargeTime;

        private void Attack()
        {
            //attack
        }

        private bool IsReloading()
        {
            throw new NotImplementedException();
        }
    }
}