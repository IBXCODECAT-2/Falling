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
                
                int response = NativeWinAlert.Alert(
                    "No Internet Connection",
                    Application.productName + " requires an internet connection to stream game assets from our servers. Please connect to the internet or try again later.\n\nIf this problem persists, report it to the issue tracker at https://github.com/IBXCODECAT/Falling/issues and attatch the debug log output file located in \n\n" + Application.consoleLogPath + ".\n\nYou may continue in offline mode, but the game will be missing some functionality or visuals. (Not recomended)",
                    NativeWinAlert.Options.cancelRetryContinue,
                    NativeWinAlert.Icons.error
                    );

                Debug.Log(response);

                switch(response)
                {
                    case 2: //Cancel
                        UnityEngine.Diagnostics.Utils.ForceCrash(UnityEngine.Diagnostics.ForcedCrashCategory.Abort);
                        break;
                    case 10: //Retry
                        LoadTextures();
                        break;
                }
            }
            else
            {
                asset.Key.GetComponent<RawImage>().texture = DownloadHandlerTexture.GetContent(uwr);
                Debug.Log("Asset " + asset + " is being loaded");
            }
        }
    }
}