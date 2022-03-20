using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prometheus;

public class PlayerBehavior : MonoBehaviour
{
    Player player;

    float xAxisInput;
    float yAxisInput;

    void Start()
    {
        player = new Player(3, 5.0f, true, gameObject.GetComponent<Rigidbody2D>());
    }

    void Update()
    {
        xAxisInput = Input.GetAxisRaw("Horizontal");
        yAxisInput = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        player.Move(xAxisInput, yAxisInput);
    }
}
