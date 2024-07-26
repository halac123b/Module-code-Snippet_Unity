using TriLibCore;

public class TrilibCode
{
  private void LoadModel()
  {
    // Option when load 3D model
    // AssetLoader: class giúp load 3D model
    /// arg: 1: option đc lưu dưới dạng Scriptable obj, chọn có lưu lại thành asset k
    ///      2. Pass `true `if you are caching your AssetLoaderOptions instance.
    AssetLoaderOptions assetLoaderOption = AssetLoader.CreateDefaultLoaderOptions(false, true);

    // Load async 1 file model từ folder lên scene
    /// wrapperGameObject: gameObject parent của obj đc load lên
    AssetLoader.LoadModelFromFile("path/to/file.fbx", OnLoad, OnMaterialsLoad, OnProgress, OnError, wrapperGameObject, assetLoaderOption);
  }

  // Chạy khi model đã load xong Mesh và hierarchy
  private void OnLoad(AssetLoaderContext assetLoaderContext) { }

  // Chạy khi model đã load xong Texture và Material
  protected void OnMaterialsLoad(AssetLoaderContext assetLoaderContext)
  {
    // GameObject vừa mới đc load lên
    GameObject rootGameObject = assetLoaderContext.RootGameObject;
  }
  // Chạy mỗi khi tiến độ load model thay đổi
  /// value: tỉ lệ % đã load xong
  protected void OnProgress(AssetLoaderContext assetLoaderContext, float value) { }
  // Chạy khi có lỗi xảy ra
  protected void OnError(IContextualizedError contextualizedError) { }
}
