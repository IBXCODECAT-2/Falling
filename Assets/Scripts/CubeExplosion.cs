using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    [SerializeField] private GameObject explosionObject;

    void OnCollisionEnter(Collision other)
    {
        Instantiate(explosionObject, transform.position, Quaternion.identity, null);
        Destroy(gameObject);
    }
}
