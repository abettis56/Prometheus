using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prometheus
{
    public class Entity
    {
        protected enum AnimationStates
        {
            up,
            down,
            left,
            right
        }
        protected float _moveSpeed;
        public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
        protected bool _canMove;
        public bool CanMove { get => _canMove; set => _canMove = value; }
        protected Vector2 _pastVelocity;
        protected Rigidbody2D _physicsBody;
        public Rigidbody2D PhysicsBody { get => _physicsBody; }
        protected AnimFSM _animFSM;

        public Entity(float moveSpeed,
                      bool canMove,
                      Rigidbody2D physicsBody,
                      Animator animator)
        {
            this._canMove = canMove;
            this._moveSpeed = moveSpeed;
            this._physicsBody = physicsBody;
            this._animFSM = new AnimFSM(animator);

            this._pastVelocity = Vector2.zero;
        }

        public void Move(int x, int y)
        {
            if(!this._canMove) { return; }
            this._physicsBody.velocity = new Vector2((float)x, (float)y).normalized * this._moveSpeed;
            
            //Animation state
            switch(x)
            {
                case -1:
                    this._animFSM.StateTransition(AnimationStates.left.ToString());
                    break;
                case 0:
                    switch(y)
                    {
                        case -1:
                            this._animFSM.StateTransition(AnimationStates.down.ToString());
                            break;
                        case 0:
                            break;
                        case 1:
                            this._animFSM.StateTransition(AnimationStates.up.ToString());
                            break;
                    }
                    break;
                case 1:
                    this._animFSM.StateTransition(AnimationStates.right.ToString());
                    break;
            }

            //Animation checks 
            float vecLength = this._physicsBody.velocity.sqrMagnitude;
            if(x == 0 && y == 0)
            {
                this._animFSM.PlayAnim("idle");
            }
            else
            {
                this._animFSM.PlayAnim("move");
            }
        }
    }
}

