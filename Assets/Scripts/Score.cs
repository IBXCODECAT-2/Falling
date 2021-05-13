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
            score.text = "Copyright (C) 2021 IBXCODECAT [Nathan Schmitt]";
            score.text += "\nPos: " + player.transform.position.ToString();
            score.text += "\nTime: " + Time.time + "Delta: " + Time.deltaTime + "Uncaled: " + Time.unscaledDeltaTime + "Fixed: " + Time.fixedDeltaTime;
            score.text += "\nFrame Count: " + Time.frameCount;
            score.text += "\nAssets: " + Application.streamingAssetsPath + "\nPersistant: " + Application.persistentDataPath;
            yield return new WaitForSeconds(updateSpeed);
        }
    }
}
