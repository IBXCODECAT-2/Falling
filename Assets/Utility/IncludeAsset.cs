using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IncludeAsset : MonoBehaviour
{
    [SerializeField] private string assetPath;

    AssetLoader assetLoader;

    private void Awake()
    {
        assetLoader = FindObjectOfType<EventSystem>().GetComponent<AssetLoader>();
        assetLoader.AssetStackAdd(gameObject, assetPath);
    }

    private void Start()
    {
        if(assetLoader.assetsLoaded == false)
        {
            assetLoader.LoadTextures();
        }
        else
        {
            Debug.LogWarning("Assetloader already loaded assets. Assetloading task terminated.");
        }
    }
}
