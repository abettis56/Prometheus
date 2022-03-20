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
        Rigidbody2D rigidBody = gameObject.GetComponent<Rigidbody2D>();
        Animator animator = gameObject.GetComponent<Animator>();
        player = new Player(3, 5.0f, true, rigidBody, animator);
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
