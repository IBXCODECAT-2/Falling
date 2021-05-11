using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private float updateSpeed;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private Transform player;

    private IEnumerator Start()
    {
        while(true)
        {
            score.text = Time.time.ToString();
            yield return new WaitForSeconds(updateSpeed);
        }
    }
}
