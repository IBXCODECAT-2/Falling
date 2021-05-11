using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCollision : MonoBehaviour
{
    [SerializeField] private GameObject[] audioObjects;
    [SerializeField] private Transform player;

    void OnCollisionEnter(Collision other)
    {
        int random = Random.Range(0, audioObjects.Length);

        Instantiate(audioObjects[random], player.position, Quaternion.identity, null);
    }
}
