using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncludeAsset : MonoBehaviour
{
    public enum AssetType { texture, audio, text}
    
    [SerializeField] public AssetType assetType;
    
    [SerializeField] private string assetPath;

    AssetLoader assetLoader;

    private void Awake()
    {
        assetLoader = FindObjectOfType<UnityEngine.EventSystems.EventSystem>().GetComponent<AssetLoader>();
        assetLoader.AssetStackAdd(gameObject, assetPath);
    }

    private void Start()
    {
        
    }
}
