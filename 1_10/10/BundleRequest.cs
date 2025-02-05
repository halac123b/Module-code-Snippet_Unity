// using System.Collections;
// using Unity.Notifications.iOS;
using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class BundleRequest : MonoBehaviour
{
    public void DownloadBundleToFile(string url, string fileName, uint version, Action<AssetBundle> onDownloadSuccess, Action onFail)
    {
        StartCoroutine(DownloadBundleToFileIE(url, fileName, version, onDownloadSuccess));
    }

    static IEnumerator DownloadBundleToFileIE(string url, string fileName, uint version, Action<AssetBundle> onDownloadSuccess)
    {
        Debug.Log("[Journey Asset] DownloadBundleToFileIE url:" + url + " version:" + version);
        // Wait for the Caching system to be ready
        while (!Caching.ready)
        {
            yield return null;
        }

        // Special request for asset bundle
        using (UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url, version, 0))
        {
            string savePath = Path.Combine(Application.persistentDataPath, fileName);
            Debug.Log("pathsaved: " + savePath);

            using (DownloadHandlerFile dhf = new(savePath))
            {
                www.downloadHandler = dhf;
                yield return www.SendWebRequest();

                if (!string.IsNullOrEmpty(www.error))
                {
                    // Some error occurred
                    UnityLog.LogI("[Journey Asset] Webreg error=" + www.error);
                }
                else
                {
                    AssetBundle bundle = AssetBundle.LoadFromFile(savePath);
                    if (bundle)
                    {
                        Debug.Log("[Journey Asset] bundle: success " + bundle);
                        onDownloadSuccess?.Invoke(bundle);
                    }
                    else
                    {
                        UnityLog.LogE("[Journey Asset] Bundle is null");
                    }
                }
            }
        }
    }
}

