using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AssetLoader : MonoBehaviour
{
    public UnityWebRequest uwr;

    [HideInInspector]
    public bool assetsLoaded;

    Dictionary<GameObject, string> assets = new Dictionary<GameObject, string>();

    private void Awake()
    {
        Debug.Log("StreamingAssets data path: " + Application.streamingAssetsPath);    
    }

    public void AssetStackAdd(GameObject go, string relpath)
    {
        assets.Add(go, relpath);
        Debug.Log("Asset " + go + " @ " + relpath + " was added to the asset stack");
    }

    public void AssetStackRemove(GameObject go)
    {
        assets.Remove(go);
        Debug.Log("Asset " + go + " was removed from the asset stack");
    }

    public void LoadTextures()
    {
        foreach(KeyValuePair<GameObject, string> asset in assets)
        {
            StartCoroutine(UpdateAssetsCo(asset));
        }

        assetsLoaded = true;
        Debug.Log("All assets loaded!", gameObject);
    }

    public static string GetFileLocation(string relPath)
    {
        string path = Application.streamingAssetsPath + relPath;
        Debug.Log("Searching: " + path);
        return path;
    }

    IEnumerator UpdateAssetsCo(KeyValuePair<GameObject, string> asset)
    {
        using (uwr = UnityWebRequestTexture.GetTexture(GetFileLocation(asset.Value)))
        {
            yield return uwr.SendWebRequest();

            if(uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.LogError(uwr.error);
            }
            else
            {
                asset.Key.GetComponent<RawImage>().texture = DownloadHandlerTexture.GetContent(uwr);
                Debug.Log("Asset " + asset + " is being loaded");
            }
        }
    }
}