using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [Header("Level Loading")]
    [SerializeField] private int[] scenes;
    [SerializeField] private Slider progressBar;
    [SerializeField] private TextMeshProUGUI progressReport;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
        if (instance == null)
        {
            Init();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

    }

    private void Init()
    {
        instance = this;

        progressBar.maxValue = 0.9f * scenes.Length;

        foreach (int scene in scenes)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(scene);

            while(!operation.isDone)
            {
                progressBar.value = operation.progress;
                //progressReport.text = "Loading:" + operation.ToString();
            }
        }
    }
}
