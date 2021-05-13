using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    [SerializeField] private GameObject explosionObject;
    [SerializeField] private byte explosionIntensity;

    void OnCollisionEnter(Collision other)
    {
        for(int i = 0; i < explosionIntensity; i++)
        {
            Instantiate(explosionObject, transform.position, Quaternion.identity, null);
        }

        Destroy(gameObject);
    }
}
