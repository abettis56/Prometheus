using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prometheus
{
    public class CameraData
    {
        public const float CAMERA_SPEED = 30f;
        
        private Camera _camera;
        private float _halfWidth;
        private float _halfHeight;
        private GameObject _objectOfFocus;
        public GameObject ObjectOfFocus { get => _objectOfFocus; set => _objectOfFocus = value; }

        private float _xMin;
        private float _xMax;
        private float _yMin;
        private float _yMax;


        public CameraData(Camera camera, GameObject objectOfFocus, Collider2D sceneBound)
        {
            this._camera = camera;
            this._objectOfFocus = objectOfFocus;
            
            this._halfHeight = this._camera.orthographicSize;
            this._halfWidth = this._camera.orthographicSize * this._camera.aspect;

            this._xMin = sceneBound.bounds.min.x;
            this._xMax = sceneBound.bounds.max.x;
            this._yMin = sceneBound.bounds.min.y;
            this._yMax = sceneBound.bounds.max.y;
        }

        //Causes Camera to move to _objectOfFocus, within current scene bindings.
        public void CameraFollowFocus()
        {
            float x = Mathf.Clamp(this._objectOfFocus.transform.position.x, 
                                  this._xMin + this._halfWidth, this._xMax - this._halfWidth);
            float y = Mathf.Clamp(this._objectOfFocus.transform.position.y,
                                  this._yMin + this._halfHeight, this._yMax - this._halfHeight);
            this._camera.transform.position = new Vector3(x, y, this._camera.transform.position.z);
        }
    }
}

