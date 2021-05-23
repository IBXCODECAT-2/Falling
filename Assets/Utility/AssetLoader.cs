using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AssetLoader : MonoBehaviour
{
    
    public UnityWebRequest uwr;
    public struct Status
    {
        public enum RawImageAssets {waiting, loading, complete};
        public enum AudioAssets {waiting, loading, complete};
        public enum TextAssets {waiting, loading, complete};
    }

    Dictionary<GameObject, string> assets = new Dictionary<GameObject, string>();
    List<byte> assetType = new List<byte>();

    private void Awake()
    {

        Debug.Log("StreamingAssets data path: " + Application.streamingAssetsPath);    
    }

    public void AssetStackAdd(GameObject go, string relpath)
    {
        IncludeAsset includer = go.GetComponent<IncludeAsset>();
        IncludeAsset.AssetType includerType = go.GetComponent<IncludeAsset>().assetType;
        
        

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

        //assetsLoaded = true;
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
                    "Asset Streaming Error",
                    "An asset could not be found at the following filepath:\n\n" + Application.streamingAssetsPath + asset.Value + "\n\n" + Application.productName + " requires an internet connection to stream game assets. Please verify that you are connected to the internet and try again. If the problem persists, make sure that you have the asset '" + asset.Value + "' in your StreamingAssets directory.\n\nIf you still see this error try re-installing the " + Application.productName + " and report the issue to the issue tracker at https://github.com/IBXCODECAT/Falling/issues and attatch the debug log output file located in \n\n" + Application.consoleLogPath + "\n\nNote that you may continue to play the game in offline mode by choosing 'continue', but the game will be missing some functionality and visuals. (Not recomended)",
                    NativeWinAlert.Options.cancelRetryContinue,
                    NativeWinAlert.Icons.error
                    );

                Debug.Log("NativeWinAlertResponse: " + response);

                switch(response)
                {
                    case 2: //Cancel
                        Debug.Log("Quitting the application.");
                        Application.Quit();
                        break;
                    case 10: //Retry
                        Debug.Log("Trying again...");
                        LoadTextures();
                        break;
                    default:
                        NativeWinAlert.Alert("Missing Assets", Application.productName + " is about to load a level with missing assets. The game may not function properly.", NativeWinAlert.Options.ok, NativeWinAlert.Icons.warn);
                        break;
                }
            }
            else
            {
                try
                {
                    Debug.Log("Attempting to load asset '" + asset + "' as raw image.");
                    asset.Key.GetComponent<RawImage>().texture = DownloadHandlerTexture.GetContent(uwr);
                    Debug.Log("Asset " + asset + " loaded");
                }
                catch
                {
                    Debug.Log("Failed to load asset '" + asset + "' as raw image.");
                }

            }
        }
    }
}