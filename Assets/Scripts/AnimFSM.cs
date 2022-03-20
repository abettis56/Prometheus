using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prometheus
{
    public class AnimFSM
    {
        private Animator _animator;
        private Dictionary<string, string> _up;
        private Dictionary<string, string> _down;
        private Dictionary<string, string> _left;
        private Dictionary<string, string> _right;

        private string _lastPlayedAnim;

        private Dictionary<string, string> _activeState;

        public AnimFSM(Animator animator)
        {
            this._animator = animator;
            
            this._up = new Dictionary<string, string>();
            this._down = new Dictionary<string, string>();
            this._left = new Dictionary<string, string>();
            this._right = new Dictionary<string, string>();

            this._activeState = this._up;
        }
        
        public void StateTransition(string state)
        {
            switch(state)
            {
                case "up":
                    this._activeState = this._up;
                    break;
                case "down":
                    this._activeState = this._down;
                    break;
                case "left":
                    this._activeState = this._left;
                    break;
                case "right":
                    this._activeState = this._right;
                    break;
            }
        }

        public void PlayAnim(string animKey)
        {
            string animName = this._activeState[animKey];

            if (this._lastPlayedAnim == animName) return;
            this._lastPlayedAnim = animName;
            this._animator.Play(animName);
        }

        public void Register(string tag, string animKey)
        {
            this._up[animKey] = tag + "_" + animKey + "_up";
            this._down[animKey] = tag + "_" + animKey + "_down";
            this._left[animKey] = tag + "_" + animKey + "_left";
            this._right[animKey] = tag + "_" + animKey + "_right";
        }
    }
}