using UnityEditor;

// Chuyên quản lí các file asset của game, nhưng chỉ chạy đc trong Editor
public class AssetDatabaseManager
{
  private void ManageAsset()
  {
    string filePath = ""path/to/file.asset"";
    // Load file script obj từ project và lưu vào biến
    LevelDesignCollection design = AssetDatabase.LoadAssetAtPath<LevelDesignCollection>(filePath);

    // Nếu k có file nào thì ra null
    if (levelDesignSo == null)
    {
        // Tạo 1 instance script obj mới
        ScriptableObject newFile = ScriptableObject.CreateInstance(typeof(LevelDesignCollection));

        // Tạo file asset mới tại path ban đầu
        AssetDatabase.CreateAsset(newFile, filePath);
        // Hàm trên tạo mới nhưng chưa lưu, bc này mới lưu
        AssetDatabase.SaveAssets();
        // Refresh rồi mới update và load lên đc
        AssetDatabase.Refresh();
    
        levelDesignSo = newFile as LevelDesignCollection;    
    }ß
}
}

// 1 class ScriptableObject có file lưu trong project với định dạng .asset
public class LevelDesignCollection : ScriptableObject {}