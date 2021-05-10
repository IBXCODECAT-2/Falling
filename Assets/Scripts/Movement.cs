using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float gravity;

    private Rigidbody physics;

    void Awake()
    {
        physics = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        physics.AddForce(new Vector3(x * force, -gravity, y * force));
    }
}
