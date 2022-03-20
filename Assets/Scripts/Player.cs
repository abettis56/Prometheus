using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prometheus
{
    public class Player : Entity
    {
        private enum Animations
        {
            move,
            idle,
            attack
        }
        private int _hitPoints;
        public int HitPoints { get => _hitPoints; set => _hitPoints = value; }

        public Player(int hitPoints,
                      float moveSpeed,
                      bool canMove, 
                      Rigidbody2D physicsBody,
                      Animator animator) : 
        base(moveSpeed, canMove, physicsBody, animator)
        {
            _hitPoints = hitPoints;

            this._animFSM.Register("player", "idle");
            this._animFSM.Register("player", "move");
            this._animFSM.Register("player", "attack");
        }
    }
}
