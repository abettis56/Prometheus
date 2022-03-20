using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prometheus
{
    public class Player : Entity
    {
        private int _hitPoints;
        public int HitPoints { get => _hitPoints; set => _hitPoints = value; }

        public Player(int hitPoints,
                      float moveSpeed,
                      bool canMove, 
                      Rigidbody2D physicsBody) : 
        base(moveSpeed, canMove, physicsBody)
        {
            _hitPoints = hitPoints;
        }
    }
}
