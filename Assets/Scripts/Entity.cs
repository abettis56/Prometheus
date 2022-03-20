using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prometheus
{
    public class Entity
    {
        private float _moveSpeed;
        public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
        private bool _canMove;
        public bool CanMove { get => _canMove; set => _canMove = value; }
        private Rigidbody2D _physicsBody;
        public Rigidbody2D PhysicsBody { get => _physicsBody; }

        public Entity(float moveSpeed, bool canMove, Rigidbody2D physicsBody)
        {
            _canMove = canMove;
            _moveSpeed = moveSpeed;
            _physicsBody = physicsBody;
        }

        public void Move(float x, float y)
        {
            this._physicsBody.velocity = new Vector2(x, y).normalized * this._moveSpeed;
        }
    }
}

