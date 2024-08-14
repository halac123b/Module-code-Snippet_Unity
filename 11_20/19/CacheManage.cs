using UnityEngine;

// Quản lí bộ nhớ cache của app
public class CacheManage
{
  private void ManageCache()
  {
    // Xoá tất cả AssetBundle data đc lưu trong cache
    Caching.ClearCache();
  }
}
