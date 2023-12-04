using System;

namespace GroupingFields
{
    public class Player
    {
        private Weapon _weapon;
        private Movement _movement;
        private string _name;
        private int _age;

        public Player(Weapon weapon, Movement movement)
        {
            _weapon = weapon;
            _movement = movement;
        }

        private void Move()
        {
            _movement.SetMovement();
        }

        private void Attack()
        {
            _weapon.DealDamage();
        }
    }

    public class Weapon
    {
        private int _damage;
        private float _rechargeTime;

        public void DealDamage() { }

        private bool IsReloading()
        {
            throw new NotImplementedException();
        }
    }

    public class Movement
    {
        private float _speed;
        private float _movementDirectionX;
        private float _movementDirectionY;

        public void SetMovement() { }
    }
}