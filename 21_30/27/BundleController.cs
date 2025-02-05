using UnityEngine;

public class BundleController : MonoBehaviour
{
    // Download bundle code at m_10: BundleRequest
    public void BundleController()
    {
        AssetBundle bundle = AssetBundle.LoadFromFile("savePath");
        // Get tên tất cả file asset đc pack trong bundle
        string[] assets = bundle.GetAllAssetNames();

        // Nếu asset đc tạo từ S.O, thì có thể parse sang object của S.O đó
        ScriptableClass journey = bundle.LoadAsset<ScriptableClass>(assets[0]);

        // Khi dùng xog thì unload để free memory
        /// true: unload tất cả asset đi kèm với bundle đó
        bundle.Unload(true);
    }

    public class ScriptableClass : ScriptableObject
    {
        public ScriptableClass() { }
    }
}

