using UnityEngine;

public class ApplicationClass
{
  private void PathName()
  {
    // Path đến folder Data của bản build hoặc Editor
    /// Editor: folder asset
    /// Standalone: folder <projectName_Data>
    /// Android: folder assets
    Debug.Log(Application.dataPath);

    // Path đến nơi chứa data về app đc giữ lại và duy trì sau nhiều lần mở app
    /// Windows: AppData/LocalLow
    Debug.Log(Application.persistentDataPath);

    // String: version hiện tại của app (1.0.0)
    Debug.Log(Application.version);

    // Set fps cho game, Unity sẽ cố để render đúng tỉ lệ này
    Application.targetFrameRate = 60;
  }
}
