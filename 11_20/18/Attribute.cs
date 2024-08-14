using UnityEngine;
using NaughtyAttributes;
using System;

public class Attribute : MonoBehaviour
{
    Enum testEnum;
    
    // ShowIf: Chỉ show trên Editor khi thoả mãn điều kiện của Enum
    [ShowIf(nameof(testEnum), Enum.One)][AllowNesting] public int VarOne;
    [ShowIf(nameof(testEnum), Enum.Two)][AllowNesting] public int VarTwo;

    // AllowNesting: giúp hiển thị cụ thể các field của các instance của class chứa nhiều field bên trong
    /// Class vẫn cần Serializable để hiển thị đc ra Inspector
    [AllowNesting] public NestedClass nestedClass;

    // Scene: hiện dropdown các scene đang dùng để dễ chọn hơn
    [Scene] public SceneAsset sceneToLoad;  // Selectable scene asset
    [Scene] public string sceneName; // Còn có thể chọn theo name string

    // Tạo 1 button trên Inspector (label đi kèm) để chạy hàm (giống ContextMenu)
    /// Hàm cần là public void
    [Button("Import from drive")]
    public void ImportFromDrive(){}
}

public enum Enum
{
    One,
    Two,
    Three
}

[Serializable]
public class NestedClass {
    public string name;
    public int age;
}