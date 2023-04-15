using Assets.Scripts.Movement.Data;
using Assets.Scripts.StatsSystem;
using Assets.Scripts.StatsSystem.Enums;
using UnityEngine;

namespace Assets.Scripts.Movement.Controller
{
    public class Jumper
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly BoxCollider2D _collider;
        private readonly JumperData _jumperData;
        private readonly IStatValueGiver _statValueGiver;

        public bool IsGrounded => _collider.IsTouchingLayers(_jumperData.GroundLayer);

        public Jumper(Rigidbody2D rigidbody, BoxCollider2D collider, JumperData jumperData, IStatValueGiver statValueGiver)
        {
            _rigidbody = rigidbody;
            _collider = collider;
            _jumperData = jumperData;
            _statValueGiver = statValueGiver;
        }

        public void Jump()
        {
            if (!IsGrounded)
            {
                return;
            }

            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _statValueGiver.GetStatValue(StatType.JumpForce));
        }
    }
}
