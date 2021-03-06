using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prometheus;

public class PlayerBehavior : MonoBehaviour
{
    Player player;

    int xAxisInput;
    int yAxisInput;

    void Start()
    {
        Rigidbody2D rigidBody = gameObject.GetComponent<Rigidbody2D>();
        Animator animator = gameObject.GetComponent<Animator>();
        player = new Player(3, 5.0f, true, rigidBody, animator);
    }

    void Update()
    {
        xAxisInput = (int)Math.Round(Input.GetAxisRaw("Horizontal"));
        yAxisInput = (int)Math.Round(Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {
        player.Move(xAxisInput, yAxisInput);
    }
}
