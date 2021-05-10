using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCollision : MonoBehaviour
{
    [SerializeField] private GameObject[] audioObjects;
    [SerializeField] private GameObject particleObject;
    [SerializeField] private Transform player;
    [SerializeField] private float destroyTime;

    void OnCollisionEnter(Collision other)
    {
        int random = Random.Range(0, audioObjects.Length);

        Instantiate(audioObjects[random], player.position, Quaternion.identity, null);
        Destroy(audioObjects[random], destroyTime);

        Instantiate(particleObject, player.position, Quaternion.identity, null);
        Destroy(particleObject, destroyTime);
    }
}
