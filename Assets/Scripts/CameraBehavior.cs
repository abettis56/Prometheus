using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prometheus;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject objectOfFocus;
    [SerializeField]
    Collider2D sceneBound;
    CameraData cameraData;
    
    void Start()
    {
        cameraData = new CameraData(gameObject.GetComponent<Camera>(), 
                                    objectOfFocus,
                                    sceneBound);
    }

    void Update()
    {
        cameraData.CameraFollowFocus();
    }
}
